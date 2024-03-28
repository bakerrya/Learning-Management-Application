using Library.Canvas.database;
using Library.Canvas.Models;
namespace Library.Canvas.Services{
    public class CourseService{

        private static CourseService? _instance;

        public static CourseService Current
        {
            get 
            {
                if (_instance == null)
                {
                    _instance = new CourseService();
                }
                return _instance;
            }
        }

        private CourseService()
        {

        }

        public IEnumerable<Course> Courses
        {
            get
            {
                return fakeDB.Courses.Where(p => p is Course).Select(p => p as Course);
            }

        }

        public void Add(Course course){
            if (!fakeDB.Courses.Any(c => c.Code == course.Code || c.Name == course.Name))
            {
                fakeDB.Courses.Add(course);
            }
        }

        public List<Person> GetRosterForCourse(Course course)
        {
            List<Person> roster = new List<Person>(); 

            foreach (var fakeCourse in fakeDB.Courses)
            {
                if (fakeCourse == course)
                {
                    roster = fakeCourse.Roster ?? new List<Person>();
                }
            }

            return roster;
        }

        public void AddStudent(Person selectedStudent, Course selectedCourse){
            foreach (var course in fakeDB.Courses){
                if (course.Name == selectedCourse.Name){
                    if(course.Roster == null)
                    {
                        course.Roster = new List<Person>();
                    }
                    course.Roster.Add(selectedStudent);
                }
            }

            Console.WriteLine("Updated Roster: ");
            selectedCourse.Roster.ForEach(Console.WriteLine);
            Console.WriteLine();
        }

        public void RemoveStudent(Person selectedStudent, Course selectedCourse){
            if (!selectedCourse.Roster.Remove(selectedStudent))
            {
                Console.WriteLine("Student not found in Course Roster");
            }

            Console.WriteLine("Updated Roster: ");
            selectedCourse.Roster.ForEach(Console.WriteLine);
            Console.WriteLine();

        }

        public IEnumerable<Course> SearchCourse(string query){
            return Courses
                .Where(s => s.Name.ToUpper().Contains(query.ToUpper()))
                .Concat(Courses.Where(s => s.Description.ToUpper().Contains(query.ToUpper())));
        }
        public void ListCourses(){
            foreach (var s in Courses){
                Console.WriteLine($@"Code: {s.Code}, Name: {s.Name}, Description: {s.Description}, Roster: {s.Roster ?? []}, Assignments: {s.Assignments ?? []},
                Modules: {s.Modules ?? []}");
            }
            Console.WriteLine();
        }
        

    }
}
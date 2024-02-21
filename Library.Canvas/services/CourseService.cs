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
                return fakeDB.Courses.ToList();
            }

        }

        public void Add(Course course){
            fakeDB.Courses.Add(course);
        }

        public void AddStudent(Person selectedStudent, Course selectedCourse){
            foreach (var course in Courses){
                if (course.Name == selectedCourse.Name){
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
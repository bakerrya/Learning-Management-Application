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
        public IEnumerable<Module> GetModulesForCourse(string courseName)
        {
            var course = fakeDB.Courses.FirstOrDefault(c => c.Name == courseName && c is Course) as Course;
            return course?.Modules ?? Enumerable.Empty<Module>();
        }
        public void AddModule(Module module, string courseName)
        {
            var course = fakeDB.Courses.FirstOrDefault(c => c.Name == courseName);
            if (course != null)
            {
                if (course.Modules == null)
                {
                    course.Modules = new List<Module>();
                }
                course.Modules.Add(module);
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
                    selectedStudent.Classes.Add(course);
                }
            }

        }

        public void AddAssignment(Assignment assignment, Course selectedCourse)
        {
            foreach (var course in fakeDB.Courses)
            {
                if (course.Name == selectedCourse.Name)
                {
                    if (course.Assignments == null)
                    {
                        course.Assignments = new List<Assignment>();
                    }
                    course.Assignments.Add(assignment);
                }
            }

        }
        public Course GetCourseByName(string courseName)
        {
            return fakeDB.Courses.FirstOrDefault(c => c.Name.Equals(courseName, StringComparison.OrdinalIgnoreCase)) as Course;
        }
        public void RemoveStudent(Person selectedStudent, Course selectedCourse){
            if (!selectedCourse.Roster.Remove(selectedStudent))
            {
                Console.WriteLine("Student not found in Course Roster");
            }

        }
        public IEnumerable<Assignment> GetAssignmentsForCourse(string courseName)
        {
            var course = fakeDB.Courses.FirstOrDefault(c => c.Name == courseName && c is Course) as Course;
            return course?.Assignments ?? Enumerable.Empty<Assignment>();
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
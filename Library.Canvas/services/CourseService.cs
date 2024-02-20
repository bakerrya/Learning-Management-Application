using Library.Canvas.Models;
namespace Library.Canvas.Services{
    public class CourseService{
        public List<Course> courseList = new List<Course>();

        public void Add(Course course){
            courseList.Add(course);
        }

        public void AddStudent(Person selectedStudent, Course selectedCourse){
            foreach (var course in courseList){
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
            return courseList
                .Where(s => s.Name.ToUpper().Contains(query.ToUpper()))
                .Concat(courseList.Where(s => s.Description.ToUpper().Contains(query.ToUpper())));
        }
        public void ListCourses(){
            foreach (var s in courseList){
                Console.WriteLine($@"Code: {s.Code}, Name: {s.Name}, Description: {s.Description}, Roster: {s.Roster ?? []}, Assignments: {s.Assignments ?? []},
                Modules: {s.Modules ?? []}");
            }
            Console.WriteLine();
        }
        

    }
}
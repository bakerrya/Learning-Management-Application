using Canvas.Models;
namespace Canvas.Services{
    public class CourseService{
        public List<Course> courseList = new List<Course>();

        public void Add(Course course){
            courseList.Add(course);
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
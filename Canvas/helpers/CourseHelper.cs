using Canvas.Models;
using Canvas.Services;

namespace Canvas.Helpers {
    internal class CourseHelper{

        private CourseService courseService = new CourseService();
        public void CreateCourseRecord(){
            Console.WriteLine("Please enter in the course code: ");
            int.TryParse(Console.ReadLine(), out var code);
            Console.WriteLine("Please enter in the name of the course: ");
            var name = Console.ReadLine();
            Console.WriteLine("Please enter an optional description: ");
            var description = Console.ReadLine();
            
            var course = new Course(code, name ?? string.Empty, description ?? string.Empty);

            courseService.Add(course);

            foreach (var s in courseService.courseList){
                Console.WriteLine($@"Code: {s.Code}, Name: {s.Name}, Description: {s.Description}, Roster: {s.Roster ?? []}, Assignments: {s.Assignments ?? []},
                Modules: {s.Modules ?? []}");
            }
            Console.WriteLine();

        }

        public void ListCourses(){
            courseService.ListCourses();
        }
    }
}
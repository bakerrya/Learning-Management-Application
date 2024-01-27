using System.Security.Cryptography.X509Certificates;
using System.Globalization;
using Canvas.Models;
using Canvas.Services;

namespace Canvas.Helpers{
    internal class AssignmentHelper{

        public CourseService courseService = new CourseService();
        public AssignmentHelper(CourseService csrvc){
            courseService = csrvc; 
        }

        public void CreateAssignment(){
            Console.WriteLine("Please enter the name of the assignment: ");
            var name = Console.ReadLine();
            Console.WriteLine("Please enter the assignment description: ");
            var desc = Console.ReadLine();
            Console.WriteLine("Please enter the total points: ");
            int.TryParse(Console.ReadLine(), out int points);
            Console.WriteLine("Please enter the due date in the form : MM/dd/yyyy");
            DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDueDate);
            Console.WriteLine("Please enter the name of the course you would like to add the assignment to: ");
            var courseName = Console.ReadLine();
            Course selectedCourse;
            if (courseName != null)
            {
                selectedCourse = courseService.courseList.FirstOrDefault(s => s.Name == courseName);
                if (selectedCourse == null){
                    Console.WriteLine("No such course found");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
                return;
            }

            var newAssignment = new Assignment(name ?? "Unnamed Assignment", desc ?? string.Empty, points, parsedDueDate);

            selectedCourse.Assignments.Add(newAssignment);

            Console.WriteLine("Outputting updated list of assignments");
            selectedCourse.Assignments.ForEach(Console.WriteLine);
            Console.WriteLine();

        }
    
    }

}
using Canvas.Models;
using Canvas.Services;

namespace Canvas.Helpers {
    internal class StudentHelper{

        private StudentService studentService = new StudentService();
        public void CreateStudentRecord(){
            Console.WriteLine("Please enter in the name of the student: ");
            var name = Console.ReadLine();
            Console.WriteLine("What is the Classification of the Student? Choices: Freshmen, Sophomore, Junior, Senior...");
            Enum.TryParse<Classification>(Console.ReadLine(), out var userClassification);
            
            var student = new Person(name ?? string.Empty, userClassification);

            studentService.Add(student);

            foreach (var s in studentService.studentList){
                Console.WriteLine($"ID: {s.id}, Name: {s.Name}, Classification: {s.Classification}");
            }
            Console.WriteLine();

        }

        public void SearchStudent(){
            Console.WriteLine("Please enter in student name: ");
            var query = Console.ReadLine() ?? string.Empty;
            studentService.SearchStudent(query).ToList().ForEach(Console.WriteLine);
        }
        public void ListStudents(){
            studentService.ListStudents();
        }
    }
}
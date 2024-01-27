using Canvas.Models;
using Canvas.Services;

namespace Canvas.Helpers {
    internal class StudentHelper{

        private StudentService studentService;
        
        public StudentHelper(StudentService ssrvc){
            studentService = ssrvc;
        }


        public void CreateStudentRecord(Person? selectedStudent = null){
            Console.WriteLine("Please enter in the name of the student: ");
            var name = Console.ReadLine();
            Console.WriteLine("What is the Classification of the Student? Choices: Freshmen, Sophomore, Junior, Senior...");
            Enum.TryParse<Classification>(Console.ReadLine(), out var userClassification);
            
            if (selectedStudent == null){
                var student = new Person(name ?? string.Empty, userClassification);
                studentService.Add(student);
                studentService.studentList.ForEach(Console.WriteLine);
                Console.WriteLine();
                return;
            }
            selectedStudent.Name = name;
            selectedStudent.Classification = userClassification;

            studentService.studentList.ForEach(Console.WriteLine);
            Console.WriteLine();

        }

        public void updatePerson(){
            Console.WriteLine("Please select a course to update: ");
            studentService.studentList.ForEach(Console.WriteLine);
            var desiredStudent = Console.ReadLine();

            Person selectedStudent = studentService.studentList.FirstOrDefault(s => s.Name == desiredStudent);

            if (selectedStudent == null){
                Console.WriteLine("No such course found");
                Console.WriteLine();
                return;
            }
            
            CreateStudentRecord(selectedStudent);

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
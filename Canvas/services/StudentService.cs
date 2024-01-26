using Canvas.Models;
namespace Canvas.Services{
    public class StudentService{
        public List<Person> studentList = new List<Person>();

        public void Add(Person student){
            studentList.Add(student);
        }

        public void ListStudents(){
            foreach (var s in studentList){
                Console.WriteLine($"ID: {s.id}, Name: {s.Name}, Classification: {s.Classification}");
            }
            Console.WriteLine();
        }
    }
}
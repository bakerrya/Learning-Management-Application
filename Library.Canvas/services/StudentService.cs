using Library.Canvas.Models;
namespace Library.Canvas.Services{
    public class StudentService{
        public List<Person> studentList = new List<Person>();

        public void Add(Person student){
            studentList.Add(student);
        }

        public IEnumerable<Person> SearchStudent(string query){
            return studentList.Where(s => s.Name.ToUpper().Contains(query.ToUpper()));
        }

        public void ListStudents(){
            foreach (var s in studentList){
                Console.WriteLine($"ID: {s.id}, Name: {s.Name}, Classification: {s.Classification}");
            }
            Console.WriteLine();
        }
    }
}
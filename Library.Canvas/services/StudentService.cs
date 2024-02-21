using Library.Canvas.database;
using Library.Canvas.Models;
namespace Library.Canvas.Services{
    public class StudentService{
        private static StudentService _instance;
        public IEnumerable<Person> Students
        {
            get
            {
                return fakeDB.People.ToList();
            }

        }

        public static StudentService Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StudentService();
                }

                return _instance;
            }
        }

        private StudentService() {

        }


        public void Add(Person student){
            fakeDB.People.Add(student);
        }

        public IEnumerable<Person> SearchStudent(string query){
            return Students.Where(s => s.Name.ToUpper().Contains(query.ToUpper()));
        }

        public void ListStudents(){
            foreach (var s in Students){
                Console.WriteLine($"ID: {s.id}, Name: {s.Name}, Classification: {s.Classification}");
            }
            Console.WriteLine();
        }
    }
}
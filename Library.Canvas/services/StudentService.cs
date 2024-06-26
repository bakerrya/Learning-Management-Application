using Library.Canvas.database;
using Library.Canvas.Models;
using System.Collections.ObjectModel;
namespace Library.Canvas.Services{
    public class StudentService{
        private static StudentService _instance;
        public IEnumerable<Person> Students
        {
            get
            {
                return fakeDB.People.Where(p => p is Person).Select(p => p as Person);
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


        public IEnumerable<Course?> GetClasses(Person student)
        {
            return fakeDB.Courses.Where(course => student.Classes.Any(aClass => aClass.Code == course.Code));
        }
        
        public void Remove(Person student)
        {
            fakeDB.People.Remove(student);
        }

        public Person? GetById(int id)
        {
            return fakeDB.People.FirstOrDefault(p => p.id == id);
        }

        public IEnumerable<Person?> SearchStudent(string query){
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
namespace Library.Canvas.Models{
    public class Person{

        private static int lastId = 0;
        public int id {get; set;}
        public string Name { get; set; }
        public Enum Classification { get; set; }
        public Dictionary<int, List<int>> Grades { get; set; }
        public List<Course> Classes { get; set; }

        public Person(string name, Enum classification)
        {
            this.id = ++lastId;
            this.Name = name;
            this.Classification = classification;
            this.Grades = new Dictionary<int, List<int>>();
            this.Classes = new List<Course>();

        }

        public void DisplayStudentInfo()
        {
            Console.WriteLine($"Name: {Name}, Student Classification: {Classification}, GPA: {Grades}");
        }

        public override string ToString()
        {
            return $"Name: {Name}, Student Classification: {Classification}";
        }
    }

    public enum Classification
    {
        Freshmen,
        Sophomore,
        Junior, 
        Senior
    }
} 
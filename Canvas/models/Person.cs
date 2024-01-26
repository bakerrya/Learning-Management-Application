namespace Canvas.Models{
    public class Person{
        public Guid id {get; set;}
        public string Name { get; set; }
        public Enum Classification { get; set; }
        public Dictionary<int, List<int>> Grades { get; set; }
        public List<Course> Classes { get; set; }

        public Person(string name, Enum classification)
        {
            this.id = Guid.NewGuid();
            this.Name = name;
            this.Classification = classification;
            this.Grades = new Dictionary<int, List<int>>();
            this.Classes = new List<Course>();

        }

        public void DisplayStudentInfo()
        {
            Console.WriteLine($"Name: {Name}, Student Classification: {Classification}, GPA: {Grades}");
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
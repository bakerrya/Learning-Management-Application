namespace Library.Canvas.Models{
    public class Course{
        public int Code { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public List<Person>? Roster { get; set; }

        public List<Assignment>? Assignments { get; set; }

        public List<Module>? Modules { get; set; }

        public Course(int code, string name, string? description)
        {
            this.Code = code;
            this.Name = name;
            this.Description = description;
            this.Roster = new List<Person>();
            this.Assignments = new List<Assignment>();
            this.Modules = new List<Module>();  
        }

        public Course()
        {
        }

        public void DisplayCourseInfo()
        {
            Console.WriteLine($"Course Name: {Name} {Code}");
        }

        public override string ToString()
        {
            return $"Name: {Name}";
        }



    }
}
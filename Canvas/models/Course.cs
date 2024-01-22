
public class Course{
    public int Code { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public List<Person>? Roster { get; set; }

    public List<Assignment>? Assignments { get; set; }

    public List<Module>? Modules { get; set; }

    public Course(int code, string name, string? description, List<Person>? roster = null, List<Assignment>? assignments = null, List<Module>? modules = null)
    {
        this.Code = code;
        this.Name = name;
        this.Description = description;
        this.Roster = roster ?? new List<Person>();
        this.Assignments = assignments ?? new List<Assignment>();
        this.Modules = modules ?? new List<Module>();  
    }

    public void DisplayCourseInfo()
    {
        Console.WriteLine($"Code:{Code}, Name: {Name}, Description: {Description}, Roster: {Roster}, Assignments: {Assignments}, Modules: {Modules}");
    }


}
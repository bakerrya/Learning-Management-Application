
public class Course{
    public int Code { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public List<Person> Roster { get; set; }

    public List<Assignment> Assignments { get; set; }

    public List<Module> Modules { get; set; }

    Course(int code, string name, string? description, List<Person> roster, List<Assignment> assignments, List<Module> modules)
    {
        this.Code = code;
        this.Name = name;
        this.Description = description;
        this.Roster = roster;
        this.Assignments = assignments;
        this.Modules = modules;  
    }


}
public class Person{
    public string? Name;
    public Enum? Classification;
    public double? Grades;

    public Person(string? name, Enum? classification, double? grades = 0.00)
    {
        this.Name = name;
        this.Classification = classification;
        this.Grades = grades;

    }

    public void DisplayStudentInfo()
    {
        Console.WriteLine($"Name: {Name}, Student Classification: {Classification}, GPA: {Grades}");
    }
}

public enum Classification
{
    freshman,
    sophomore,
    junior, 
    senior
}
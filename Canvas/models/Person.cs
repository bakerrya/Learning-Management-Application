public class Person{
    public string? Name;
    public Enum? Classification;
    public double? Grades;

    Person(string? name, Enum? classification, double? grades = 0.00)
    {
        this.Name = name;
        this.Classification = classification;
        this.Grades = grades;

    }
}

public enum Classification
{
    freshman,
    sophomore,
    junior, 
    senior
}
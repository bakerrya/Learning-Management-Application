namespace Canvas.Models{
    public class Assignment
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int TotalPoints { get; set; }
        public DateTime DueDate { get; set; }

        public Assignment(string name, string? description, int totalPoints, DateTime dueDate)
        {
            this.Name = name;
            this.Description = description;
            this.TotalPoints = totalPoints;
            this.DueDate = dueDate;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Description: {Description}, TotalPoints: {TotalPoints}, Due Date: {DueDate}";
        }
    }
}
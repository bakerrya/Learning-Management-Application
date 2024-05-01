namespace Library.Canvas.Models{
    public class Module{
        public string Name { get; set; }
        public string? Description { get; set; }
        public Module () { }
        public List<ContentItem> Content { get; set; }
        public Module(string name, string? description, List<ContentItem> content)
        {
            this.Name = name;
            this.Description = description;
            this.Content = content;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Description: {Description}";
        }
    }
}
namespace Canvas.Models{
    public class Module{
        public string Name { get; set; }
        public string? Description { get; set; }

        public List<ContentItem> Content { get; set; }
        public Module(string name, string? description, List<ContentItem> content)
        {
            this.Name = name;
            this.Description = description;
            this.Content = content;
        }
    }
}
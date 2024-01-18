public class ContentItem{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Path { get; set; }

    ContentItem(string name, string? description, string path){
        this.Name = name;
        this.Description = description;
        this.Path = path;
    }

}
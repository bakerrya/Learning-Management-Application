namespace Library.Canvas.Models {
    public class ContentItem{
        public string Name { get; set; }
        public string? Description { get; set; }

        public ContentItem(string name, string? description){ 
            this.Name = name;
            this.Description = description;
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Name))
            {
                if (!string.IsNullOrEmpty(Description))
                {
                    return $"{Name}: {Description}";
                }
                else
                {
                    return Name;
                }
            }
            else
            {
                return string.IsNullOrEmpty(Description) ? string.Empty : Description;
            }
        }

    }
}
namespace KadirBeskardes.Models
{
    public class ProjectDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Technologies { get; set; }
        public List<string> ImagesUrl { get; set; }
        public string VideoURL { get; set; }

    }
}

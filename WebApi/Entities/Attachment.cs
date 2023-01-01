namespace WebApi.Entities
{
    public class Attachment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string FileType { set; get; }
        public int TaskId { get; set; }
    }
}
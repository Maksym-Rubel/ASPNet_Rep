namespace _02_Exam_Social_Network.Data.Entities
{
    public class PostImage
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}

namespace _02_Exam_Social_Network.Data.Entities
{
    public class Coment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public string Message { get; set; }


    }
}

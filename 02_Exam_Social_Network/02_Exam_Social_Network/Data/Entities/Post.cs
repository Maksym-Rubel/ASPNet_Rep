namespace _02_Exam_Social_Network.Data.Entities
{
    public class Post
    {
        public int Id { get; set; }

        public ICollection<PostImage> ImgUrls { get; set; }

        public string? Location { get; set; } = null;
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Coment> Coments { get; set; }
        //public ICollection<User> LikeUsers { get; set; }
    }
}

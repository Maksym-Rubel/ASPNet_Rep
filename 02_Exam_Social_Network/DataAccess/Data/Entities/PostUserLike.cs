using Microsoft.AspNetCore.Identity;

namespace _02_Exam_Social_Network.Data.Entities
{
    public class PostUserLike
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}

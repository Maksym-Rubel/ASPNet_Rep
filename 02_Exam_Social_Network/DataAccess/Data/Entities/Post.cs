using Microsoft.AspNetCore.Identity;

namespace DataAccess.Data.Entities
{
    public class Post
    {
        public int Id { get; set; }

        public ICollection<PostImage> ImgUrls { get; set; }

        public string? Location { get; set; } = null;
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;

        public ICollection<Coment> Coments { get; set; }
        //public ICollection<User> LikesUser { get; set; } = new List<User>();
        public ICollection<PostUserLike> PostUserLikes { get; set; } = new List<PostUserLike>();

    }
}

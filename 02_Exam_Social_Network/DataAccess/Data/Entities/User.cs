using Microsoft.AspNetCore.Identity;

namespace _02_Exam_Social_Network.Data.Entities

{
    public class User : IdentityUser
    {
        //public int Id { get; set; }
        //public string NickName { get; set; }

        public string? ImgUrl { get; set; } = "https://cdn.pixabay.com/photo/2023/02/18/11/00/icon-7797704_640.png";

        //public string Name { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }



        public ICollection<Coment> Coments { get; set; }


        public ICollection<Post> Posts { get; set; }
        ////public ICollection<User> Following { get; set; }
        ////public ICollection<User> Followers { get; set; }
        //public ICollection<Post> LikedPosts { get; set; } = new List<Post>();
        public ICollection<PostUserLike> PostUserLikes { get; set; } = new List<PostUserLike>();



    }
}

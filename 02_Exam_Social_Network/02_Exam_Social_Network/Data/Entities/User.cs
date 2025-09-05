namespace _02_Exam_Social_Network.Data.Entities

{
    public class User
    {
        public int Id { get; set; }
        public string NickName { get; set; }

        public string ImgUrl { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }



        public ICollection<Coment> Coments { get; set; }


        public ICollection<Post> Posts { get; set; }
        //public ICollection<User> Following { get; set; }
        //public ICollection<User> Followers { get; set; }
        //public ICollection<Post> LikedPosts { get; set; }


    }
}

using Microsoft.AspNetCore.Identity;

namespace DataAccess.Data.Entities
{
    public class Coment
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;


    }
}

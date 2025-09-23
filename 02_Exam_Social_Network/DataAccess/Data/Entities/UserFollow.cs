using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
    public class UserFollow
    {
        public int Id { get; set; }
        public string FollowerId { get; set; }
        public User Follower { get; set; }

        public string FollowedId { get; set; }
        public User Followed { get; set; }
    }
}

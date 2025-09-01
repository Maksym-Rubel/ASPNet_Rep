using _02_Exam_Social_Network.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace _02_Exam_Social_Network.Data
{
    public class SNetworkDbContext : DbContext
    {
        public SNetworkDbContext()
        {
            //Database.EnsureCreated();
        }




        public SNetworkDbContext(DbContextOptions<SNetworkDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<Coment> Coments { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                                        "Data Source=DESKTOP-JELVTGO\\SQLEXPRESS;Initial Catalog=SocialNetworkDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;Application Intent=ReadWrite;MultiSubnetFailover=False"
                                        );
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>()
            .HasOne(c => c.User)
            .WithMany(c => c.Posts)
            .HasForeignKey(c => c.UserId);


            modelBuilder.Entity<Coment>()
            .HasOne(c => c.User)
            .WithMany(c => c.Coments)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Coment>()
            .HasOne(c => c.Post)
            .WithMany(c => c.Coments)
            .HasForeignKey(c => c.PostId)
            .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<User>().HasData(new List<User>()
            {

                new User() {
                 Id = 1,
                 NickName = "maxyyy42",
                 Name = "Maksym",
                 Email = "rubelmaksum2404@gmail.com",
                 Password = "TestPass22",
                 ImgUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQNL-OXfUdlkKCgDFYV9WXavaJucZsprpGiTA&s",

                },
                new User() {
                    Id = 2,
                    NickName = "igor21",
                    Name = "Igor",
                    Email = "rubelmaksum1@gmail.com",
                    Password = "TestPass22",
                    ImgUrl = "https://randomuser.me/api/portraits/men/14.jpg"
                },
                new User() {
                    Id = 3,
                    NickName = "denys88",
                    Name = "Denys",
                    Email = "rubelmaksum2@gmail.com",
                    Password = "TestPass22",
                    ImgUrl = "https://randomuser.me/api/portraits/men/45.jpg"
                },
                new User() {
                    Id = 4,
                    NickName = "petya09",
                    Name = "Petya",
                    Email = "rubelmaksum3@gmail.com",
                    Password = "TestPass22",
                    ImgUrl = "https://randomuser.me/api/portraits/men/52.jpg"
                },
                new User() {
                    Id = 5,
                    NickName = "vika_sun",
                    Name = "Vika",
                    Email = "rubelmaksum4@gmail.com",
                    Password = "TestPass22",
                    ImgUrl = "https://randomuser.me/api/portraits/women/21.jpg"
                },
                new User() {
                    Id = 6,
                    NickName = "katya_star",
                    Name = "Katya",
                    Email = "rubelmaksum5@gmail.com",
                    Password = "TestPass22",
                    ImgUrl = "https://randomuser.me/api/portraits/women/35.jpg"
                }
    
    

            });
            modelBuilder.Entity<Post>().HasData(new List<Post>()
            {

                new Post() {
                    Id = 1,
                    Location = "",
                    UserId = 1,
                    }
            });
            modelBuilder.Entity<PostImage>().HasData(new List<PostImage>()
            {

                new PostImage() {
                    Id = 1,
                    Url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSFkYcWvynkUjRz8ME31vQoP2dyJXzLYObCQA&s",
                    PostId = 1,
                    },
                new PostImage() {
                    Id = 2,
                    Url = "https://i.guim.co.uk/img/media/87929f76cb1cbd05350d5a7b8fe759857a2e7e78/388_698_3299_1979/master/3299.jpg?width=1200&quality=85&auto=format&fit=max&s=2e1386e2df9c479f2fe3061bed3ac6eb",
                    PostId = 1,
                    }
            });
            modelBuilder.Entity<Coment>().HasData(new List<Coment>()
            {

                new Coment() {
                    Id = 1,
                    PostId = 1,
                    UserId = 3,
                    Message = "Hello maxyyy42"
                },
                new Coment() {
                    Id = 2,
                    PostId = 1,
                    UserId = 1,
                    Message = "my first post"
                }

            });

        }

    }
}

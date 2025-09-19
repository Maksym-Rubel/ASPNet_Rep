using _02_Exam_Social_Network.Data;
using _02_Exam_Social_Network.Data.Entities;
using _02_Exam_Social_Network.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Threading.Tasks;

namespace _02_Exam_Social_Network.Controllers
{
    [Authorize]
    public class AutorizeController : Controller
    {
        private string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier);
        private readonly SNetworkDbContext ctx;
        private readonly IWebHostEnvironment _webHost;
        public AutorizeController(SNetworkDbContext ctx, IWebHostEnvironment webHost)
        {
            this.ctx = ctx;
            _webHost = webHost;
        }

        public async Task<IActionResult> Index(IFormFileCollection fileUp, string Message)
        {
            string uploadFolder = Path.Combine(_webHost.WebRootPath, "uploadPostFromUser");
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }
            if (fileUp.Count > 0)
            {
                ctx.Posts.Add(new Post
                {
                    UserId = CurrentUserId,
                });
                ctx.SaveChanges();
                foreach (var file in fileUp)
                {
                    if (file == null || file.Length == 0)
                    {
                        return View();
                    }
                    string fileName = file.FileName;
                    string fileSavePath = Path.Combine(uploadFolder, fileName);

                    using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }


                    //int length = ctx.PostImages.Count();
                    ctx.PostImages.Add(new PostImage
                    {
                        PostId = ctx.Posts.OrderByDescending(p => p.Id).FirstOrDefault().Id,
                        Url = "/uploadPostFromUser/" + fileName
                    });

                }
                ctx.SaveChanges();
            }

            ctx.Coments.Add(new Coment
            {
                UserId = CurrentUserId,
                PostId = ctx.Posts.OrderByDescending(p => p.Id).FirstOrDefault().Id,
                Message = Message

            });
            ctx.SaveChanges();

            return RedirectToAction("HomeBtn");
        }
        public IActionResult HomeBtn()
        {
            this.ViewBag.ProfileId = CurrentUserId;
            Console.WriteLine(CurrentUserId);
            var model = ctx.Users
                .Include(u => u.Posts)
                    .ThenInclude(p => p.ImgUrls)
                .Include(u => u.Coments)
                .Include(u => u.PostUserLikes)
                    .ThenInclude(n => n.Post)
                    .ThenInclude(n => n.User)

                .ToList();
            return View(model);
        }
        public IActionResult Profile()
        {
            var model = ctx.Users
                .Include(u => u.Posts)
                    .ThenInclude(p => p.ImgUrls)
                .Include(u => u.Coments)
                .FirstOrDefault(m => m.Id == CurrentUserId);
          
            return View(model);
        }

        public IActionResult AddLike(int postId)
        {
            ctx.PostUserLikes.Add(new PostUserLike
            {
                UserId = CurrentUserId,
                PostId = postId
            });
            ctx.SaveChanges();
            Console.WriteLine(postId);
            var model = ctx.Users
                .Include(u => u.Posts)
                    .ThenInclude(p => p.ImgUrls)
                .Include(u => u.Coments)
                .Include(u => u.PostUserLikes)
                    .ThenInclude(n => n.Post)
                    .ThenInclude(n => n.User)

                .ToList();

            return View("HomeBtn", model);
        }
        public IActionResult DeleteLike(int postId)
        {
            var like = ctx.PostUserLikes.FirstOrDefault(u => u.UserId == CurrentUserId && u.PostId == postId);
            ctx.PostUserLikes.Remove(like);

            ctx.SaveChanges();
            Console.WriteLine(postId);
            var model = ctx.Users
                .Include(u => u.Posts)
                    .ThenInclude(p => p.ImgUrls)
                .Include(u => u.Coments)
                .Include(u => u.PostUserLikes)
                    .ThenInclude(n => n.Post)
                    .ThenInclude(n => n.User)

                .ToList();

            return View("HomeBtn", model);
        }
        public IActionResult Delete(int id)
        {
            var PostimagesId = ctx.PostImages.Where(m => m.PostId == id);
            var ComentsId = ctx.Coments.Where(m => m.PostId == id);
            var PostId = ctx.Posts.Find(id);



            if (PostId == null) return NotFound();


            ctx.PostImages.RemoveRange(PostimagesId);
            ctx.Coments.RemoveRange(ComentsId);
            ctx.SaveChanges();

            ctx.Posts.Remove(PostId);
            ctx.SaveChanges();


            return RedirectToAction("HomeBtn");
        }
        public IActionResult Create()
        {
            return RedirectToAction("Index");
        }
        public IActionResult GetPostPartial(int PostId)
        {
            var model =
                ctx.Posts
                .Include(p => p.User)
                .Include(m => m.ImgUrls)
                .Include(n => n.Coments)
                    .ThenInclude(m => m.User)
                .FirstOrDefault(m => m.Id == PostId);

            if (model == null)
                return NotFound();
            return PartialView("_PostViewPartial", model);
        }
        [HttpPost]
        public IActionResult SetComment(string Message, int PostId)
        {
            ctx.Coments.Add(new Coment { Message = Message, PostId = PostId, UserId = "2" });
            ctx.SaveChanges();
            var model =
                ctx.Posts
                .Include(p => p.User)
                .Include(m => m.ImgUrls)
                .Include(n => n.Coments)
                .ThenInclude(m => m.User)
                    .FirstOrDefault(m => m.Id == PostId);

            if (model == null)
                return NotFound();



            return RedirectToAction("Profile", model);




        }

    }
}

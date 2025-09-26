using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace _02_Exam_Social_Network.Controllers
{

    [Authorize]
    public class ProfileController : Controller
    {
        private string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier);
        private readonly SNetworkDbContext ctx;
        private readonly IWebHostEnvironment _webHost;

        public ProfileController(SNetworkDbContext ctx, IWebHostEnvironment webHost)
        {
            this.ctx = ctx;
            _webHost = webHost;
        }
        public IActionResult Profile(string? UserId)
        {
            HttpContext.Session.SetString("ProfileId", CurrentUserId);
            TempData["ReturnUrl"] = Request.Path + Request.QueryString;
            if (UserId == null)
            {
                var model = ctx.Users
                    .Include(u => u.Followers)
                    .Include(u => u.Following)
                .Include(u => u.Posts)
                    .ThenInclude(p => p.ImgUrls)
                .Include(u => u.Posts)
                    .ThenInclude(m => m.PostUserLikes)
                .Include(u => u.Posts)
                    .ThenInclude(m => m.Coments)
                .FirstOrDefault(m => m.Id == CurrentUserId);

                return View(model);
            }
            else
            {
                var model = ctx.Users
                    .Include(u => u.Followers)
                    .Include(u => u.Following)
                .Include(u => u.Posts)
                    .ThenInclude(p => p.ImgUrls)
                .Include(u => u.Posts)
                    .ThenInclude(m => m.PostUserLikes)
                .Include(u => u.Posts)
                    .ThenInclude(m => m.Coments)
                .FirstOrDefault(m => m.Id == UserId);

                return View(model);
            }


        }
        [HttpGet]
        public IActionResult ProfileEdit()
        {
            var model = ctx.Users.FirstOrDefault(m => m.Id == CurrentUserId);

            return View(model);
        }
        [HttpPost]
        public IActionResult ProfileEdit(User user)
        {
            var MyUser = ctx.Users.FirstOrDefault(l => l.Id == CurrentUserId);

            if (MyUser != null)
            {
                MyUser.UserName = user.UserName;
                MyUser.ImgUrl = user.ImgUrl;
                MyUser.Email = user.Email;
                ctx.SaveChanges();

            }

            return RedirectToAction("Profile");
        }
    }
}

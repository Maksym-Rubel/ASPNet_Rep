using System.Diagnostics;
using System.Threading.Tasks;
using _02_Exam_Social_Network.Data;
using _02_Exam_Social_Network.Data.Entities;
using _02_Exam_Social_Network.Models;



using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _02_Exam_Social_Network.Controllers
{
    public class HomeController : Controller
    {

        private readonly SNetworkDbContext ctx;
        private readonly IWebHostEnvironment _webHost;
        public HomeController(SNetworkDbContext ctx, IWebHostEnvironment webHost)
        {
            this.ctx = ctx;
            _webHost = webHost;
        }

        [HttpGet]
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]

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
                    UserId = 1,
                });
                ctx.SaveChanges();
                foreach (var file in fileUp)
                {
                    if (file == null || file.Length == 0)
                    {
                        ModelState.AddModelError("", "Файл не вибрано або він порожній");
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
                UserId = 1,
                PostId = ctx.Posts.OrderByDescending(p => p.Id).FirstOrDefault().Id,
                Message = Message

            });
            ctx.SaveChanges();

            return RedirectToAction("HomeBtn");
        }
        //public async Task<IActionResult> Index(IFormFile fileUp, string Message)
        //{
        //    string uploadFolder = Path.Combine(_webHost.WebRootPath, "uploadPostFromUser");
        //    if (!Directory.Exists(uploadFolder))
        //    {
        //        Directory.CreateDirectory(uploadFolder);
        //    }
        //    if (fileUp == null || fileUp.Length == 0)
        //    {
        //        ModelState.AddModelError("", "???? ?? ??????? ??? ??? ????????");
        //        return View();
        //    }
        //    string fileName = fileUp.FileName;
        //    string fileSavePath = Path.Combine(uploadFolder, fileName);

        //    using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
        //    {
        //        await fileUp.CopyToAsync(stream);
        //    }
        //    ctx.Posts.Add(new Post
        //    {
        //        UserId = 1,


        //    });
        //    ctx.SaveChanges();

        //    int length = ctx.PostImages.Count();
        //    ctx.PostImages.Add(new PostImage
        //    {
        //        PostId = ctx.Posts.OrderByDescending(p => p.Id).FirstOrDefault().Id,
        //        Url = "/uploadPostFromUser/" + fileName
        //    });
        //    ctx.Coments.Add(new Coment
        //    {
        //        UserId = 1,
        //        PostId = ctx.Posts.OrderByDescending(p => p.Id).FirstOrDefault().Id,
        //        Message = Message

        //    });
        //    ctx.SaveChanges();

        //    return RedirectToAction("HomeBtn");
        //}
        public IActionResult HomeBtn()
        {
            var model = ctx.Users
                .Include(u=> u.Posts)
                    .ThenInclude(p=> p.ImgUrls)
                .Include(u=> u.Coments)
                .ToList();
            return View(model);
        }
        public IActionResult Profile()
        {
            var model = ctx.Users
                .Include(u => u.Posts)
                    .ThenInclude(p => p.ImgUrls)
                .Include(u => u.Coments)
                .ToList();
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var PostimagesId = ctx.PostImages.Where(m=> m.PostId == id);
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
        //[HttpPost]
        //public async Task<IActionResult> HomeBtn(IFormFile fileUp)
        //{
        //    //string uploadFolder = Path.Combine(_webHost.WebRootPath, "uploadPostFromUser");
        //    //if (!Directory.Exists(uploadFolder))
        //    //{
        //    //    Directory.CreateDirectory(uploadFolder);
        //    //}
        //    //string fileName = fileUp.FileName;
        //    //string fileSavePath = Path.Combine(uploadFolder, fileName);

            //    //using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
            //    //{
            //    //    await fileUp.CopyToAsync(stream);
            //    //}
            //    var model = ctx.Users
            //        .Include(u => u.Posts)
            //            .ThenInclude(p => p.ImgUrls)
            //        .Include(u => u.Coments)
            //        .ToList();
            //    return View(model);
            //}
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

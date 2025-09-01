using System.Diagnostics;
using _02_Exam_Social_Network.Data;
using _02_Exam_Social_Network.Models;


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _02_Exam_Social_Network.Controllers
{
    public class HomeController : Controller
    {

        private readonly SNetworkDbContext ctx;
        public HomeController(SNetworkDbContext ctx)
        {
           this.ctx = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult HomeBtn()
        {
            var model = ctx.Users
                .Include(u=> u.Posts)
                    .ThenInclude(p=> p.ImgUrls)
                .Include(u=> u.Coments)
                .ToList();
            return View(model);
        }

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

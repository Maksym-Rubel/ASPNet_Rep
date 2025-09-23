using DataAccess.Data;
using DataAccess.Data.Entities;
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
 
    public class HomeController : Controller
    {
        private string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier);
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

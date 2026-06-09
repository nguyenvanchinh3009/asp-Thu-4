<<<<<<< HEAD
using System.Diagnostics;
using System.Linq;
using CMS.Backend.Models;
using CMS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
=======
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMS.Data;
>>>>>>> bf8421308594fdc70a2f2729b121ae3dc4958834

namespace CMS.Backend.Controllers
{
    public class HomeController : Controller
    {
<<<<<<< HEAD
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        // Inject Logger + DbContext
        public HomeController(
            ILogger<HomeController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // L?y 3 bài vi?t m?i nh?t
            var latestPosts = _context.Posts
                .Include(p => p.Category)
                .OrderByDescending(p => p.CreatedDate)
                .Take(3)
                .ToList();

            return View(latestPosts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(
            Duration = 0,
            Location = ResponseCacheLocation.None,
            NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id
                            ?? HttpContext.TraceIdentifier
            });
=======
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context) => _context = context;

        public IActionResult Index()
        {
            var posts = _context.Posts.Include(p => p.Category)
                                      .OrderByDescending(p => p.CreatedDate)
                                      .Take(6).ToList();
            return View(posts);
>>>>>>> bf8421308594fdc70a2f2729b121ae3dc4958834
        }
    }
}
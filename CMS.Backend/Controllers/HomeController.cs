using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMS.Data;

namespace CMS.Backend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context) => _context = context;

        public IActionResult Index()
        {
            var posts = _context.Posts.Include(p => p.Category)
                                      .OrderByDescending(p => p.CreatedDate)
                                      .Take(6).ToList();
            return View(posts);
        }
    }
}
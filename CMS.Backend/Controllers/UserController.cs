using Microsoft.AspNetCore.Mvc;
using CMS.Data.Entities;

namespace CMS.Backend.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            var list = new List<User>
            {
                new User
                {
                    Id = 1,
                    Username = "admin",
                    FullName = "Nguyễn Văn Chính",
                    Role = "Administrator"
                },

                new User
                {
                    Id = 2,
                    Username = "editor",
                    FullName = "Nguyễn Thị thùy Trâm",
                    Role = "Editor"
                }
            };

            return View(list);
        }
    }
}
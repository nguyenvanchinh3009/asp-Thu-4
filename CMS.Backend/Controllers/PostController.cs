using Microsoft.AspNetCore.Mvc;
using CMS.Data.Entities;

namespace CMS.Backend.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            var list = new List<Post>
            {
                new Post
                {
                    Id = 1,
                    Title = "Lộ trình học ASP.NET",
                    Content = "Học từ C# -> ASP.NET MVC -> Entity Framework",
                    ImageUrl = "https://picsum.photos/300/200?1"
                },

                new Post
                {
                    Id = 2,
                    Title = "Cài đặt ReactJS",
                    Content = "Cài NodeJS, npm và tạo project React",
                    ImageUrl = "https://picsum.photos/300/200?2"
                }
            };

            return View(list);
        }
    }
}
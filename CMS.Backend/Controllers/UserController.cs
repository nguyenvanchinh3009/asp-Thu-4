<<<<<<< HEAD
﻿using CMS.Data;
using CMS.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.Backend.Controllers
{
    [Authorize(Roles = "Admin")]
=======
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMS.Data;
using CMS.Data.Entities;
using System.Linq;
using Microsoft.AspNetCore.Authorization; // <--- DÒNG NÀY LÀ CỨU TINH CỦA BẠN
namespace CMS.Backend.Controllers
{
>>>>>>> bf8421308594fdc70a2f2729b121ae3dc4958834
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

<<<<<<< HEAD
        // Inject DbContext
=======
>>>>>>> bf8421308594fdc70a2f2729b121ae3dc4958834
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

<<<<<<< HEAD
        // ================= INDEX =================

        // Danh sách người dùng
        public IActionResult Index()
        {
            var userList = _context.Users.ToList();

            return View(userList);
        }

        // ================= CREATE =================

        // GET: Hiển thị form thêm mới
=======
        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

>>>>>>> bf8421308594fdc70a2f2729b121ae3dc4958834
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

<<<<<<< HEAD
        // POST: Lưu user mới
        [HttpPost]
        public IActionResult Create(User model)
        {
            // Kiểm tra username đã tồn tại chưa
            var checkExist = _context.Users
                .Any(u => u.Username == model.Username);

            if (checkExist)
            {
                ModelState.AddModelError(
                    "Username",
                    "Tên đăng nhập đã tồn tại!"
                );

                return View(model);
            }

            // Lưu xuống database
            _context.Users.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // ================= EDIT =================

        // GET: Hiển thị form sửa
=======
        [HttpPost]
        public IActionResult Create(User model)
        {
            if (_context.Users.Any(u => u.Username == model.Username))
            {
                ModelState.AddModelError("Username", "Tên đăng nhập này đã có người dùng!");
                return View(model);
            }

            _context.Users.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

>>>>>>> bf8421308594fdc70a2f2729b121ae3dc4958834
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _context.Users.Find(id);
<<<<<<< HEAD

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Cập nhật dữ liệu
        [HttpPost]
        public IActionResult Edit(User model, string NewPassword)
        {
            // Lấy user cũ
            var existingUser = _context.Users
                .AsNoTracking()
                .FirstOrDefault(u => u.Id == model.Id);

            if (existingUser == null)
            {
                return NotFound();
            }

            // Nếu có nhập mật khẩu mới
=======
            if (user == null) return NotFound();
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User model, string NewPassword)
        {
            var existingUser = _context.Users.AsNoTracking().FirstOrDefault(u => u.Id == model.Id);
            if (existingUser == null) return NotFound();

>>>>>>> bf8421308594fdc70a2f2729b121ae3dc4958834
            if (!string.IsNullOrEmpty(NewPassword))
            {
                model.PasswordHash = NewPassword;
            }
            else
            {
<<<<<<< HEAD
                // Giữ mật khẩu cũ
=======
>>>>>>> bf8421308594fdc70a2f2729b121ae3dc4958834
                model.PasswordHash = existingUser.PasswordHash;
            }

            _context.Users.Update(model);
            _context.SaveChanges();
<<<<<<< HEAD

            return RedirectToAction("Index");
        }

        // ================= DELETE =================

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);

=======
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
>>>>>>> bf8421308594fdc70a2f2729b121ae3dc4958834
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> bf8421308594fdc70a2f2729b121ae3dc4958834

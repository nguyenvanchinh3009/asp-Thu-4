<<<<<<< HEAD
﻿using CMS.Data;
using CMS.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
=======
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMS.Data;
using CMS.Data.Entities;
>>>>>>> bf8421308594fdc70a2f2729b121ae3dc4958834
using System.Linq;

namespace CMS.Backend.Controllers
{
<<<<<<< HEAD
    [Authorize]
=======
>>>>>>> bf8421308594fdc70a2f2729b121ae3dc4958834
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

<<<<<<< HEAD
        // Inject DbContext
=======
>>>>>>> bf8421308594fdc70a2f2729b121ae3dc4958834
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

<<<<<<< HEAD
        // =========================
        // DANH SÁCH CATEGORY
        // =========================
        public IActionResult Index()
        {
            // Lấy dữ liệu thật từ SQL Server
            var list = _context.Categories.ToList();

            return View(list);
        }

        // =========================
        // GET: Category/Create
        // Hiển thị form nhập
        // =========================
=======
        // GET: Category
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        // 1. Hàm GET: Dùng để hiển thị giao diện Form cho nhập
>>>>>>> bf8421308594fdc70a2f2729b121ae3dc4958834
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

<<<<<<< HEAD
        // =========================
        // POST: Category/Create
        // Lưu dữ liệu vào SQL Server
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken] // Phải khớp với @Html.AntiForgeryToken() bên View
        public IActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model); // Trả về lại form nếu dữ liệu sai
        }

        // =========================
        // DELETE CATEGORY
        // =========================
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Tìm category theo id
            var category = _context.Categories
                .FirstOrDefault(c => c.Id == id);

            // Nếu không tồn tại
            if (category == null)
            {
                return NotFound();
            }

            // Xóa dữ liệu
            _context.Categories.Remove(category);

            // Lưu xuống SQL Server
            _context.SaveChanges();

            // Quay về danh sách
            return RedirectToAction("Index");
        }

        // =========================
        // GET EDIT
        // Hiển thị dữ liệu cũ lên Form
        // =========================
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Tìm category theo id
            var category = _context.Categories.Find(id);

            // Nếu không tồn tại
            if (category == null)
            {
                return NotFound();
            }

            // Đẩy dữ liệu sang View
            return View(category);
        }

        // =========================
        // POST EDIT
        // Cập nhật dữ liệu mới
        // =========================
        [HttpPost]
        public IActionResult Edit(Category model)
        {
            // Kiểm tra dữ liệu
            if (ModelState.IsValid)
            {
                // Update dữ liệu
                _context.Categories.Update(model);

                // Lưu xuống SQL Server
                _context.SaveChanges();

                // Quay về danh sách
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
=======
        // 2. Hàm POST: Dùng để đón dữ liệu từ Form gửi lên và lưu vào SQL
        [HttpPost]
        public IActionResult Create(Category model)
        {
            // BƯỚC 1: Thêm dữ liệu vào bộ nhớ tạm của Entity Framework
            _context.Categories.Add(model);

            // BƯỚC 2: Ra lệnh cho hệ thống ghi dữ liệu thật sự vào SQL Server
            _context.SaveChanges();

            // Sau khi lưu thành công, tự động quay về trang danh sách
            return RedirectToAction("Index");
        }

        // 1. Hàm GET: Tìm dữ liệu cũ và đổ lên Form
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Tìm danh mục trong Database theo Id
            var category = _context.Categories.Find(id);

            if (category == null) return NotFound();

            return View(category); // Gửi đối tượng tìm được sang giao diện Edit
        }

        // 2. Hàm POST: Nhận dữ liệu mới từ người dùng và lưu lại
        [HttpPost]
        public IActionResult Edit(Category model)
        {
            // Lệnh cập nhật đối tượng vào bộ nhớ tạm
            _context.Categories.Update(model);

            // Lưu thay đổi thực sự xuống SQL Server
            _context.SaveChanges();

            // Quay lại trang danh sách để xem kết quả
            return RedirectToAction("Index");
        }

        // Action nhận vào Id của danh mục cần xóa
        public IActionResult Delete(int id)
        {
            // Bước 1: Tìm đối tượng danh mục trong Database bằng Id
            var category = _context.Categories.Find(id);

            // Kiểm tra nếu tìm thấy thì mới xóa
            if (category != null)
            {
                // Bước 2: Lệnh xóa khỏi bộ nhớ tạm (Tracking)
                _context.Categories.Remove(category);

                // Bước 3: Chốt phiên làm việc, xóa thực sự trong SQL Server
                _context.SaveChanges();
            }

            // Sau khi xóa xong, quay lại trang danh sách để cập nhật giao diện
            return RedirectToAction("Index");
        }
    }
}
>>>>>>> bf8421308594fdc70a2f2729b121ae3dc4958834

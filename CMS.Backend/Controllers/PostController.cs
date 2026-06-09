<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMS.Data;
using CMS.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CMS.Backend.Controllers
{
    [Authorize] // Bắt buộc đăng nhập
=======
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMS.Data;
using CMS.Data.Entities;
using System;
using System.IO;
using System.Linq;

namespace CMS.Backend.Controllers
{
>>>>>>> bf8421308594fdc70a2f2729b121ae3dc4958834
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostController(ApplicationDbContext context)
        {
            _context = context;
        }

<<<<<<< HEAD
        // =========================
        // DANH SÁCH BÀI VIẾT
        // =========================
        public IActionResult Index()
        {
            var posts = _context.Posts
                .Include(p => p.Category)
                .OrderByDescending(p => p.CreatedDate)
                .ToList();

            return View(posts);
        }

        // =========================
        // CHI TIẾT
        // =========================
        public IActionResult Details(int id)
        {
            var post = _context.Posts
                .Include(p => p.Category)
                .FirstOrDefault(p => p.Id == id);
=======
        public IActionResult Index(int? id)
        {
            var posts = id == null
                ? _context.Posts.Include(p => p.Category).OrderByDescending(p => p.CreatedDate)
                : _context.Posts.Where(p => p.CategoryId == id).Include(p => p.Category).OrderByDescending(p => p.CreatedDate);

            return View(posts.ToList());
        }

        public IActionResult Details(int id)
        {
            var post = _context.Posts
                               .Include(p => p.Category)
                               .FirstOrDefault(p => p.Id == id);
>>>>>>> bf8421308594fdc70a2f2729b121ae3dc4958834

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

<<<<<<< HEAD
        // =========================
        // CREATE GET
        // =========================
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CategoryList =
                new SelectList(_context.Categories, "Id", "Name");

            return View();
        }

        // =========================
        // CREATE POST
        // =========================
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(Post model, IFormFile uploadImage)
        {
            // Upload ảnh
            if (uploadImage != null && uploadImage.Length > 0)
            {
                string folder = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "uploads"
                );

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                string fileName =
                    Guid.NewGuid().ToString()
                    + Path.GetExtension(uploadImage.FileName);

=======
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CategoryList = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Post model, IFormFile uploadImage)
        {
            if (uploadImage != null && uploadImage.Length > 0)
            {
                string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(uploadImage.FileName);
>>>>>>> bf8421308594fdc70a2f2729b121ae3dc4958834
                string filePath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    uploadImage.CopyTo(stream);
                }

                model.ImageUrl = "/uploads/" + fileName;
            }

<<<<<<< HEAD
            _context.Posts.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // =========================
        // DELETE
        // =========================
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var post = _context.Posts.Find(id);

=======
            if (model.CreatedDate == default)
            {
                model.CreatedDate = DateTime.Now;
            }

            _context.Posts.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var post = _context.Posts.Find(id);
            if (post == null) return NotFound();

            ViewBag.CategoryList = new SelectList(_context.Categories, "Id", "Name", post.CategoryId);
            return View(post);
        }

        [HttpPost]
        public IActionResult Edit(Post model, IFormFile uploadImage)
        {
            var oldPost = _context.Posts.AsNoTracking().FirstOrDefault(p => p.Id == model.Id);
            if (oldPost == null) return NotFound();

            if (uploadImage != null && uploadImage.Length > 0)
            {
                string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(uploadImage.FileName);
                string filePath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    uploadImage.CopyTo(stream);
                }

                model.ImageUrl = "/uploads/" + fileName;
            }
            else if (string.IsNullOrEmpty(model.ImageUrl))
            {
                model.ImageUrl = oldPost.ImageUrl;
            }

            if (model.CreatedDate == default)
            {
                model.CreatedDate = oldPost.CreatedDate;
            }

            _context.Posts.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var post = _context.Posts.Find(id);
>>>>>>> bf8421308594fdc70a2f2729b121ae3dc4958834
            if (post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
<<<<<<< HEAD

        // =========================
        // EDIT GET
        // =========================
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var post = _context.Posts.Find(id);

            if (post == null)
            {
                return NotFound();
            }

            ViewBag.CategoryList =
                new SelectList(
                    _context.Categories,
                    "Id",
                    "Name",
                    post.CategoryId
                );

            return View(post);
        }

        // =========================
        // EDIT POST
        // =========================
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(Post model, IFormFile uploadImage)
        {
            if (uploadImage != null && uploadImage.Length > 0)
            {
                string folder = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "uploads"
                );

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                string fileName =
                    Guid.NewGuid().ToString()
                    + Path.GetExtension(uploadImage.FileName);

                string filePath = Path.Combine(folder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    uploadImage.CopyTo(stream);
                }

                model.ImageUrl = "/uploads/" + fileName;
            }
            else
            {
                // giữ ảnh cũ
                var oldPost = _context.Posts
                    .AsNoTracking()
                    .FirstOrDefault(p => p.Id == model.Id);

                if (oldPost != null)
                {
                    model.ImageUrl = oldPost.ImageUrl;
                }
            }

            _context.Posts.Update(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
=======
    }
}
>>>>>>> bf8421308594fdc70a2f2729b121ae3dc4958834

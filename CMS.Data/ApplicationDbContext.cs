<<<<<<< HEAD
﻿using Microsoft.EntityFrameworkCore;
=======
using Microsoft.EntityFrameworkCore;
>>>>>>> bf8421308594fdc70a2f2729b121ae3dc4958834
using CMS.Data.Entities;

namespace CMS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

<<<<<<< HEAD
        // Khai báo các bảng dữ liệu
        public DbSet<Category> Categories { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<CategoryProduct> CategoriesProducts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
=======
        // Khởi tạo các DbSet với "= null!;" để trình biên dịch hiểu chúng sẽ được khởi tạo bởi EF Core
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        // Lưu ý: Nếu bạn có thêm các bảng như Product, Order, v.v. từ sơ đồ 
>>>>>>> bf8421308594fdc70a2f2729b121ae3dc4958834
    }
}
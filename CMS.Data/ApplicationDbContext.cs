using Microsoft.EntityFrameworkCore;
using CMS.Data.Entities;

namespace CMS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Khởi tạo các DbSet với "= null!;" để trình biên dịch hiểu chúng sẽ được khởi tạo bởi EF Core
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        // Lưu ý: Nếu bạn có thêm các bảng như Product, Order, v.v. từ sơ đồ 
    }
}
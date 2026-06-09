//Sinh viên : Nguyễn Văn Chính      
//MSSV:2123110543   
//Lớp:CCQ2311F
//Ngày tạo: 15/05/2026
//Mô tả: Quản lí bài viết
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Entities
{


    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty; // Nên khởi tạo rỗng để tránh lỗi
        public string? Content { get; set; } // Thêm dấu ? ở đây
        public string? ImageUrl { get; set; } // Nên thêm ? cho cả ảnh
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
    }
}


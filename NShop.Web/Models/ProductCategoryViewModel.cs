using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NShop.Web.Models
{
    public class ProductCategoryViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Tên danh mục không được bỏ trống")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Tiêu đề SEO không được bỏ trống")]
        public string Alias { get; set; }

        [MaxLength(500,ErrorMessage ="Mô tả không quá 500 ký tự")]
        public string Description { get; set; }

        public int? ParentId { get; set; }

        public string Image { get; set; }

        public int? DisplayOrder { get; set; }

        public bool? HomeFlag { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public string MetaKeyword { get; set; }

        public string MetaDescription { get; set; }

        [Required]
        public bool Status { get; set; }

        public virtual ICollection<ProductViewModel> Products { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _23dh111482_My_Store.Models
{
    //trường nào cần validation thì làm không thì khỏi
    public class UserMetadata
    {
        [Required]
        [Display(Name = "Tên đăng nhập")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
      
    }

    public class ProductMetadata
    {
        [Required(ErrorMessage = "Nhập tên sản phẩm")]
        [Display(Name = "Tên sản phẩm")]
        [MinLength(5, ErrorMessage = "Độ dài tối thiểu là 5 ký tự")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Nhập hình ảnh sản phẩm")]
        [Display(Name = "HÌnh ảnh sản phẩm")]
        [StringLength(5000, MinimumLength = 5, ErrorMessage = "Độ dài tối thiểu là 5 ký tự và độ dài tối đa là 5000 ký tự")]
        public string ProductImage { get; set; }

        [Required(ErrorMessage = "Nhập mô tả sản phẩm")]
        [Display(Name = "Mô tả sản phẩm")]
        [StringLength(5000, MinimumLength = 5, ErrorMessage = "Độ dài tối thiểu là 5 ký tự và độ dài tối đa là 5000 ký tự")]
        [DataType(DataType.MultilineText)]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "Nhập giá sản phẩm")]
        [Display(Name = "Giá sản phẩm")]
        public decimal ProductPrice { get; set; }
    }

    public class CustomerMetadata
    {
        [Required]
        [Display(Name = "Tên khách hàng")]
        public string CustomerName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Số điện thoại khách hàng")]
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public string Username { get; set; }
    }
}
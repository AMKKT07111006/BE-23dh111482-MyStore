using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; 

namespace _23dh111482_My_Store.Models
{
    //để validate dữ liệu ta viết trên 2 lớp:
    //Metadata và PartialModelClasses
   
    [MetadataType(typeof(UserMetadata))]
    public class PartialModelClasses
    {
        public partial class User
        {
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Xác nhận mật khẩu")]
            [Compare("Password", ErrorMessage = "Mật khẩu và xác nhận mật khẩu không hợp lệ")]
            public string ConfirmPassword { get; set; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _23dh111482_My_Store.Models.ViewModel
{
    public class CartItem //lưu thông tin mỗi mặt hàng có trong giỏ
    {
        public int ProductID { get; set; }
        public string ProductName {  get; set; }

        public string ProductImage { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        //Tổng giá mỗi sản phẩm
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
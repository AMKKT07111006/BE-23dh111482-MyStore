using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using PagedList.Mvc;

namespace _23dh111482_My_Store.Models.ViewModel
{
    public class HomeProductVM
    {
        //tiêu chí để search theo tên, mô tả sản phẩm
        //hoặc loại sản phẩm
        public string SearchTerm { get; set; }

        //các thuộc tính hỗ trợ phân trang 
        public int PageNumber { get; set; } //trang hiện tại
        public int PageSize { get; set; } = 10; //số sp mỗi trang

        //ds sp nổi bật
        public PagedList.IPagedList<Product> FeaturedProducts { get; set; }

        //ds sp đã phân trang
        public PagedList.IPagedList<Product> NewProducts { get; set; }
    }
}
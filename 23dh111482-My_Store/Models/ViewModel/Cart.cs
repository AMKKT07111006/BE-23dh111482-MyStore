﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _23dh111482_My_Store.Models.ViewModel
{
    public class Cart //quản lý ds sp trong giỏ hàng
    {
        private List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items => items;

        //Thêm sản phẩm vào giỏ
        public void AddItem(int productId, string productImage, string productName, decimal unitPrice, int quantity, string category)
        {
            var existingItem = items.FirstOrDefault(i => i.ProductID == productId);
            if (existingItem == null)
            {
                items.Add(new CartItem
                {
                    ProductID = productId,
                    ProductImage = productImage,
                    ProductName = productName,
                    UnitPrice = unitPrice,
                    Quantity = quantity
                });
            }
            else
            {
                existingItem.Quantity += quantity;
            }
        }

        //Xóa sản phẩm khỏi giỏ 
        public void RemoveItem(int productId)
        {
            items.RemoveAll(i => i.ProductID == productId);
        }

        //Tính tổng giá trị giỏ hàng
        public decimal TotalValue()
        {
            return items.Sum(i => i.TotalPrice);
        }

        //Làm trống giỏ hàng
        public void Clear()
        {
            items.Clear();
        }

        //Cập nhật số lượng sản phảm đã chọn
        public void UpdateQuantity(int productId, int quantity)
        {
            var item = items.FirstOrDefault(i => i.ProductID == productId);
            if(item != null)
            {
                item.Quantity = quantity;
            }    
        }

}
}
﻿
namespace Mock.Core.Models
{
    public class WishList
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int? TotalQuantity { get; set; }
        public virtual List<WishListDetails> WishListDetails { get; set; } = new List<WishListDetails>();
    }
}

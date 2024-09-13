﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Core.Models
{
    public class WishList
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int TotalQuantity { get; set; }
        public virtual List<WishListDetails> WishListDetails { get; set; }
    }
}

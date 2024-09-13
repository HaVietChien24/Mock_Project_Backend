﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Core.Models
{
    public class BorrowingDetails
    {
        public int BorrowingId { get; set; }
        public Borrowing Borrowing { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
        public DateTime? ActualReturnDate { get; set; } //ngày trả thực tế
        public int NumberReturnedBook { get; set; } = 0;
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Bussiness.DTO
{
    public class UpdateBookRequestDTO
    {
        public int Id { get; set; } // Thêm trường Id
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int PublishedYear { get; set; }
        public string ISBN { get; set; }
        public int Amount { get; set; }
        public string? ImageUrl { get; set; }
        public List<string> Genres { get; set; } = new List<string>();
    }
}

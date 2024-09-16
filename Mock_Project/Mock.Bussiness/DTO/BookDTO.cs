using Mock.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Bussiness.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int PublishedYear { get; set; }
        public string ISBN { get; set; }

        public virtual List<string>? GenreNames { get; set; } = new List<string>();

        public int Amount { get; set; }
    }
}

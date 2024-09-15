using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Bussiness
{
    public  class PageList<T>
    {
        public List<T> Items { get; }
        public int PageNumber { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }
        public int PageSize { get; set; }

        public PageList(List<T> items, int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            Items = items;
            PageSize = pageSize;
        }

        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;

        public static PageList<T> CreatePage(IList<T> source, int pageNumber, int pageSize)
        {
            var count =  source.Count();
            var items =  source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PageList<T>(items, count, pageNumber, pageSize);
        }
    }
}

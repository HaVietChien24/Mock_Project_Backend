using Microsoft.EntityFrameworkCore;
using Mock.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Core.Data
{
    public class LivebraryContext : DbContext
    {
        public LivebraryContext() { }
        public LivebraryContext(DbContextOptions<LivebraryContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }
        public DbSet<BorrowingDetails> BorrowingDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<WishListDetails> WishListDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookGenre>().HasKey(x => new { x.BookId, x.GenreId });

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Mock.Core.Models;

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
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=LAPTOP-9LBBS3VQ;database=Mock_Project;uid=sa;password=1234;Integrated security=true;TrustServerCertificate=true");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookGenre>().HasKey(bg => new { bg.BookId, bg.GenreId });

            modelBuilder.Entity<BookGenre>()
                .HasOne(b => b.Book)
                .WithMany(bg => bg.BookGenres)
                .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<BookGenre>()
                .HasOne(b => b.Genre)
                .WithMany(bg => bg.BookGenres)
                .HasForeignKey(b => b.GenreId);

            modelBuilder.Entity<BorrowingDetails>()
                .HasOne(b => b.Borrowing)
                .WithMany(a => a.BorrowingDetails)
                .HasForeignKey(b => b.BorrowingId);

            modelBuilder.Entity<WishListDetails>()
                .HasOne(b => b.WishList)
                .WithMany(a => a.WishListDetails)
                .HasForeignKey(b => b.WishListId);

            modelBuilder.Entity<Borrowing>()
                .HasOne(b => b.User)
                .WithMany(a => a.Borrowings)
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<WishList>()
                .HasOne(b => b.User)
                .WithMany(a => a.WishLists)
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<User>().HasData(
                SeedData.SeedUser()
            );
           
        }
    }
}

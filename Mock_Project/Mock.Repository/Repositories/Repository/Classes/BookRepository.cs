using Microsoft.EntityFrameworkCore;
using Mock.Core.Data;
using Mock.Core.Models;
using Mock.Repository.Repositories.Generic;
using Mock.Repository.Repositories.Repository.Interfaces;

namespace Mock.Repository.Repositories.Repository.Classes
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly LivebraryContext _context;
        private readonly DbSet<Book> _entity;

        public BookRepository(LivebraryContext context) : base(context)
        {
            _context = context;
            _entity = _context.Set<Book>();
        }

        public List<Book> GetByGenreId(int id)
        {
            return _entity.Where(x => x.BookGenres.Any(bg => bg.GenreId == id))
                .Include(x => x.BookGenres).ThenInclude(bg => bg.Genre).ToList();
        }

        public List<Book> SearchByTitleOrAuthor(string search)
        {
            return _entity.Where(x =>
                (x.Title.ToLower().Contains(search.ToLower()))
                || (x.Author.ToLower().Contains(search.ToLower())))
                .Include(x => x.BookGenres)
                .ThenInclude(bg => bg.Genre)
                .ToList();
        }

        public async Task AddBook(Book book, List<string> genreNames)
        {
            if (book == null || genreNames == null || !genreNames.Any())
            {
                throw new ArgumentException("Book or genres cannot be null or empty");
            }

            // Thêm các thể loại cho sách
            foreach (var genreName in genreNames)
            {
                // Kiểm tra xem thể loại đã tồn tại chưa
                var existingGenre = await _context.Genres.FirstOrDefaultAsync(g => g.Name == genreName);

                // Nếu thể loại chưa tồn tại, thêm thể loại mới
                if (existingGenre == null)
                {
                    existingGenre = new Genre { Name = genreName };
                    _context.Genres.Add(existingGenre);
                }

                // Thêm vào bảng trung gian BookGenre
                book.BookGenres.Add(new BookGenre
                {
                    Book = book,
                    Genre = existingGenre
                });
            }

            // Thêm sách vào cơ sở dữ liệu
            await _entity.AddAsync(book);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateBook(Book book, List<string> genreNames)
        {
            if (book == null || genreNames == null)
            {
                throw new ArgumentException("Book or genres cannot be null");
            }

            // Tìm sách trong cơ sở dữ liệu
            var existingBook = await _context.Books
                .Include(b => b.BookGenres)
                .ThenInclude(bg => bg.Genre)
                .FirstOrDefaultAsync(b => b.Id == book.Id);

            if (existingBook == null)
            {
                throw new ArgumentException("Book not found");
            }

            // Cập nhật thông tin sách
            existingBook.Title = book.Title;
            existingBook.Description = book.Description;
            existingBook.Author = book.Author;
            existingBook.Publisher = book.Publisher;
            existingBook.PublishedYear = book.PublishedYear;
            existingBook.ISBN = book.ISBN;
            existingBook.Amount = book.Amount;
            existingBook.ImageUrl = book.ImageUrl;

            // Xoá các thể loại cũ
            _context.BookGenres.RemoveRange(existingBook.BookGenres);

            // Thêm các thể loại mới
            foreach (var genreName in genreNames)
            {
                // Kiểm tra xem thể loại đã tồn tại chưa
                var existingGenre = await _context.Genres.FirstOrDefaultAsync(g => g.Name == genreName);

                // Nếu thể loại chưa tồn tại, thêm thể loại mới
                if (existingGenre == null)
                {
                    existingGenre = new Genre { Name = genreName };
                    _context.Genres.Add(existingGenre);
                }

                // Thêm vào bảng trung gian BookGenre
                existingBook.BookGenres.Add(new BookGenre
                {
                    Book = existingBook,
                    Genre = existingGenre
                });
            }

            // Cập nhật sách trong cơ sở dữ liệu
            _context.Books.Update(existingBook);
            await _context.SaveChangesAsync();
        }
    }
}

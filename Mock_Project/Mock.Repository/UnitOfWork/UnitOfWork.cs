using Microsoft.Extensions.Configuration;
using Mock.Core.Data;
using Mock.Repository.Repositories.Generic;
using Mock.Repository.Repositories.Repository.Classes;
using Mock.Repository.Repositories.Repository.Interfaces;

namespace Mock.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LivebraryContext _context;
        private readonly IConfiguration _configuration;

        private IBookRepository _bookRepository;
        private IBorrowingRepository _borrowingRepository;
        private IBorrowDetailRepository _borrowDetailRepository;
        private IGenreRepository _genreRepository;
        private IUserRepository _userRepository;
        private IWishListDetailRepository _wishListDetailRepository;
        private IWishListRepository _wishListRepository;
        private IBookGenreRepository _bookGenreRepository;
        

        public UnitOfWork(LivebraryContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public IBookRepository BookRepository => _bookRepository ?? new BookRepository(_context);

        public IGenreRepository GenreRepository => _genreRepository ?? new GenreRepository(_context);

        public IBorrowingRepository BorrowingRepository => _borrowingRepository ?? new BorrowingRepository(_context);

        public IBorrowDetailRepository BorrowDetailRepository => _borrowDetailRepository ?? new BorrowDetailRepository(_context);

        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context, _configuration);

        public IWishListRepository WishListRepository => _wishListRepository ?? new WishListRepository(_context);

        public IWishListDetailRepository WishListDetailRepository => _wishListDetailRepository 
            ?? new WishListDetailRepository(_context);

        public IBookGenreRepository BookGenreRepository => _bookGenreRepository ?? new BookGenreRepository(_context);

        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}

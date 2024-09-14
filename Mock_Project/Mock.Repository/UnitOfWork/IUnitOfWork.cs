using Mock.Repository.Repositories.Generic;
using Mock.Repository.Repositories.Repository.Interfaces;

namespace Mock.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }
        IGenreRepository GenreRepository { get; }
        IBorrowingRepository BorrowingRepository { get; }
        IBorrowDetailRepository BorrowDetailRepository { get; }
        IUserRepository UserRepository { get; }
        IWishListRepository WishListRepository { get; }
        IWishListDetailRepository WishListDetailRepository { get; }
        IBookGenreRepository BookGenreRepository { get; }

        int SaveChanges();
        IGenericRepository<T> GenericRepository<T>() where T : class;
    }
}

using Microsoft.EntityFrameworkCore;
using Mock.Core.Data;
using Mock.Core.Models;
using Mock.Repository.Repositories.Generic;
using Mock.Repository.Repositories.Repository.Interfaces;

namespace Mock.Repository.Repositories.Repository.Classes
{
    public class WishListRepository : GenericRepository<WishList>, IWishListRepository
    {
        private readonly LivebraryContext _context;
        private readonly DbSet<WishList> _entity;
        public WishListRepository(LivebraryContext context) : base(context)
        {
            _context = context;
            _entity = _context.Set<WishList>();
        }

        public WishList GetByUserId(int id)
        {
            return _entity.Include(x => x.WishListDetails).ThenInclude(wld=>wld.Book).FirstOrDefault(x => x.UserId == id);
        }
    }
}

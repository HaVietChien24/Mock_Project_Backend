using Mock.Core.Data;
using Mock.Core.Models;
using Mock.Repository.Repositories.Generic;
using Mock.Repository.Repositories.Repository.Interfaces;

namespace Mock.Repository.Repositories.Repository.Classes
{
    public class WishListDetailRepository : GenericRepository<WishListDetails>, IWishListDetailRepository
    {
        private readonly LivebraryContext _context;
        public WishListDetailRepository(LivebraryContext context) : base(context)
        {
            _context = context;
        }
    }
}

using Mock.Core.Models;

namespace Mock.Bussiness.DTO
{
    public class WishListDetailsDTO
    {
        public int Id { get; set; }
        public int WishListId { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string ImageUrl { get; set; }
        public int? Quantity { get; set; }
    }
}

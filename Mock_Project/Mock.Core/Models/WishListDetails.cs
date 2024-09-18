
namespace Mock.Core.Models
{
    public class WishListDetails
    {
        public int Id { get; set; }
        public int WishListId { get; set; }
        public virtual WishList WishList { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public int? Quantity { get; set; }
    }
}

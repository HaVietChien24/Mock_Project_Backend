namespace Mock.Bussiness.DTO
{
    public class WishlistDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? TotalQuantity { get; set; }
        public virtual List<WishListDetailsDTO> WishListDetails { get; set; } = new List<WishListDetailsDTO>();
    }
}

namespace Mock.Bussiness.DTO
{
    public class RequestDetailsDTO
    {
        public int Id { get; set; }
        public int BorrowingId { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string ImageUrl { get; set; }
        public int? Quantity { get; set; }
    }
}

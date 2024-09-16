namespace Mock.Bussiness.DTO
{
    public class AuthResultDTO
    {
        public AuthResultDTO(string token, string message)
        {
            Token = token;
            Message = message;
        }

        public string Token { get; set; }
        public string Message { get; set; }
    }
}

namespace Mock.Bussiness.DTO
{
    public class AuthResultDTO
    {
        public AuthResultDTO(string token)
        {
            Token = token;
        }

        public string Token { get; set; }
    }
}

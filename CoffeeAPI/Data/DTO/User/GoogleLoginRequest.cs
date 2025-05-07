namespace Data.DTO.User
{
    public class GoogleLoginRequest
    {
        public string IdToken { get; set; } // Thực ra là access_token
        public string Email { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
    }

}

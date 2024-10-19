namespace Fiap.Web.SmartWasteManagement.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; // Em produção, nunca armazene senhas em texto claro.
        public string? Role { get; set; }
    }
}
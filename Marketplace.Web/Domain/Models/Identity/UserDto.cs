namespace Marketplace.Web.Domain.Models.Identity
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Image { get; set; }
    }
}
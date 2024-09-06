using MovieApp.Models.Entities;

namespace MovieApp.Models.Dto
{
    public class RegisterUserDto
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}

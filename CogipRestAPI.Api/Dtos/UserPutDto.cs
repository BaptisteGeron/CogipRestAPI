using System.ComponentModel.DataAnnotations;

namespace cogip.Models
{
    public class UserPutDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string UserType { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty ;
    }
}

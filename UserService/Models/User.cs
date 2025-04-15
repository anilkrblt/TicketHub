using System.ComponentModel.DataAnnotations;

namespace UserService.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string? Phone { get; set; }

        [Required]
        public string Password { get; set; } = string.Empty;

        public DateTime Created_At { get; set; } = DateTime.UtcNow;
    }
}
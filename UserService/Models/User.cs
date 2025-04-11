using System.ComponentModel.DataAnnotations;

namespace UserService.Models
{
    public class User
    {
        [Key]
        public int Id{get;set;}
        public string? Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public DateTime Created_At { get; set; } = DateTime.UtcNow;

    }
}
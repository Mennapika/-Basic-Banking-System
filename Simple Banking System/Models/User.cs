using System.ComponentModel.DataAnnotations;

namespace Simple_Banking_System.Models
{
    public class User
    {   [Key]
        public int Id { get; set; } 
        [Required]
        public string Name { get; set; }
        public float Balance { get; set; }
        [Display(Name ="Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "E-Mail")]
        public string Email { get; set; }
    }
}

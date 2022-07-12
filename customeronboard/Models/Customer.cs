using System.ComponentModel.DataAnnotations;

namespace customeronboard.Models
{
    public class Customer
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Ensure the First Letter is uppercase e.g Lagos")]
        public string Residence { get; set; }
        [Required(ErrorMessage = "Ensure the LGA is typed in Pascal Case e.g. Aba North ")]
        public string LGA { get; set; }
    }
}

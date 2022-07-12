using System.ComponentModel.DataAnnotations;

namespace customeronboard.Dtos
{
    public class CustomerCreateDto
    {
        [Required]
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
        [Required]
        public string Residence { get; set; }
        [Required]
        public string LGA { get; set; }
    }
}

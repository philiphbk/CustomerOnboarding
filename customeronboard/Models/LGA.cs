using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace customeronboard.Models
{
    public class LGA
    {
        [Key]
        public int  Id { get; set; }
        public int Lga_Id { get; set; }
        public string LGA_Name { get; set; }

       [ForeignKey("State")]
        public int State_Id { get; set; }
    }
}

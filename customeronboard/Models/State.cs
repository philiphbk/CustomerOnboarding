using System.ComponentModel.DataAnnotations;

namespace customeronboard.Models
{
    public class State
    {
        [Key]
        public int State_Id { get; set; }
        public string State_Name { get; set; }

    }
}

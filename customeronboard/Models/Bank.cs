using System;
using System.Collections.Generic;

namespace customeronboard.Models
{
    public class Bank
    {

        public List<String> result { get; set; }
        public string errorMessage { get; set; }
        public string[] errorMessages { get; set; }
        public bool hasError { get; set; }
        public DateTime timeGenerated { get; set; } = DateTime.Now;
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Models
{
    public class Car
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Range(1950, 2020)]
        public int Year { get; set; }

        [Required]
        public int VIN { get; set; }

        public string Colour { get; set; }

        public int DealershipID { get; set; }
    }
}

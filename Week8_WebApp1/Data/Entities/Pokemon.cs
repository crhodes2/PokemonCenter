using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Week8_WebApp1.Models;
using Week8_WebApp1.Data.Entities;
using System.Collections.Generic;
using System.Collections;

namespace Week8_WebApp1.Data.Entities
{
    public class Pokemon
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime NextCheckup { get; set; }

        public string VetName { get; set; }
		
		public ICollection<Vitamins> Vitamins {get; set;}

        [ForeignKey("User")]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace Week8_WebApp1.Models.View
{
    public class PokemonViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Pokemon's Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Pokemon's Age")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Next Checkup")]
        public DateTime NextCheckup { get; set; }

        [Required]
        [Display(Name = "Vet Name")]
        public string VetName { get; set; }

        public bool CheckupAlert { get; set; }

        //public string UserId { get; set; }
    }
}
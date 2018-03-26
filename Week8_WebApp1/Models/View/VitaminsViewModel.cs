using System;
using System.ComponentModel.DataAnnotations;

namespace Week8_WebApp1.Models.View
{
    public class VitaminsViewModel
    {
        [Key]
        public int VitId { get; set; }

        [Required]
        [Display(Name = "Vitamin's Name")]
        public string VitaminName { get; set; }

        [Required]
        [Display(Name = "Serving Size")]
        public int ServingSize { get; set; }

        [Display(Name = "About Vitamin")]
        public string AboutVitamin { get; set; }

        [Display(Name = "Refill Date")]
        public DateTime RefillDate { get; set; }

        public int PokemonId { get; set; }
    }
}
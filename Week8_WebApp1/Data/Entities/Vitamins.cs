using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Week8_WebApp1.Models;
using Week8_WebApp1.Data.Entities;

namespace Week8_WebApp1.Data.Entities
{
    public class Vitamins
    {
        [Key]
        public int VitId { get; set; }
        public string VitaminName { get; set; }
        public int ServingSize { get; set; }
        public string AboutVitamin { get; set; }
        public DateTime RefillDate { get; set; }
        public int PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }
    }
}
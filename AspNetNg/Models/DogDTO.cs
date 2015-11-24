using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetNg.Models
{
    public class DogDTO
    {
        [Key]
        public int DogId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Breed { get; set; }
        public byte[] FileAboutDog { get; set; }
    }
}
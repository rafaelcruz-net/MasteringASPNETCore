using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Underwater.Models
{
    public class Fish
    {
       
        public int FishId { get; set; }
        public string Name { get; set; }
        public string ScientificName { get; set; }
        public string CommonName { get; set; }
        public IFormFile PhotoAvatar { get; set; }
        public string ImageName { get; set; }
        public byte[] PhotoFile { get; set; }
        public string ImageMimeType { get; set; }
        public string ImageURL { get; set; }
        public int AquariumId { get; set; }
        public virtual Aquarium Aquarium { get; set; }
    }
}

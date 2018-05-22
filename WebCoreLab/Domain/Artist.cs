using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreLab.Models;

namespace WebCoreLab.Domain
{
    public class Artist
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int YearOfBirth { get; set; }
        public string Description { get; set; }
        public virtual string ImageLink { get; set; }

        public ICollection<LineUp> LineUps { get; set; }
        public ICollection<Subscribtion> Subcribers { get; set; }
    }
}

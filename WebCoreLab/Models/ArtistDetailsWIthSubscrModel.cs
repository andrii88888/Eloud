using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreLab.Domain;

namespace WebCoreLab.Models
{
    public class ArtistDetailsWithSubscr
    {
        public Artist Artist { get; set; }
        public Subscribtion Subscribtion { get; set; }

        public ArtistDetailsWithSubscr() { }
        public ArtistDetailsWithSubscr(Artist a, Subscribtion s)
        {
            this.Artist = a;
            this.Subscribtion = s;
        }
    }
}
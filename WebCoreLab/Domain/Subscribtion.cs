using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreLab.Domain
{
    public class Subscribtion
    {
        public int SubsribtionID { get; set; }
        public long UserID { get; set; }
        public int ArtistID { get; set; }

        public Artist Artist { get; set; }
    }
}

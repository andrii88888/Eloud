using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreLab.Domain
{
    public class LineUp
    {
        public int LineUpID { get; set; }
        public long FestivalID { get; set; }
        public int ArtistID { get; set; }

        public Festival Festival { get; set; }
        public Artist Artist { get; set; }
    }
}

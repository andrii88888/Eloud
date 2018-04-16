using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreLab.Domain
{
    public class Festival
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Country { get; set; }
        public virtual string City { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual string Description { get; set; }
        public virtual string ImageLink { get; set; }
        public ICollection<LineUp> LineUps { get; set; }
    }
}

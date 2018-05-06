using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreLab.Models;

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
       // public ICollection<Subscribtion> Subcribers { get; set; }

        public Festival() { }

        public Festival(/*long _id,*/ string _Name, string _Country, string _City, DateTime _Start, DateTime _End,
            string _Descr, string _ImagLink)
        {
            //Id = _id;
            Name = _Name;
            Country = _Country;
            City = _City;
            StartDate = _Start;
            EndDate = _End;
            Description = _Descr;
            ImageLink = _ImagLink;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Festival;
            return this.City == other.City && this.Name== other.Name && this.Country == other.Country 
                && this.StartDate == other.StartDate && this.EndDate == other.EndDate;
        }
    }
}

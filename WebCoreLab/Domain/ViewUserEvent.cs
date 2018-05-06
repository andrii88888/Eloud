using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreLab.Domain
{
    public class ViewUserEvent
    {
        public ViewUserEvent(string name, int? id, DateTime datetime)
        {
            this.UserId = name;
            this.FestivalId = (long)id;
            this.datetime = datetime;
        }

        public ViewUserEvent() { }

        public long Id { get; set; }
        public String UserId { get; set; }
        public long FestivalId { get; set; }
        public DateTime datetime { get; set; }
    }
}

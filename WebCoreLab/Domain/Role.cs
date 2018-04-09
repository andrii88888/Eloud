using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoreLab.Domain
{
    public class Role
    {
        public virtual long Id { get; set; }
        public virtual string Code { get; set; }
        public virtual string Name { get; set; }
        
        [JsonIgnore]
        public virtual List<User> Users { get; set; }

        public Role()
        {
            Users = new List<User>();
        }
    }
}

﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreLab.Models;

namespace WebCoreLab.Domain
{
    public class Subscribtion
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public int ArtistID { get; set; }


        public Subscribtion() { }
        public Subscribtion (string user, int artistid)
        {
            UserEmail = user;
            ArtistID = artistid;
        }
        
    }
}

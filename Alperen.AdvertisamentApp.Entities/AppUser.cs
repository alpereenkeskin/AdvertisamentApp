﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alperen.AdvertisamentApp.Entities
{
    public class AppUser : BaseEntity
    {
        public string FirtsName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public List<AppUserRole> AppUserRoles { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public List<AdvertisamentUser> AdvertisamentUsers { get; set; }
    }
}

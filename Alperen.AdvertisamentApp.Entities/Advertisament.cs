using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alperen.AdvertisamentApp.Entities
{
    public class Advertisament : BaseEntity
    {
        public string Title { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public List<AppUser> AppUsers { get; set; }
        public List<AdvertisamentUser> AdvertisamentUsers { get; set; }

    }
}

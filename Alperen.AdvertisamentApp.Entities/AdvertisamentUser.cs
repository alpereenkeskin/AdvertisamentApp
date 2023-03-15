using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alperen.AdvertisamentApp.Entities
{
    public class AdvertisamentUser : BaseEntity
    {
        public int AdvertisamentId { get; set; }
        public Advertisament Advertisament { get; set; }
        public int UserId { get; set; }
        public AppUser AppUser { get; set; }
        public int AdvertisamentUserStatusId { get; set; }
        public AdvertisamentUserStatus AdvertisamentUserStatus { get; set; }
        public int MilitaryStatusId { get; set; }
        public MilitaryStatus MilitaryStatus { get; set; }
        public DateTime? EndDate { get; set; }
        public int WorkExperiance { get; set; }
        public string CvPath { get; set; }





    }
}

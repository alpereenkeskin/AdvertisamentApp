using Alperen.AdvertisamentApp.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alperen.AdvertisamentApp.Dtos
{
    public class AdvertisamentUserListDto : IDto
    {
        public int Id { get; set; }
        public int AdvertisamentId { get; set; }
        public AdvertisamentListDto Advertisament { get; set; }
        public int UserId { get; set; }
        public AppUserListDto AppUser { get; set; }
        public int AdvertisamentUserStatusId { get; set; }
        public AdvertisamentUserStatusListDto AdvertisamentUserStatus { get; set; }
        public int MilitaryStatusId { get; set; }
        public MilitaryStatusListDto MilitaryStatus { get; set; }
        public DateTime? EndDate { get; set; }
        public int WorkExperiance { get; set; }
        public string CvPath { get; set; }

    }
}

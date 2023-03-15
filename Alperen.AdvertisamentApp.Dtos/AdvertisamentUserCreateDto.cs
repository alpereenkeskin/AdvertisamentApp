using Alperen.AdvertisamentApp.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alperen.AdvertisamentApp.Dtos
{
    public class AdvertisamentUserCreateDto:IDto
    {
        public int AdvertisamentId { get; set; }
        public int UserId { get; set; }
        public int AdvertisamentUserStatusId { get; set; }
        public int MilitaryStatusId { get; set; }
        public DateTime? EndDate { get; set; }
        public int WorkExperiance { get; set; }
        public string CvPath { get; set; }
    }
}

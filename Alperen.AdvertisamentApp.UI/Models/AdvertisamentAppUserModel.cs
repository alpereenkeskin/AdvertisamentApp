using Alperen.AdvertisamentApp.Common.Enums;
using Microsoft.AspNetCore.Http;
using System;

namespace Alperen.AdvertisamentApp.UI.Models
{
    public class AdvertisamentAppUserModel
    {
        public int AdvertisamentId { get; set; }
        public int UserId { get; set; }
        public int AdvertisamentUserStatusId { get; set; } = (int)AdvertisamentAppUserStatusType.Basvurdu;
        public int MilitaryStatusId { get; set; }
        public DateTime? EndDate { get; set; }
        public int WorkExperiance { get; set; }
        public IFormFile CvFile { get; set; }

    }
}

using Alperen.AdvertisamentApp.Dtos.Interfaces;
using System.Collections.Generic;

namespace Alperen.AdvertisamentApp.Dtos
{
    public class AdvertisamentUserStatusListDto:IDto
    {
        public string Definition { get; set; }
        public List<AdvertisamentUserListDto> AdvertisamentUsers { get; set; }
    }
}

using System.Collections.Generic;

namespace Alperen.AdvertisamentApp.Entities
{
    public class AdvertisamentUserStatus : BaseEntity
    {
        public string Definition { get; set; }
        public List<AdvertisamentUser> AdvertisamentUsers { get; set; }
    }
}

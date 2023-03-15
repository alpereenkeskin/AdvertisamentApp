using Alperen.AdvertisamentApp.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alperen.AdvertisamentApp.Dtos
{
    public class AdvertisamentListDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public List<AdvertisamentUserListDto> AdvertisamentUsers { get; set; }

    }
}

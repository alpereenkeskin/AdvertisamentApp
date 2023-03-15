using Alperen.AdvertisamentApp.Business.Interfaces;
using Alperen.AdvertisamentApp.Business.Services;
using Alperen.AdvertisamentApp.UI.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Alperen.AdvertisamentApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProvidedServiceService _service;
        private readonly IAdvertisamentService _advertisingService;
        public HomeController(IProvidedServiceService service, IAdvertisamentService advertisingService)
        {
            _service = service;
            _advertisingService = advertisingService;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _service.GetListAsync();
            return this.ResponseView(response);
        }
        public async Task<IActionResult> HumanResorce()
        {
            var values = await _advertisingService.GetActivesAsync();
            return this.ResponseView(values);
        }
    }

}

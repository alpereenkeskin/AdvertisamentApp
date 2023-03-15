using Alperen.AdvertisamentApp.Business.Interfaces;
using Alperen.AdvertisamentApp.Common.Enums;
using Alperen.AdvertisamentApp.Dtos;
using Alperen.AdvertisamentApp.UI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Alperen.AdvertisamentApp.UI.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly IAdvertisamentAppUserService _service;
        private readonly IAdvertisamentService _advertisamentService;

        public ApplicationController(IAdvertisamentAppUserService service, IAdvertisamentService advertisamentService)
        {
            _service = service;
            _advertisamentService = advertisamentService;
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var response = await _advertisamentService.GetListAsync();
            return this.ResponseView(response);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult List(AdvertisamentAppUserStatusType advertisamentAppUserStatusType)
        {
            var list = _service.ListByStatus(advertisamentAppUserStatusType);
            return View(list);
        }
        public async Task<IActionResult> SetStatus(int advertisamentuserId, AdvertisamentAppUserStatusType advertisamentAppUserStatusType)
        {
            await _service.SetStatus(advertisamentuserId, advertisamentAppUserStatusType);
            return RedirectToAction("List");
        }
        public async Task<IActionResult> AdvertisamentList()
        {
            var response = await _advertisamentService.GetActivesAsync();
            return this.ResponseView(response);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(AdvertisamentCreateDto advertisamentCreateDto)
        {
            var response = await _advertisamentService.CreateAsync(advertisamentCreateDto);
            return this.ResponseViewRedirect(response, "List", "Application");
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id)
        {
            var response = await _advertisamentService.GetByIdAsync<AdvertisamentUpdateDto>(id);
            return this.ResponseView(response);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(AdvertisamentUpdateDto advertisamentUpdateDto)
        {
            var response = await _advertisamentService.UpdateAsync(advertisamentUpdateDto);
            return this.ResponseViewRedirect(response, "AdvertisamentList", "Application");
        }
        public async Task<IActionResult> Remove(int id)
        {
            var response = await _advertisamentService.RemoveAsync(id);
            return this.ResponseViewRedirect(response, "AdvertisamentList", "Application");
        }
    }
}

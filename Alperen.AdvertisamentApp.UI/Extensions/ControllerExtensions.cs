using Alperen.AdvertisamentApp.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace Alperen.AdvertisamentApp.UI.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult ResponseViewRedirect<T>(this Controller controller, IResponse<T> response, string actionName,
            string controllername = "")
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }
            if (response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var item in response.ValidationErrors)
                {
                    controller.ModelState.AddModelError(item.PropertyName, item.Message);
                }
                controller.View(response.Data);
            }
            return controller.RedirectToAction(actionName,controllername);
        }
        public static IActionResult ResponseView<T>(this Controller controller, IResponse<T> response)
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }
            return controller.View(response.Data);
        }
        public static IActionResult ResponseViewRedirect(this Controller controller, IResponse response, string actionName, 
            string controllername = "")
        {
            if (response.ResponseType == ResponseType.NotFound)
            {
                return controller.NotFound();
            }
            return controller.RedirectToAction(actionName, controllername);

        }
    }

}

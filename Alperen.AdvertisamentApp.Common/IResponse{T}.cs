using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alperen.AdvertisamentApp.Common
{
    public interface IResponse<T>:IResponse
    {
        T Data { get; set; }
        List<CustomValidationErrors> ValidationErrors { get; set; }

    }

}

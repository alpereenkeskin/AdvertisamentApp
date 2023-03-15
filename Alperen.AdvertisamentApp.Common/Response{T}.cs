using Alperen.AdvertisamentApp.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alperen.AdvertisamentApp.Common
{
    public class Response<T> : Response, IResponse<T>
    {

        public Response(ResponseType responseType, string message) : base(responseType, message)
        {

        }
        public Response(ResponseType responseType, T data) : base(responseType)
        {
            Data = data;
        }
        public Response(ResponseType responseType, List<CustomValidationErrors> errors,T data) : base(responseType)
        {
            ValidationErrors = errors;
            Data = data;
        }

        public T Data { get; set; }
        public List<CustomValidationErrors> ValidationErrors { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace FeedBackCollection.API
{
    public class Response
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public object Data { get; set; }

    }

    public class BaseController : ControllerBase
    {
        protected IActionResult OkResult(object data)
        {
            var apiResult = new Response
            {
                StatusCode = 200,
                Status = "Success",
                Message = "Successful",
                Data = data
            };
            return ObjectResult(apiResult);
        }

        protected IActionResult ObjectResult(Response model)
        {
            var result = new ObjectResult(model)
            {
                StatusCode = model.StatusCode
            };
            return result;
        }

        protected IActionResult ExceptionResult(Exception ex)
        {


            var apiResult = new Response()
            {
                StatusCode = 500,
                Status = "Error",
                Message = ex.Message,
                Data = new object(),

            };
            return ObjectResult(apiResult);

        }

    }
}

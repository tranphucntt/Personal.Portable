using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace TT.API.Controllers
{
    public class TestController : Controller
    {
        [HttpGet, HttpPost] // 讓此方法可同時接受 HTTP GET 和 POST 請求.
        public HttpResponseMessage HandMadeJson()
        {          
               throw new HttpResponseException(HttpStatusCode.NotFound);

        }

    }
}


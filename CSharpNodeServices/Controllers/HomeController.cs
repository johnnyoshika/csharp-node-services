using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jering.Javascript.NodeJS;
using Microsoft.AspNetCore.Mvc;

namespace CSharpNodeServices.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(INodeJSService nodeService)
        {
            NodeService = nodeService;
        }

        INodeJSService NodeService { get; }

        public async Task<IActionResult> Index()
        {
            var result = await NodeService.InvokeFromFileAsync<int>("./Scripts/add", args: new object[] { 1, 2 });
            return Content("1 + 2 = " + result);
        }

        [HttpGet("memory")]
        public async Task<IActionResult> Memory()
        {
            string javascriptModule = @"
                module.exports = function (callback, a, b) {
                    let result = a + b;
                    callback(/* error */ null, result);
                };
            ";
            var result = await NodeService.InvokeFromStringAsync<int>(javascriptModule, args: new object[] { 1, 2 });
            return Content("1 + 2 = " + result);
        }

        [HttpGet("screenshot")]
        public async Task<IActionResult> Screenshot()
        {
            var url = "https://www.bcjobs.ca/";
            var fileName = System.IO.Path.ChangeExtension(DateTime.UtcNow.Ticks.ToString(), "png");
            var file = await NodeService.InvokeFromFileAsync<string>("Scripts/screenshot", args: new object[] { url, System.IO.Path.Combine("wwwroot/images", fileName) });

            return Content($"<img src=\"/images/{fileName}\" />", "text/html");
        }
    }
}

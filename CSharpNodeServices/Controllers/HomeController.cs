using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;

namespace CSharpNodeServices.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(INodeServices nodeServices)
        {
            NodeServices = nodeServices;
        }

        INodeServices NodeServices { get; }

        public async Task<IActionResult> Index()
        {
            var result = await NodeServices.InvokeAsync<int>("./Scripts/add", 1, 2);
            return Content("1 + 2 = " + result);
        }
    }
}

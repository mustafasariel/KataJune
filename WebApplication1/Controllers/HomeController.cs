using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace WebApplication1.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetContentAsync()
        {
            Thread.Sleep(5000);

            var myTask = new HttpClient().GetStringAsync("https://www.sabah.com.tr");

            var data = await myTask;
            return Ok(data);
        }
    }
}

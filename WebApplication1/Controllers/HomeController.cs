using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;

namespace WebApplication1.Controllers
{


    [Route("api/[controller]")]
    //[Route("api/{controller}/{action}/{id}")]
    [ApiController]
    public class HomeController : Controller
    {
        //[HttpGet]
        //public async Task<IActionResult> GetContentAsync()
        //{
        //    Thread.Sleep(5000);

        //    var myTask = new HttpClient().GetStringAsync("https://www.sabah.com.tr");

        //    var data = await myTask;
        //    return Ok(data);
        //}

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetContentCancelAsync(CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("istek başladı");

                await Task.Delay(5000, cancellationToken);

                var myTask = new HttpClient().GetStringAsync("https://www.sabah.com.tr");

                var data = await myTask;
                _logger.LogInformation("istek tamamlandı");
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"istek iptal edildi :{ex.Message}");
                return BadRequest($"istek iptal edildi {ex.Message}");
            }
        }
    }
}

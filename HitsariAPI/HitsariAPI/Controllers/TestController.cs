using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HitsariAPI.Controllers
{
    // Yksinkertainen controlleri ilman tietokantayhteyksiä testaukseen
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("test")]
        public string Testaa()
        {
            Console.WriteLine("Testikontrolleri löydetty!");
            return "Testi OK!";
        }

    }
}

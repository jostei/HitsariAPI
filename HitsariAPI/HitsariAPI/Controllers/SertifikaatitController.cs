using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HitsariAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace HitsariAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SertifikaatitController : ControllerBase
    {
        // /api/getSertificates GET
        [HttpGet]
        [Route("getSertificates/{id}")]
        public List<Sertifikaatit> GetCertificates(string id)
        {
            //HitsaritContext konteksti = new();
            //Worker w = konteksti.
            //return konteksti.Workers.Where(Worke).ToList();
            return null;
        }
    }
}

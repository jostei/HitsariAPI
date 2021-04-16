using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HitsariAPI.Models;

namespace HitsariAPI.Controllers
{
    // /api/workers
    [Route("api/workers")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        // /api/workers GET
        [HttpGet]
        [Route("Workers")]
        public List<Worker> GetWorkers()
        {
            HitsaritContext konteksti = new();
            return konteksti.Workers.ToList();
        }

        // /api/workers/{workerId}
        [HttpGet]
        [Route("{id}")]
        public List<Worker> GetWorker(string id)
        {
            HitsaritContext konteksti = new();
            return konteksti.Workers.Where(c => c.WorkerId == id).ToList();
        }
    }
}

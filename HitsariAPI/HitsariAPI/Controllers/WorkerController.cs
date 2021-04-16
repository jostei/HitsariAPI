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
        [Route("tolist")]
        public List<Worker> GetWorkers()
        {
            HitsaritContext konteksti = new();
            return konteksti.Workers.ToList();
        }

        // /api/workers/{workerId} GET
        [HttpGet]
        [Route("{id}")]
        public List<Worker> GetWorker(string id)
        {
            HitsaritContext konteksti = new();
            return konteksti.Workers.Where(c => c.WorkerId == id).ToList();
        }

        // /api/addWorker POST JSON
        [HttpPost]
        [Route("addWorker")]
        public void AddWorker([FromBody] Worker tyomies)
        {
            HitsaritContext konteksti = new();
            konteksti.Workers.Add(tyomies);
            konteksti.SaveChanges();
        }
    }
}

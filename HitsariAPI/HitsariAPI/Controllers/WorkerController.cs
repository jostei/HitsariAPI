using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HitsariAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using System.IO;

namespace HitsariAPI.Controllers
{
    // /api/workers
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class WorkerController : ControllerBase
    {
        // /api/workers GET
        // Hakee kaikki työntekijät
        [HttpGet]
        [Route("tolist")]
        public List<Worker> GetWorkers()
        {
            HitsaritContext konteksti = new();
            return konteksti.Workers.ToList();
        }

        // /api/workers/{workerId} GET
        // Hakee työntekijän annetun ID:n perusteella
        [HttpGet]
        [Route("{id}")]
        public List<Worker> GetWorker(string id)
        {
            HitsaritContext konteksti = new();
            return konteksti.Workers.Where(c => c.WorkerId == id).ToList();
        }

        // /api/addWorker POST JSON
        // Lisää tietokantaan uuden työntekijän
        [HttpPost]
        [Route("addWorker")]
        public void AddWorker([FromBody] Worker tyomies)
        {
            HitsaritContext konteksti = new();
            // Lisätään työntekijä jos ei virheitä
            try
            {
                konteksti.Workers.Add(tyomies);
                konteksti.SaveChanges();
            }
            // Napataan exception ja kirjoitetaan viesti lokitiedostoon
            catch (DbUpdateException e)
            {
                string logFilePath = @".\Logs\addWorkerExceptionLog.txt";
                if (!System.IO.File.Exists(logFilePath))
                {
                    // Luodaan tiedosto jos sitä ei ole
                    using (StreamWriter sw = System.IO.File.CreateText(logFilePath))
                    {
                        sw.WriteLine("------------------------------------------\n\nLoki Luotu " + DateTime.Now
                            + "\n\n------------------------------------------\n");                                                                                                                                   
                    }
                }
                // Kirjoitetaan seuraava viesti tiedostoon uudelle riville
                using (StreamWriter sw = System.IO.File.AppendText(logFilePath))
                {
                    sw.WriteLine(DateTime.Now.ToString()+"  Työntekijän lisäys epäonnistui! Message: " + e.ToString());
                }
            }
        }
    }
}

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
        // /api/getCertificates GET
        // Hae yksittäisen työntekijän sertifikaatit
        [HttpGet]
        [Route("getCertificates/{workerId}")]
        public List<Sertifikaatit> GetCertificates(string workerId)
        {
            HitsaritContext konteksti = new();
            return konteksti.Sertifikaatits.Where(c => c.SertifikaatinHaltija == workerId).ToList();
        }

        // /api/getCertificates GET
        // Hae vanhentuvat sertifikaatit
        [HttpGet]
        [Route("getExpiringCertificates")]
        public List<Sertifikaatit> GetExpiringCertificates()
        {
            var minVoimassa = 1; // Määrää monenko kuukauden päästä vanhentuvat listataan
            HitsaritContext konteksti = new();
            return konteksti.Sertifikaatits.Where(c => c.Voimassa < DateTime.Now.AddMonths(minVoimassa) ).ToList();
        }

        // /api/getCertificates GET
        // Hae työntekijän vanhentuvat sertifikaatit
        [HttpGet]
        [Route("getExpiringCertificates/{workerid}")]
        public List<Sertifikaatit> GetExpiringCertificates(string workerid)
        {
            var minVoimassa = 1; // Määrää monenko kuukauden päästä vanhentuvat listataan
            HitsaritContext konteksti = new();
            return konteksti.Sertifikaatits.Where(c => (c.Voimassa < DateTime.Now.AddMonths(minVoimassa) && c.SertifikaatinHaltija == workerid)).ToList();
        }

        // /api/addCertificate POST JSON
        // Lisää tietokantaan uuden sertifikaatin
        [HttpPost]
        [Route("addCertificate")]
        public void AddCertificate([FromBody] Sertifikaatit sert)
        {
            HitsaritContext konteksti = new();
            // Lisätään sertifikaatti jos ei virheitä
            try
            {
                konteksti.Sertifikaatits.Add(sert);
                konteksti.SaveChanges();
            }
            // Napataan exception ja kirjoitetaan viesti lokitiedostoon
            catch (DbUpdateException e)
            {
                string logFilePath = @".\Logs\addCertificateExceptionLog.txt";
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
                    sw.WriteLine(DateTime.Now.ToString() + "  Sertifikaatin lisäys epäonnistui! Message:\n" + e.GetBaseException().ToString() + "\n");
                }
            }
        }

        // /api/deleteCertificate/{workerid}/{certificateid} REMOVE
        // Poistaa sertifikaatin annetun WrokerIdn ja CertificateIdn perusteella
        [HttpDelete]
        [Route("deleteCertificate/{workerid}/{certificateid}")]
        public void DeleteCertificate(string workerid, string certificateid)
        {
            HitsaritContext konteksti = new();
            try
            {
                var sert = new Sertifikaatit {
                    CertificateId = certificateid,
                    SertifikaatinHaltija = workerid
                };
                konteksti.Remove(sert);
                konteksti.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                string logFilePath = @".\Logs\deleteCertificateExceptionLog.txt";
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
                    sw.WriteLine(DateTime.Now.ToString() + "  Sertifikaatin poisto epäonnistui! Message:\n" + e.GetBaseException().ToString() + "\n");
                }
            }
        }

        // /api/updateCertificate/{certificateid} UPDATE JSON
        // Päivittää uudet tiedot sertifikaatille
        [HttpPut]
        [Route("updateCertificate")]
        public void UpdateCertificate([FromBody] Sertifikaatit sert)
        {
            try
            {
            HitsaritContext konteksti = new();
            konteksti.Update(sert);
            konteksti.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                string logFilePath = @".\Logs\updateCertificateExceptionLog.txt";
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
                    sw.WriteLine(DateTime.Now.ToString() + "  Sertifikaatin päivitys epäonnistui! Message:\n" + e.GetBaseException().ToString() + "\n");
                }
            }
        }
    }
}

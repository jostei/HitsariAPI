using System;
using System.Collections.Generic;

#nullable disable

namespace HitsariAPI.Models
{
    public partial class Sertifikaatit
    {
        public string CertificateId { get; set; }
        public string SertifikaatinHaltija { get; set; }
        public DateTime Myönnetty { get; set; }
        public DateTime? Voimassa { get; set; }
        public string Pätevyys { get; set; }
    }
}

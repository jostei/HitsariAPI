using System;
using System.Collections.Generic;

#nullable disable

namespace HitsariAPI.Models
{
    public partial class Worker
    {
        public string WorkerId { get; set; }
        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }
        public string Toimipiste { get; set; }
        public string Esimies { get; set; }
        public string Pätevyys1 { get; set; }
        public string Pätevyys2 { get; set; }
        public string Pätevyys3 { get; set; }
        public string Pätevyys4 { get; set; }
        public DateTime? Lisäyspäivä { get; set; }
        public DateTime? Muokattu { get; set; }
    }
}

using System;

namespace papeletavirtualapp.Entities.Papeleta
{
    public class PapeletaEntity
    {
        public int? IdInfractor { get; set; }
        public int? IdPlaca { get; set; }
        public int? IdInfraccion { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Photo { get; set; }
        public bool? State { get; set; }
        public string Details { get; set; }
        public string City { get; set; }
        public int? IdAutoridad { get; set; }        
    }
}
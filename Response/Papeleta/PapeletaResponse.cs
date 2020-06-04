using System;

namespace papeletavirtualapp.Response.Papeleta
{
    public class PapeletaResponse
    {
        public int Id { get; set; }
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
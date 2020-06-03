using System;
using System.Collections.Generic;

namespace papeletavirtualapp.Models
{
    public partial class Papeleta
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

        public virtual Autoridad IdAutoridadNavigation { get; set; }
        public virtual Infraccion IdInfraccionNavigation { get; set; }
        public virtual Infractor IdInfractorNavigation { get; set; }
        public virtual Placa IdPlacaNavigation { get; set; }
    }
}

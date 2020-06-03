using System;
using System.Collections.Generic;

namespace papeletavirtualapp.Models
{
    public partial class Infractor
    {
        public Infractor()
        {
            Papeleta = new HashSet<Papeleta>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Dni { get; set; }
        public int? IdLicencia { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool? State { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual Licencia IdLicenciaNavigation { get; set; }
        public virtual ICollection<Papeleta> Papeleta { get; set; }
    }
}

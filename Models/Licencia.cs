using System;
using System.Collections.Generic;

namespace papeletavirtualapp.Models
{
    public partial class Licencia
    {
        public Licencia()
        {
            Infractor = new HashSet<Infractor>();
        }

        public int Id { get; set; }
        public string NumLicencia { get; set; }
        public string Class { get; set; }
        public string Category { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Restriction { get; set; }

        public virtual ICollection<Infractor> Infractor { get; set; }
    }
}

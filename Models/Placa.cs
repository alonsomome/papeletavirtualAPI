using System;
using System.Collections.Generic;

namespace papeletavirtualapp.Models
{
    public partial class Placa
    {
        public Placa()
        {
            Papeleta = new HashSet<Papeleta>();
        }

        public int Id { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string TransportDetails { get; set; }
        public string NumPlaca { get; set; }

        public virtual ICollection<Papeleta> Papeleta { get; set; }
    }
}

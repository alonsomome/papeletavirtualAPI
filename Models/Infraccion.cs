using System;
using System.Collections.Generic;

namespace papeletavirtualapp.Models
{
    public partial class Infraccion
    {
        public Infraccion()
        {
            Papeleta = new HashSet<Papeleta>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public decimal? Price { get; set; }
        public string Details { get; set; }

        public virtual ICollection<Papeleta> Papeleta { get; set; }
    }
}

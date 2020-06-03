using System;
using System.Collections.Generic;

namespace papeletavirtualapp.Models
{
    public partial class Autoridad
    {
        public Autoridad()
        {
            Papeleta = new HashSet<Papeleta>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool? State { get; set; }
        public string Phone { get; set; }
        public string Cip { get; set; }

        public virtual ICollection<Papeleta> Papeleta { get; set; }
    }
}

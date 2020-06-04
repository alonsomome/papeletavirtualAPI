using System;

namespace papeletavirtualapp.Entities.Infractor
{
    public class InfractorEntity
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Dni { get; set; }
        public int? IdLicencia { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool? State { get; set; }
        public DateTime? CreateDate { get; set; }       
    }
}
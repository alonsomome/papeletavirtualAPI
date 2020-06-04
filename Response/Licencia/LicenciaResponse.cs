using System;

namespace papeletavirtualapp.Response.Licencia
{
    public class LicenciaResponse
    {
        public int Id { get; set; }
        public string NumLicencia { get; set; }
        public string Class { get; set; }
        public string Category { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Restriction { get; set; }     
    }
}
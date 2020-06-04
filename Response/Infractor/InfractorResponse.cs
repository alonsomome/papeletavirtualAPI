using System;
using System.Collections.Generic;
using papeletavirtualapp.Response.Papeleta;
using papeletavirtualapp.Response.Licencia;


namespace papeletavirtualapp.Response.Infractor
{
    public class InfractorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool? State { get; set; }
        public DateTime? CreateDate { get; set; }

        public List<PapeletaResponse> Papeleta {get;set;} = new List<PapeletaResponse>();

        public List<Licencia.LicenciaResponse> Licencia {get;set;} = new List<Licencia.LicenciaResponse>();



    }
}
using System;
using System.Collections.Generic;
using papeletavirtualapp.Response.Infraccion;
using papeletavirtualapp.Response.Infractor;
using papeletavirtualapp.Response.Placa;

namespace papeletavirtualapp.Response.Papeleta
{
    public class PapeletaResponse
    {
        public int Id { get; set; }
        //public int? IdInfractor { get; set; }
        //public int? IdPlaca { get; set; }
        // public int? IdInfraccion { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Photo { get; set; }
        public bool? State { get; set; }
        public string Details { get; set; }
        public string City { get; set; }
        public int? IdAutoridad { get; set; }
                
        //Edgar Mori
        //add for request: GetPapeletabyAutoridadID()
        public List<InfractorResponse> Infractor {get; set;} = new List<InfractorResponse>();
        public List<InfraccionResponse> Infraccion {get; set;} = new List<InfraccionResponse>();  
        public List<PlacaResponse> Placa {get; set;} = new List<PlacaResponse>();  


    }
}
using System;
using System.Collections.Generic;
using papeletavirtualapp.Response.Papeleta;

namespace papeletavirtualapp.Response.Placa
{
    public class PlacaResponse
    {
        public int Id { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string TransportDetails { get; set; }
        public string NumPlaca { get; set; }

        public List<PapeletaResponse> Papeleta { get; set; } = new List<PapeletaResponse>();
    }
}
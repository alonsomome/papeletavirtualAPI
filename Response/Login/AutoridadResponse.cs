using System.Collections.Generic;
using papeletavirtualapp.Response.Infraccion;
using papeletavirtualapp.Response.Infractor;
using papeletavirtualapp.Response.Papeleta;

namespace papeletavirtualapp.Response.Autoridad
{
    public class AutoridadResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool? State { get; set; }
        public string Phone { get; set; }
        public string Cip { get; set; }

        public List<PapeletaResponse> Papeleta {get; set;} = new List<PapeletaResponse>();
        
    }
}
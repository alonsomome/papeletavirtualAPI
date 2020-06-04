using System;
using System.Linq;
using papeletavirtualapp.Models;
using papeletavirtualapp.Response;
using papeletavirtualapp.Response.Autoridad;
using papeletavirtualapp.Response.Papeleta;

namespace papeletavirtualapp.Business.Autoridad
{
    public class AutoridadBusiness
    {
        public ResultResponse<AutoridadResponse> GetById(PapeletaVirtualDBContext _context,int id){
            try
            {
                ResultResponse<AutoridadResponse> response = new ResultResponse<AutoridadResponse>();
                var firstresult = _context.Autoridad.Any(x=>x.Id == id);
                if(firstresult){
                    var result = _context.Autoridad.FirstOrDefault(x=>x.Id==id);
                    AutoridadResponse autoridadResponse = new AutoridadResponse{
                        Id = result.Id,
                        Name = result.Name,
                        Lastname = result.Lastname,
                        Email = result.Email,
                        Username = result.Username,
                        Password = result.Password,
                        State = result.State,
                        Phone = result.Phone,
                        Cip = result.Cip,
                        Papeleta = _context.Papeleta.Where(y=>y.IdAutoridad == result.Id).Select( 
                            y=> new PapeletaResponse{
                                    Id= y.Id,
                                    IdInfractor=y.IdInfractor,
                                    IdInfraccion = y.IdInfraccion,
                                    CreateDate = y.CreateDate,
                                    Photo = y.Photo,
                                    State = y.State,
                                    Details = y.Details,
                                    City = y.City,
                                    IdAutoridad= y.IdAutoridad
                                }
                        ).ToList()                       
                    };
                    response.Data = autoridadResponse;
                    response.Error = false;
                    response.Message ="Datos encontrados";    
                }else{

                    response.Data = null;
                    response.Error = true;
                    response.Message ="Datos no encontrados";       
                }
                return response;
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
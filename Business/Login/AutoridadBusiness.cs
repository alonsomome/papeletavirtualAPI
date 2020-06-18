using System;
using System.Linq;
using papeletavirtualapp.Models;
using papeletavirtualapp.Response;
using papeletavirtualapp.Response.Autoridad;
using papeletavirtualapp.Response.Infraccion;
using papeletavirtualapp.Response.Infractor;
using papeletavirtualapp.Response.Papeleta;
using papeletavirtualapp.Response.Placa;

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
                    //var resultPapeleta = _context.Papeleta.FirstOrDefault(x=>x.IdAutoridad==id);                    
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
                                    CreateDate = y.CreateDate,
                                    Photo = y.Photo,
                                    State = y.State,
                                    Details = y.Details,
                                    City = y.City,
                                    IdAutoridad= y.IdAutoridad,
                                    Infractor = _context.Infractor.Where(w=>w.Id == y.IdInfractor).Select(
                                        w => new InfractorResponse{
                                            Id=w.Id,
                                            Name = w.Name,
                                            Lastname = w.Lastname,
                                            Dni = w.Dni,
                                            Email = w.Email,
                                            Phone = w.Phone,
                                            State = w.State,
                                            CreateDate = w.CreateDate
                                        }
                                    ).ToList(),
                                    Infraccion = _context.Infraccion.Where(z=>z.Id == y.IdInfraccion).Select(
                                        z => new InfraccionResponse{
                                            Id = z.Id,
                                            Type=z.Type,
                                            Code = z.Code,
                                            Price = z.Price,
                                            Details = z.Details                                            
                                        }
                                    ).ToList(),
                                    Placa = _context.Placa.Where(z=>z.Id == y.IdPlaca).Select(
                                        z => new PlacaResponse{
                                            Id = z.Id,
                                            CarBrand=z.CarBrand,
                                            CarModel = z.CarModel,
                                            ReleaseDate = z.ReleaseDate,
                                            TransportDetails = z.TransportDetails,
                                            NumPlaca = z.NumPlaca                                            
                                        }
                                    ).ToList()
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
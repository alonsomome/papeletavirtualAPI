using System;
using System.Linq;
using papeletavirtualapp.Entities.Infractor;
using papeletavirtualapp.Models;
using papeletavirtualapp.Response;
using papeletavirtualapp.Response.Infractor;
using papeletavirtualapp.Response.Licencia;
using papeletavirtualapp.Response.Papeleta;

namespace papeletavirtualapp.Business.Infractor
{
    public class InfractorBusiness
    {
        public ResultResponse<InfractorResponse> GetById(PapeletaVirtualDBContext _context, int id)
        {
            try
            {
                ResultResponse<InfractorResponse> response = new ResultResponse<InfractorResponse>();
                var firstresult = _context.Infractor.Any(x=>x.Id == id);
                if(firstresult){
                    var result = _context.Infractor.FirstOrDefault(x=>x.Id == id);
                    InfractorResponse infractorResponse = new InfractorResponse{
                        Id = result.Id,
                        Name = result.Name,
                        Lastname = result.Lastname,
                        Dni = result.Dni,
                        Email = result.Email,
                        Phone = result.Phone,
                        State = result.State,
                        CreateDate = result.CreateDate,
                        Papeleta = _context.Papeleta.Where(y=>y.IdInfractor == result.Id).Select( 
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
                        ).ToList(),
                        Licencia = _context.Licencia.Where(y=>y.IdInfractor == result.Id).Select(
                            y=> new LicenciaResponse{
                                    Id = y.Id,
                                    NumLicencia = y.NumLicencia,
                                    Class = y.Class,
                                    Category = y.Category,
                                    CreationDate = y.CreationDate,
                                    ExpirationDate = y.ExpirationDate,
                                    Restriction= y.Restriction
                            }
                        ).ToList()
                    };

                    response.Data = infractorResponse;
                    response.Error = false;
                    response.Message ="Datos encontrados";                    
                }else{

                    response.Data = null;
                    response.Error = true;
                    response.Message ="Datos no encontrados";       
                }

                return response;
            }catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }
/*
        public ResultResponse<string> Add(PapeletaVirtualDBContext _context, InfractorEntity model){
            try
            {
                ResultResponse<string> response = new ResultResponse<string>();
                if(model.Dni == null){
                    response.Data = null;
                    response.Error = true;
                    response.Message= "Se necesita el numero de dni";
                    return response;
                }
                if()

                
            }
            catch (Exception ex) 
            {
                
                throw new Exception(ex.Message);
            }
        }
        */
    }
}
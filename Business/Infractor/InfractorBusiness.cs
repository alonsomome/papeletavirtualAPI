using System;
using System.Linq;
using System.Transactions;
using papeletavirtualapp.Entities.Infractor;
using papeletavirtualapp.Helpers;
using papeletavirtualapp.Models;
using papeletavirtualapp.Response;
using papeletavirtualapp.Response.Infraccion;
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
                                    CreateDate = y.CreateDate,
                                    Photo = y.Photo,
                                    State = y.State,
                                    Details = y.Details,
                                    City = y.City,
                                    IdAutoridad= y.IdAutoridad,
                                    Infraccion = _context.Infraccion.Where(z=>z.Id == y.IdInfraccion).Select(
                                        z => new InfraccionResponse{
                                            Id = z.Id,
                                            Type=z.Type,
                                            Code = z.Code,
                                            Price = z.Price,
                                            Details = z.Details                                            
                                        }
                                    ).ToList()                                    
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

        public ResultResponse<InfractorResponse> Add(PapeletaVirtualDBContext _context, InfractorEntity model){
            try
            {
                InfractorResponse infractorResponseforAdd;
                //ResultResponse<string> response = new ResultResponse<string>();
                ResultResponse<InfractorResponse> response = new ResultResponse<InfractorResponse>();
                if(model.Dni == null){
                    response.Data = null;
                    response.Error = true;
                    response.Message= "Se necesita el numero de dni";
                    return response;
                }
                if(model.Email== null){
                    response.Data = null;
                    response.Error = true;
                    response.Message ="Se necesita el email";
                    return response;
                }
                if(model.Name == null){
                    response.Data = null;
                    response.Error = true;
                    response.Message ="Se necesita el nombre";
                    return response;
                }
                if(_context.Infractor.Any(x=>x.Dni == model.Dni)){
                        response.Data = null;
                        response.Error = true;
                        response.Message = "El número de DNI ya existe";
                        return response;
                }else
                {
                    using (var ts = new TransactionScope()){
                    Models.Infractor infractor = new Models.Infractor();
                    _context.Infractor.Add(infractor);

                    infractor.Name= model.Name;
                    infractor.Lastname= model.Lastname;
                    infractor.Dni = model.Dni;
                    infractor.Email = model.Email;
                    infractor.Phone = model.Phone;
                    infractor.State = ConstantHelpers.Estado.Activo;
                    infractor.CreateDate = model.CreateDate;

                    _context.SaveChanges();
                    ts.Complete();
                    }
                    var result = _context.Infractor.FirstOrDefault(x=>x.Dni ==model.Dni);
                    infractorResponseforAdd = new InfractorResponse{
                        Id = result.Id,
                        Name = result.Name,
                        Lastname = result.Lastname,
                        Dni = result.Dni,
                        Email = result.Email,
                        Phone = result.Phone,
                        State = result.State,
                        CreateDate = result.CreateDate                        
                    };
                    response.Data = infractorResponseforAdd;
                    response.Error = false;
                    response.Message = "Infractor registrado con éxito";  


                }
                return  response;                
            }
            catch (Exception ex) 
            {
                
                throw new Exception(ex.Message);
            }
        }
        
        public ResultResponse<InfractorResponse> GetByDni(PapeletaVirtualDBContext _context,string dni){
            try
            {
                ResultResponse<InfractorResponse> response = new ResultResponse<InfractorResponse>();
                var firstresult = _context.Infractor.Any(x=>x.Dni == dni);
                if(firstresult){
                    var result = _context.Infractor.FirstOrDefault(x=>x.Dni == dni);
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
                                    ).ToList()
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

    }
}
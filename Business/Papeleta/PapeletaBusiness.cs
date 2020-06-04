using System;
using System.Linq;
using papeletavirtualapp.Entities.Papeleta;
using papeletavirtualapp.Models;
using papeletavirtualapp.Response;
using papeletavirtualapp.Response.Papeleta;
using papeletavirtualapp.Helpers;
using System.Transactions;
using Microsoft.Extensions.Configuration;

namespace papeletavirtualapp.Business.Papeleta
{
    public class PapeletaBusiness
    {
        public ResultResponse<string> AddPapeleta (PapeletaVirtualDBContext _context , PapeletaEntity model){
            try
            {
                ResultResponse<string> response = new ResultResponse<string>();
                if(model.IdInfractor == null){
                    response.Data = null;
                    response.Error=true;
                    response.Message = "Se necesita los datos del Infractor ";
                    return response;
                }
                if(model.IdPlaca == null){
                    response.Data = null;
                    response.Error = true;
                    response.Message ="Se necesita los datos del vehiculo";
                    return response;
                }
                if(model.IdInfraccion== null){
                    response.Data = null;
                    response.Error =true;
                    response.Message ="Se necesita ingresar una infraccion";
                    return response;
                }

                using( var ts = new TransactionScope()){
                    Models.Papeleta papeleta = new Models.Papeleta();
                    _context.Papeleta.Add(papeleta);

                    papeleta.IdInfraccion  = model.IdInfraccion;
                    papeleta.IdPlaca = model.IdPlaca;
                    papeleta.IdInfractor = model.IdInfractor;
                    papeleta.CreateDate = model.CreateDate;
                    papeleta.Photo = model.Photo;
                    papeleta.State = ConstantHelpers.Estado.Activo;
                    papeleta.Details = model.Details;
                    papeleta.City = model.City;
                    papeleta.IdAutoridad = model.IdAutoridad;

                    _context.SaveChanges();
                    ts.Complete();            
                    response.Data = null;
                    response.Error = false;
                    response.Message = "Papeleta guardada con éxito";
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
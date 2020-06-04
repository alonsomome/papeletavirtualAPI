using System;
using System.Linq;
using System.Transactions;
using papeletavirtualapp.Entities.Placa;
using papeletavirtualapp.Models;
using papeletavirtualapp.Response;
using papeletavirtualapp.Response.Placa;

namespace papeletavirtualapp.Business.Placa
{
    public class PlacaBusiness
    {
        public ResultResponse<string> AddPlaca(PapeletaVirtualDBContext _context, PlacaEntity model){
            try
            {
                ResultResponse<string> response = new ResultResponse<string>();
                if(model==null){
                    response.Data = null;
                    response.Error = true;
                    response.Message ="Completar todos los campos";
                    return response;                    
                }

                if(_context.Placa.Any(x=>x.NumPlaca== model.NumPlaca)){
                    response.Data = null;
                    response.Error = true;
                    response.Message = "El número de Placa ya existe";
                    return response;                    
                }else{
                    using( var ts= new TransactionScope()){
                        Models.Placa placa=new Models.Placa();
                        _context.Placa.Add(placa);
                        placa.CarBrand = model.CarBrand;
                        placa.CarModel=model.CarModel;
                        placa.TransportDetails = model.TransportDetails;
                        placa.NumPlaca = model.NumPlaca;

                        _context.SaveChanges();
                        ts.Complete();
                        response.Data = null;
                        response.Error = false;
                        response.Message = "Placa registrada";  

                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                
                throw new System.Exception(ex.Message);
            }
        }
    }
}
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
        public ResultResponse<PlacaResponse> AddPlaca(PapeletaVirtualDBContext _context, PlacaEntity model){
            try
            {
                PlacaResponse placaResponseforAdd ;
                ResultResponse<PlacaResponse> response = new ResultResponse<PlacaResponse>();
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
                    var result = _context.Placa.FirstOrDefault(x=>x.NumPlaca ==model.NumPlaca);
                    placaResponseforAdd = new PlacaResponse{
                        Id = result.Id,
                        CarBrand = result.CarBrand,
                        CarModel = result.CarModel,
                        ReleaseDate = result.ReleaseDate,
                        TransportDetails = result.TransportDetails,
                        NumPlaca = result.NumPlaca                 
                        
                    };
                        response.Data = placaResponseforAdd;
                        response.Error = false;
                        response.Message = "Placa registrada";                      

                }
                return response;
            }
            catch (Exception ex)
            {
                
                throw new System.Exception(ex.Message);
            }
        }
   
        public ResultResponse<PlacaResponse> getByPlaca(PapeletaVirtualDBContext _context,string numplaca){
            try
            {
                ResultResponse<PlacaResponse> response = new ResultResponse<PlacaResponse>();
                var firstresult = _context.Placa.Any(x=>x.NumPlaca == numplaca );
                if(firstresult){
                    var result = _context.Placa.FirstOrDefault(x=>x.NumPlaca == numplaca);
                    PlacaResponse placaResponse = new PlacaResponse{
                        Id= result.Id,
                        CarBrand = result.CarBrand,
                        CarModel = result.CarModel,
                        ReleaseDate = result.ReleaseDate,
                        TransportDetails = result.TransportDetails,
                        NumPlaca = result.NumPlaca                        
                    };
                    response.Data = placaResponse;
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
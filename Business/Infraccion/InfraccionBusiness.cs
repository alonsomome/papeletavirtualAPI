using System;
using System.Linq;
using papeletavirtualapp.Models;
using papeletavirtualapp.Response;
using papeletavirtualapp.Response.Infraccion;

namespace papeletavirtualapp.Business.Infraccion
{
    public class InfraccionBusiness
    {
        public ResultResponse<InfraccionResponse> GetById(PapeletaVirtualDBContext _context, int id){
            try
            {
                ResultResponse<InfraccionResponse> response = new ResultResponse<InfraccionResponse>();
                var firstresult = _context.Infraccion.Any(x=>x.Id == id);
                if(firstresult){
                    var result = _context.Infraccion.FirstOrDefault(x=>x.Id == id);

                    InfraccionResponse infraccionResponse = new InfraccionResponse{
                        Id= result.Id,
                        Type = result.Type,
                        Code = result.Code,
                        Price = result.Price,
                        Details = result.Details

                    };
                    response.Data = infraccionResponse;
                    response.Error = false;
                    response.Message = "Datos encontrados";
                }else{
                    response.Data = null;
                    response.Error = true;
                    response.Message = "Datos no encontrados";                    
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
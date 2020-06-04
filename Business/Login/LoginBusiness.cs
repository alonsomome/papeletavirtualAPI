using System;
using System.Linq;
using papeletavirtualapp.Entities.Login;
using papeletavirtualapp.Models;
using papeletavirtualapp.Response.Login;
using papeletavirtualapp.Response;
using papeletavirtualapp.Helpers;
using System.Transactions;
using Microsoft.Extensions.Configuration;

namespace papeletavirtualapp.Business.Login
{
    public class LoginBusiness
    {
        public ResultResponse<string> RegisterAutoridad(PapeletaVirtualDBContext _context, AutoridadEntity model)
        {
            try
            {
                ResultResponse<string> response = new ResultResponse<string>();
                char[] s={' '};
                string[] slastname;
                if(model == null){
                    response.Data = null;
                    response.Error = true;
                    response.Message = "Complete los datos";
                }else
                {
                    if(_context.Autoridad.Any(x =>x.Email == model.Email)){
                        response.Data= null;
                        response.Error = true;
                        response.Message = "El correo ya existe";
                    }
                    if(_context.Autoridad.Any(x =>x.Phone == model.Phone)){
                        response.Data = null;
                        response.Error = true;
                        response.Message = "El numero de telefono ya existe";
                    }
                    using (var ts = new TransactionScope()){
                        Models.Autoridad autoridad = new Models.Autoridad();
                        _context.Autoridad.Add(autoridad);

                        autoridad.Name = model.Name;
                        autoridad.Lastname = model.Lastname;
                        autoridad.Email = model.Email;
                        //autoridad.Username = model.Username;
                        slastname = model.Lastname.Split(s,2,StringSplitOptions.None);
                        autoridad.Username = model.Name.Substring(0,1).ToLower() + slastname[0].ToLower()+"pnp";                       
                        autoridad.Password = model.Password;
                        autoridad.State = ConstantHelpers.Estado.Activo;
                        autoridad.Phone = model.Phone;
                        autoridad.Cip = model.Cip;
                        _context.SaveChanges();
                        ts.Complete();
                        response.Data = null;
                        response.Error = false;
                        response.Message = "Registro satisfactorio";
                    }
                }
                return response;                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ResultResponse<LoginAutoridadResponse> LogInAutoridad(PapeletaVirtualDBContext _context, IConfiguration _config, LoginEntity model)
            {
                try
                {
                    var userAutoridad = false;
                    ResultResponse<LoginAutoridadResponse> response = new ResultResponse<LoginAutoridadResponse>();
                    userAutoridad = _context.Autoridad.Any(x =>x.Username == model.Username && x.Password == model.Password);
                    if(userAutoridad){
                    var autoridad = _context.Autoridad.FirstOrDefault(x =>x.Username == model.Username && x.Password == model.Password);
                    LoginTokenAutoridad(_config,autoridad,response);
                    }else{
                        userAutoridad = _context.Autoridad.Any(x =>x.Email == model.Username && x.Password == model.Password);
                        if(userAutoridad){
                            var autoridad = _context.Autoridad.FirstOrDefault(x =>x.Email == model.Username && x.Password == model.Password);
                            LoginTokenAutoridad(_config,autoridad,response);
                        }
                        if(!userAutoridad){
                        response.Data = null;
                        response.Error = true;
                        response.Message = "Usuario y/o password incorrecto";                        
                        }
                    }
                    return response;
                }
                catch (Exception ex)
                {                
                    throw new Exception(ex.Message);
                }
            }
        
        public static void LoginTokenAutoridad(IConfiguration _config, Models.Autoridad autoridad, ResultResponse<LoginAutoridadResponse> response)
        {
            var jwt = new JwtService(_config);
            var token = jwt.GenerateSecurityToken(autoridad.Email);      
            LoginAutoridadResponse loginResponse = new LoginAutoridadResponse{
                Token = token,
                Id =autoridad.Id,
                Name = autoridad.Name,
                LastName =autoridad.Lastname
            };
            response.Data = loginResponse;
            response.Error = false;
            response.Message = "Inicio de Sesion Satisfactorio";   
        }        


    }
}
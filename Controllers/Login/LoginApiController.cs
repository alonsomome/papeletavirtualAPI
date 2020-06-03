using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using papeletavirtualapp.Models;
using papeletavirtualapp.Business.Login;
using papeletavirtualapp.Entities.Login;
using Microsoft.Extensions.Configuration;
using System.Net;



namespace papeletavirtualapp.Controllers.Login
{
    [Route("[controller]")]
    [ApiController]
    public class LoginApiController : ControllerBase
    {
        private readonly PapeletaVirtualDBContext _context;
        private IConfiguration _config;

        public LoginApiController(PapeletaVirtualDBContext context, IConfiguration config){
            _context = context;
            _config = config;
        }
        [HttpPost("autoridadlogin")]
        public async Task<IActionResult> PostLogInAutoridad(LoginEntity model){
            LoginBusiness loginBusiness = new LoginBusiness();
            var response = loginBusiness.LogInAutoridad(_context,_config,model);
            if(response.Error == false){
                return Ok(response);
            }else{
                return BadRequest(response);
            }
        }

        [HttpPost("autoridadregister")]
        public async Task<IActionResult> PostRegisterAutoridad(AutoridadEntity model){
            LoginBusiness loginBusiness = new LoginBusiness();
            var response = loginBusiness.RegisterAutoridad(_context, model);
            if(response.Error == false){
                return Ok(response);
            }else{
                return BadRequest(response);
            }
            
        }

    }
}
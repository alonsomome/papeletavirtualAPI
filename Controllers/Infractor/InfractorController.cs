using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using papeletavirtualapp.Business.Infractor;
using papeletavirtualapp.Models;
using System.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;



namespace papeletavirtualapp.Controllers.Infractor
{

    [Route("[Controller]")]
    [ApiController]
    public class InfractorController : Controller
    {
        private readonly PapeletaVirtualDBContext _context;
        
        public InfractorController(PapeletaVirtualDBContext context){
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInfractorById(int id){
            InfractorBusiness infractorBusiness = new InfractorBusiness();
            var result = infractorBusiness.GetById(_context,id);
            if(result.Error == false){
                return Ok(result);
            }else{
                return BadRequest(result);
            }
        }
    }
}
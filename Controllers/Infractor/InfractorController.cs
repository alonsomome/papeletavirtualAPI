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
using papeletavirtualapp.Entities.Infractor;

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

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id){
            InfractorBusiness infractorBusiness = new InfractorBusiness();
            var result = infractorBusiness.GetById(_context,id);
            if(result.Error == false){
                return Ok(result);
            }else{
                return BadRequest(result);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(InfractorEntity model){
            InfractorBusiness infractorBusiness = new InfractorBusiness();
            var result = infractorBusiness.Add(_context,model);
            if(result.Error == false){
                return Ok(result);
            }else{
                return BadRequest(result);
            }           
        }

        [HttpGet("[action]/{dni}")]
        public async Task<IActionResult> GetByDni(string dni){
            InfractorBusiness infractorBusiness = new InfractorBusiness();
            var result = infractorBusiness.GetByDni(_context,dni);
            if(result.Error == false){
                return Ok(result);
            }else{
                return BadRequest(result);
            }
        }
    }
}
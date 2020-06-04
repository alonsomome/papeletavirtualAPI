using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using papeletavirtualapp.Business.Infraccion;
using papeletavirtualapp.Models;

namespace papeletavirtualapp.Controllers.Infraccion
{

    [Route("[controller]")]
    [ApiController]
    public class InfraccionController : Controller
    {
        private readonly PapeletaVirtualDBContext _context;

        public InfraccionController(PapeletaVirtualDBContext context){
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInfraccionById(int id){
            InfraccionBusiness infraccionBusiness = new InfraccionBusiness();
            var result = infraccionBusiness.GetById(_context,id);
            if(result.Error == false){
                return Ok(result);
            }else{
                return BadRequest(result);
            }
        }
        
    }
}
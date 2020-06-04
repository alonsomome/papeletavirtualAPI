using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using papeletavirtualapp.Business.Autoridad;
using papeletavirtualapp.Models;

namespace papeletavirtualapp.Controllers.Login
{   
       
    [Route("[controller]")]
    [ApiController]
    public class AutoridadApiController : Controller
    {
        private readonly PapeletaVirtualDBContext _context;

        public AutoridadApiController(PapeletaVirtualDBContext context){
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAutoridadById(int id){
            AutoridadBusiness autoridadBusiness = new AutoridadBusiness();
            var response = autoridadBusiness.GetById(_context, id);
            if(response.Error == false){
                return Ok(response);
            }else{
                return BadRequest(response);
            }
        }

    }
    
}
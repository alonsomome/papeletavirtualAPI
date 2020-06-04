using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using papeletavirtualapp.Business.Placa;
using papeletavirtualapp.Entities.Placa;
using papeletavirtualapp.Models;

namespace papeletavirtualapp.Controllers.Placa
{
    [ApiController]
    [Route("[controller]")]
    public class PlacaController : Controller
    {
        private readonly PapeletaVirtualDBContext _context;
        public PlacaController(PapeletaVirtualDBContext context){
            _context = context;
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> Add(PlacaEntity model)
        {

            PlacaBusiness placaBusiness = new PlacaBusiness();

            var response = placaBusiness.AddPlaca(_context,model);

            if(response.Error == false)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        
    }
}
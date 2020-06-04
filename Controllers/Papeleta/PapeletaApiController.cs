using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using papeletavirtualapp.Models;
using papeletavirtualapp.Business.Papeleta;
using papeletavirtualapp.Entities.Papeleta;


namespace papeletavirtualapp.Controllers.Papeleta
{
    [Route("[Controller]")]
    [ApiController]
    public class PapeletaApiController : Controller
    {
        private readonly PapeletaVirtualDBContext _context;
        public PapeletaApiController(PapeletaVirtualDBContext context){
            _context = context;
        }

        [HttpPost("addpapeleta")]
        public async Task<IActionResult> AddPapeletas(PapeletaEntity model)
        {

            PapeletaBusiness papeletaBusiness = new PapeletaBusiness();

            var response = papeletaBusiness.AddPapeleta(_context,model);

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
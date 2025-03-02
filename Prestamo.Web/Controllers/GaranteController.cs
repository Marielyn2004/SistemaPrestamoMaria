using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prestamo.Data;
using Prestamo.Entidades;
namespace Prestamo.Web.Controllers
{
    [Authorize]
    public class GaranteController : Controller
    {
        private readonly GaranteData _garanteData;
        public GaranteController(GaranteData garanteData)
        {
            _garanteData = garanteData;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Garante> lista = await _garanteData.Lista();
            return StatusCode(StatusCodes.Status200OK, new { data = lista });
        }


        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Garante objeto)
        {
            string respuesta = await _garanteData.Crear(objeto);
            return StatusCode(StatusCodes.Status200OK, new { data = respuesta });
        }

        [HttpPut]
        public async Task<IActionResult> Editar([FromBody] Garante objeto)
        {
            string respuesta = await _garanteData.Editar(objeto);
            return StatusCode(StatusCodes.Status200OK, new { data = respuesta });
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int Id)
        {
            string respuesta = await _garanteData.Eliminar(Id);
            return StatusCode(StatusCodes.Status200OK, new { data = respuesta });
        }
    }
}

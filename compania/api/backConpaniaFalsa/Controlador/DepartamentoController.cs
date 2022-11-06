using backConpaniaFalsa.Modelo;
using backConpaniaFalsa.Vista;
using Microsoft.AspNetCore.Mvc;

namespace backConpaniaFalsa.Controlador
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : Controller
    {
        private IDepartamento db = new DepCollection();

        [HttpGet]
        public async Task <IActionResult> getAllDepartamentos()
        {
            return Ok(await db.GetAllDepartamentos());
        }
        
        [HttpGet("{id}")]
        public async Task <IActionResult> getDepartamentosById(string id)
        {
            return Ok(await db.GetDepartamentosById(id));
        }
        [HttpPost]
        public async Task<IActionResult> postDepartamento([FromBody] Departamento dep)
        {
            if (dep == null)
                return BadRequest();
            if (dep.nombreDepa == string.Empty)
            {
                ModelState.AddModelError("nombreDepa", "Debes llenar el nombre");
            }

            await db.PostDepartamento(dep);

            return Created("Creado exitosamente", true);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> putDepartamento([FromBody] Departamento dep, string id)
        {
            if (dep == null)
                return BadRequest();
            if (dep.nombreDepa == string.Empty)
            {
                ModelState.AddModelError("nombreDepa", "Debes llenar el nombre");
            }


            dep.Id = new MongoDB.Bson.ObjectId(id);
            await db.PutDepartamento(dep);

            return Created("Modificado exitosamente", true);
        }

        [HttpDelete]
        public async Task<IActionResult> deleteDepartamento(string id)
        {
                      
            await db.DeleteDepartamento(id);

            return NoContent();
        }
    }
}

using backConpaniaFalsa.Modelo;
using backConpaniaFalsa.Vista;
using Microsoft.AspNetCore.Mvc;

namespace backConpaniaFalsa.Controlador
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : Controller
    {
        private IEmpleado db = new EmpCollection();

        [HttpGet]
        public async Task <IActionResult> getAllEmpleados()
        {
            return Ok(await db.GetAllEmpleados());
        }
        
        [HttpGet("{id}")]
        public async Task <IActionResult> getEmpleadosById(string id)
        {
            return Ok(await db.GetEmpleadoById(id));
        }
        [HttpPost]
        public async Task<IActionResult> postEmpleado([FromBody] Empleado dep)
        {
            if (dep == null)
                return BadRequest();
            if (dep.nombre == string.Empty)
            {
                ModelState.AddModelError("nombre", "Debes llenar el nombre");
            }
            if (dep.correo == string.Empty)
            {
                ModelState.AddModelError("correo", "Debes llenar el campo");
            }
            if (dep.pass == string.Empty)
            {
                ModelState.AddModelError("pass", "Debes llenar el campo");
            }

            await db.PostEmpleado(dep);

            return Created("Creado exitosamente", true);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> putEmpleado([FromBody] Empleado dep, string id)
        {
            if (dep == null)
                return BadRequest();
            if (dep.nombre == string.Empty)
            {
                ModelState.AddModelError("nombre", "Debes llenar el campo");
            }
            if (dep.correo == string.Empty)
            {
                ModelState.AddModelError("correo", "Debes llenar el campo");
            }
            if (dep.pass == string.Empty)
            {
                ModelState.AddModelError("pass", "Debes llenar el campo");
            }


            dep.Id = new MongoDB.Bson.ObjectId(id);
            await db.PutEmpleado(dep);

            return Created("Modificado exitosamente", true);
        }

        [HttpDelete]
        public async Task<IActionResult> deleteEmpleado(string id)
        {
                      
            await db.DeleteEmpleado(id);

            return NoContent();
        }
    }
}

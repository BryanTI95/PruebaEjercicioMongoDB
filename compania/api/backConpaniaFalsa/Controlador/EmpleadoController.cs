using backConpaniaFalsa.Modelo;
using backConpaniaFalsa.Vista;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization;
using MongoDB.Driver.Core.WireProtocol.Messages;
using System.Runtime.Intrinsics.Arm;

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

        [HttpGet("{correo},{pass}")]
        public async Task<IActionResult> getLoginEmpleado(string correo, string pass)
        {
            Empleado emp = new Empleado();

            emp.correo = correo;
            emp.pass = pass;

            if (correo!= emp.correo && pass != emp.pass)
            {
                ModelState.AddModelError("nombre,pass", "Debes llenar el campo correctamente");

            }
            else
            {
                Ok("Bienvenido " + emp.nombre);
            }
            Console.WriteLine(db.GetLoginEmpleado(correo, pass));
            return Ok(await db.GetLoginEmpleado(correo,pass));

        }
        
        [HttpGet("{id}")]
        public async Task <IActionResult> getEmpleadosById(string id)
        {
            return Ok(await db.GetEmpleadoById(id));
        }
        [HttpPost]
        public async Task<IActionResult> postEmpleado([FromBody] Empleado emp)
        {
            if (emp == null)
                return BadRequest();
            if (emp.nombre == string.Empty)
            {
                ModelState.AddModelError("nombre", "Debes llenar el nombre");
            }
            if (emp.correo == string.Empty)
            {
                ModelState.AddModelError("correo", "Debes llenar el campo");
            }
            if (emp.pass == string.Empty)
            {
                ModelState.AddModelError("pass", "Debes llenar el campo");
            }

            await db.PostEmpleado(emp);

            return Created("Creado exitosamente", true);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> putEmpleado([FromBody] Empleado emp, string id)
        {
            if (emp == null)
                return BadRequest();
            if (emp.nombre == string.Empty)
            {
                ModelState.AddModelError("nombre", "Debes llenar el campo");
            }
            if (emp.correo == string.Empty)
            {
                ModelState.AddModelError("correo", "Debes llenar el campo");
            }
            if (emp.pass == string.Empty)
            {
                ModelState.AddModelError("pass", "Debes llenar el campo");
            }


            emp.Id = new MongoDB.Bson.ObjectId(id);
            await db.PutEmpleado(emp);

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

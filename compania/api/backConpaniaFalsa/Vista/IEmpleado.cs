using backConpaniaFalsa.Modelo;

namespace backConpaniaFalsa.Vista
{
    public interface IEmpleado
    {
        Task PostEmpleado(Empleado emp);
        Task PutEmpleado(Empleado emp);
        Task DeleteEmpleado(string id);

        Task<List<Empleado>> GetAllEmpleados();
        Task<Empleado> GetEmpleadoById(string id);
        Task<Empleado> GetLoginEmpleado(string correo, string pass);

    }
}

using backConpaniaFalsa.Modelo;

namespace backConpaniaFalsa.Vista
{
    public interface IDepartamento
    {
        Task PostDepartamento(Departamento dep);
        Task PutDepartamento(Departamento dep);
        Task DeleteDepartamento(string id);

        Task<List<Departamento>> GetAllDepartamentos();
        Task<Departamento> GetDepartamentosById(string id);



    }
}

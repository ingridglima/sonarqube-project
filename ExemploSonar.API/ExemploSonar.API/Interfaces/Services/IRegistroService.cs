using ExemploSonar.API.Entities;
using ExemploSonar.API.Services.Response;
using System.Threading.Tasks;

namespace ExemploSonar.API.Interfaces.Services
{
    public interface IRegistroService
    {
        Task<ServiceResponse<Registro>> ArmazenarRegistro(Registro registro);

        Task<ServiceResponse<Registro>> RecuperarRegistroPorId(int id);
    }
}

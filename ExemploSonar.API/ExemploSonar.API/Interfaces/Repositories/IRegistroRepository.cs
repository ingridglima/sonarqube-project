using ExemploSonar.API.Entities;
using System.Threading.Tasks;

namespace ExemploSonar.API.Interfaces.Repositories
{
    public interface IRegistroRepository
    {
        Task RegistrarCadastro(Registro registro);

        Task<bool> EmailUnico(string email);

        Task<Registro> RecuperarRegistroPorId(int id);

    }
}

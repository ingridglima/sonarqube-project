using ExemploSonar.API.Entities;
using ExemploSonar.API.Interfaces.Repositories;
using ExemploSonar.API.Interfaces.Services;
using ExemploSonar.API.Services.Response;
using System.Threading.Tasks;

namespace ExemploSonar.API.Services
{
    public class RegistroService : IRegistroService
    {
        private readonly IRegistroRepository _repository;
        public RegistroService(IRegistroRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResponse<Registro>> ArmazenarRegistro(Registro registro)
        {
            var response = new ServiceResponse<Registro>();

            if (!await _repository.EmailUnico(registro.Email)) response.AddError("Email", "Email já cadastrado!");

            if (!response.HasErrors())
            {
                await _repository.RegistrarCadastro(registro);
                response.SetResponseData(registro);
            }

            return response;


        }

        public async  Task<ServiceResponse<Registro>> RecuperarRegistroPorId(int id)
        {
            var response = new ServiceResponse<Registro>();

            var registro = await _repository.RecuperarRegistroPorId(id);

            if(registro != null)
            {
                response.SetResponseData(registro);
                return response;
            }

            response.AddError("NotFound", "Registro não encontrado!");

            return response;
        }
    }
}

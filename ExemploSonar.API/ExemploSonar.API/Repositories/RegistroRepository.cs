using ExemploSonar.API.Data;
using ExemploSonar.API.Entities;
using ExemploSonar.API.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ExemploSonar.API.Repositories
{
    public class RegistroRepository : IRegistroRepository
    {

        private readonly AppDbContext _context;

        public RegistroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> EmailUnico(string email)
        {
            var registro = await _context.Registros.FirstOrDefaultAsync(r =>
            r.Email.Equals(email));

            return registro == null;

        }

        public async Task<Registro> RecuperarRegistroPorId(int id)
        {
            return await _context.Registros.FirstOrDefaultAsync(r =>
            r.Id == id);
        }

        public async Task RegistrarCadastro(Registro registro)
        {
            await _context.AddAsync(registro);
            await _context.SaveChangesAsync();
        }
    }
}

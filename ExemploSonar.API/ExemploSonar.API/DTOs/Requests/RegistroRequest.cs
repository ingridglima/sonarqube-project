using System.ComponentModel.DataAnnotations;

namespace ExemploSonar.API.DTOs.Requests
{
    public class RegistroRequest
    {
        public string Nome { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}

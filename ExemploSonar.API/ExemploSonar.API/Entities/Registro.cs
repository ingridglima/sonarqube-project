namespace ExemploSonar.API.Entities
{
    public class Registro : Entity
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        public Registro(string nome, string email, string cidade, string estado)
        {
            Nome = nome;
            Email = email;
            Cidade = cidade;
            Estado = estado;
        }
    }
}

using ExemploSonar.API.DTOs.Requests;
using ExemploSonar.API.Validators;
using Xunit;

namespace ExemploSonar.Tests.DTOs
{
    public class RegistroRequestTests
    {
        [Fact]
        public void Validar_DadosDeEntradaRequestValidos_RetornarTrue()
        {
            // Arrange
            var request = new RegistroRequest
            {
                Nome = "Fulano Teste",
                Email = "fulano@example.com",
                Cidade = "São Paulo",
                Estado = "SP"
                
            };

            var validator = new RegistroRequestValidator();

            //Act
            var validRes = validator.Validate(request);

            //Assert
            Assert.True(validRes.IsValid);

        }

        [Theory]
        [InlineData("Fulano Teste", "", "São Paulo", "SP")]
        [InlineData(null, "fulano@example.com", "São Paulo", "SP")]
        [InlineData("Fulano Teste", "fulano", "", "SP")]
        [InlineData("Fulano Teste", "fulano@example.com", "São Paulo", null)]
        public void Validar_DadosEntradaRequestInvalidos_RetornarFalse(string nome, string email,
            string cidade, string estado)
        {
            // Arrange
            var request = new RegistroRequest
            {
                Nome = nome,
                Email = email,
                Cidade = cidade,
                Estado = estado

            };

            var validator = new RegistroRequestValidator();

            //Act
            var validRes = validator.Validate(request);

            //Assert
            Assert.False(validRes.IsValid);

        }
    }
}

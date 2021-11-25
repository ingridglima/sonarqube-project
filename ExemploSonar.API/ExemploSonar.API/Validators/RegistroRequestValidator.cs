using ExemploSonar.API.DTOs.Requests;
using FluentValidation;

namespace ExemploSonar.API.Validators
{
    public class RegistroRequestValidator : AbstractValidator<RegistroRequest>
    {

        public RegistroRequestValidator()
        {

            RuleFor(x => x.Nome)
                .NotEmpty()
                .Length(2, 100);

            RuleFor(x => x.Cidade)
                .NotEmpty()
                .Length(2, 100);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .Length(1, 50);

            RuleFor(x => x.Estado)
                .NotEmpty()
                .Length(2, 50);

        }

    }
}

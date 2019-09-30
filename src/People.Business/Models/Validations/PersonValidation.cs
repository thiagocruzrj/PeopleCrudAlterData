using FluentValidation;
using People.Business.Models.Validations.CustomValidations;

namespace People.Business.Models.Validations
{
    public class PersonValidation : AbstractValidator<Person>
    {
        public PersonValidation()
        {
            RuleFor(n => n.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser preenchido")
                .Length(3, 70).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(n => n.Email)
                .EmailRule()
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser preenchido");

            RuleFor(n => n.Birthdate)
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser preenchido");

            RuleFor(n => n.WhatsAppNumber)
                .MatchPhoneNumberRule()
                .NotEmpty().WithMessage("O campo {PropertyName} deve ser preenchido");
        }
    }
}

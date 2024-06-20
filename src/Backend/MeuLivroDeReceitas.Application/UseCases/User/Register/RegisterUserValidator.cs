using FluentValidation;
using MeuLivroDeReceitas.Communication.Requests;

namespace MeuLivroDeReceitas.Application.UseCases.User.Register;

public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(u => u.Name)
            .NotEmpty()
            .WithMessage("Nome não pode ser vazio");
            

        RuleFor(u => u.Email)
            .NotEmpty()
                .WithMessage("Email não pode ser vazio")
            .EmailAddress()
                .WithMessage("Email inválido");

        RuleFor(u => u.Password.Length)
            .GreaterThan(6)
                .WithMessage("A senha deve ter mais que 6 caractéres");
    }
}
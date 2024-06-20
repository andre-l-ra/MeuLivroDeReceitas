using MeuLivroDeReceitas.Communication.Requests;
using MeuLivroDeReceitas.Communication.Responses;
using MeuLivroDeReceitas.Exceptions.ExceptionsBase;

namespace MeuLivroDeReceitas.Application.UseCases.User.Register;

public class RegisterUserUseCase
{
    public ResponseRegisteredUserJson Execute(RequestRegisterUserJson request)
    {
        Validate(request);

        var user = new Domain.Entities.User
        {
            Name = request.Name,
            Email = request.Email,
            Password = request.Password
        };

        return new ResponseRegisteredUserJson{
            Name = request.Name,
        };
    }

    private void Validate(RequestRegisterUserJson request)
    {
        var validator = new RegisterUserValidator();
        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
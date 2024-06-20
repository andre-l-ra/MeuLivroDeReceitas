using AutoMapper;
using MeuLivroDeReceitas.Communication.Requests;
using MeuLivroDeReceitas.Domain.Entities;

namespace MeuLivroDeReceitas.Application.Services.Automapper;

public class Automapping : Profile
{
    public Automapping()
    {
    }

    private void RequestToDomain()
    {
        CreateMap<RequestRegisterUserJson, User>()
            .ForMember(dest => dest.Password, opt => opt.Ignore());
    }

    private void DomainToResponse()
    {
        //
    }
}
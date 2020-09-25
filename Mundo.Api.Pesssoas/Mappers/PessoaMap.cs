using AutoMapper;
using Mundo.Api.Pessoas.Domain;


namespace Mundo.Api.Pessoas.Mappers
{
    public class PessoaMap : Profile
    {
        public PessoaMap()
        {
            CreateMap<Domain.Pessoas, PessoasResponse>();
        }
    }
}

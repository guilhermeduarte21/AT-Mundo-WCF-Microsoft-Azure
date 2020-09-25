using AutoMapper;
using Mundo.Api.Paises.Estados.Domain;

namespace Mundo.Api.Pessoas.Mappers
{
    public class PaisMap : Profile
    {
        public PaisMap()
        {
            CreateMap<Pais, PaisResponse>();
        }
    }
}

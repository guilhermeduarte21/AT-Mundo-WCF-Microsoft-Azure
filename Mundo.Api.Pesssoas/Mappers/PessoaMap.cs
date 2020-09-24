using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

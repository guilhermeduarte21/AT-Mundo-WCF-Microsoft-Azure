﻿using System;
using System.Collections.Generic;

namespace Mundo.Api.Pesssoas.Domain.Pessoa
{
    public class PessoaResponse
    {
        public Guid Id { get; set; }
        public string UrlFoto { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataAniversario { get; set; }
        public virtual List<Pessoas> Amigos { get; set; } = new List<Pessoas>();
        public Guid Id_PaisOrigiem { get; set; }
        public Guid Id_EstadoOrigem { get; set; }
    }
}
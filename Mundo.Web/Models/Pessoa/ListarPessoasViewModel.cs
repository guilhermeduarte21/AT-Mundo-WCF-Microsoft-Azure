﻿using System;

namespace Mundo.Web.Models.Pessoa
{
    public class ListarPessoasViewModel
    {
        public Guid Id { get; set; }
        public string UrlFoto { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}

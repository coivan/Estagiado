﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estagiado.Models
{
    public class EstudanteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public string Fone { get; set; }
        public string Whatsapp { get; set; }
        public string Senha { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int CodUniversidade { get; set; }
        public string NivelAcesso { get; set; }
    }
}


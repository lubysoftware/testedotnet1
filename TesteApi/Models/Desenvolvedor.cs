﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// HEROI
namespace TesteApi.Models
{
    public class Desenvolvedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public HoraTrabalhada HoraTrabalhada { get; set; }

        public Desenvolvedor(string nome) // Construtor
        {
            this.Nome = nome;
        }
    }
}
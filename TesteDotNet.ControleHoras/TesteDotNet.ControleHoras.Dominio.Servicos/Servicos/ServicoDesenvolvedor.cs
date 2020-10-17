using System;
using System.Collections.Generic;
using System.Text;
using TesteDotNet.ControleHoras.Dominio.Core.Interfaces.Repositorios;
using TesteDotNet.ControleHoras.Dominio.Core.Interfaces.Servicos;
using TesteDotNet.ControleHoras.Dominio.Entidades;

namespace TesteDotNet.ControleHoras.Dominio.Servicos.Servicos
{
    public class ServicoDesenvolvedor : ServicoBase<Desenvolvedor>, IServicoDesenvolvedor
    {
        private readonly IRepositorioDesenvolvedor _repositorioDesenvolvedor;

        public ServicoDesenvolvedor(IRepositorioDesenvolvedor repositorioDesenvolvedor) : base(repositorioDesenvolvedor)
        {
            _repositorioDesenvolvedor = repositorioDesenvolvedor;
        }
    }
}

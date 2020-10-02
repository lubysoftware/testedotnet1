using Lançador_de_Horas_WebAPI.Models;
using System;

/// <summary>
/// Interface de registro de horas
/// </summary>
namespace Lançador_de_Horas_WebAPI.Interfaces
{
    internal interface IRegistroDeHoras
    {
        /// Identificador
        public int Id { get; set; }

        /// Data de início para registro
        public DateTime DataInicio { get; set; }

        /// Data final para registro
        public DateTime DataFim { get; set; }

        /// Desenvolvedor
        public Desenvolvedor Desenvolvedor { get; set; }
    }
}
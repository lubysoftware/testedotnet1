using System.Collections.Generic;
using PontoAPI.Domain.Models;

namespace PontoAPI.Domain.Interfaces

{
    public interface IDesenvolvedorRepository
    {
         bool CreateDesenvolvedor(Desenvolvedor desenvolvedor);

         string GetDesenvolvedor(int desenvolvedorID);

         bool DeleteDesenvolvedor(int desenvolvedorID);

         bool EditDesenvolvedor(Desenvolvedor desenvolvedor);
    }
}
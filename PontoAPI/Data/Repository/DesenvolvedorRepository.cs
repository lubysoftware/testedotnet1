using System;
using PontoAPI.Domain.Interfaces;
using PontoAPI.Domain.Models;
using System.Linq;
using Newtonsoft.Json;

namespace PontoAPI.Data.Repository
{
    public class DesenvolvedorRepository : IDesenvolvedorRepository
    {
        private readonly PontoContext dbContext;
        public DesenvolvedorRepository(PontoContext context)
        {
            dbContext = context;
        }

        public bool CreateDesenvolvedor(Desenvolvedor desenvolvedor)
        {
            try
            {
                desenvolvedor.DataCadastro = DateTime.Now;
                desenvolvedor.Ativo = true;
                dbContext.DesenvolvedorSet.Add(desenvolvedor);
                dbContext.SaveChanges();

                return true;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetDesenvolvedor(int desenvolvedorID)
        {
            try
            {
                var desenvolvedor = dbContext.DesenvolvedorSet.Where(t => t.DesenvolvedorID == desenvolvedorID).ToList();
                var jsonString = JsonConvert.SerializeObject(desenvolvedor);

                return jsonString;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteDesenvolvedor(int desenvolvedorID)
        {
            try
            {
                var desenvolvedor = dbContext.DesenvolvedorSet.Where(t => t.DesenvolvedorID.Equals(desenvolvedorID) && t.Ativo.Equals(true)).FirstOrDefault();

                desenvolvedor.Ativo = false;
                dbContext.SaveChanges();

                return true;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EditDesenvolvedor(Desenvolvedor desenvolvedor)
        {
            try
            {
                dbContext.DesenvolvedorSet.Update(desenvolvedor);
                dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
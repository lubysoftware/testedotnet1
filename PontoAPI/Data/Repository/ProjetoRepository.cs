using System;
using PontoAPI.Domain.Interfaces;
using PontoAPI.Domain.Models;
using System.Linq;
using Newtonsoft.Json;

namespace PontoAPI.Data.Repository
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly PontoContext dbContext;

        public ProjetoRepository(PontoContext context)
        {
            dbContext = context;
        }

        public bool CreateProjeto(Projeto projeto)
        {
            try
            {
                projeto.DataCadastro = DateTime.Now;
                projeto.Ativo = true;
                dbContext.ProjetoSet.Add(projeto);
                dbContext.SaveChanges();

                return true;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetProjeto(int projetoID)
        {
            try
            {
                var projeto = dbContext.ProjetoSet.Where(t => t.ProjetoID.Equals(projetoID)).ToList();
                var jsonString = JsonConvert.SerializeObject(projeto);

                return jsonString;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteProjeto(int projetoID)
        {
            try
            {
                var projeto = dbContext.ProjetoSet.Where(t => t.ProjetoID.Equals(projetoID) && t.Ativo.Equals(true)).FirstOrDefault();

                projeto.Ativo = false;
                dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool EditProjeto(Projeto projeto)
        {
            try
            {
                dbContext.ProjetoSet.Update(projeto);
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
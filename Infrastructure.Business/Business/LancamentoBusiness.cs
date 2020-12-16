using Domain;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Business
{
    public class LancamentoBusiness
    {
        LancamentoRepository repository = new LancamentoRepository();
        public Lancamento Add(Lancamento g)
        {
            if (g != null)
            {
                try
                {
                    repository.Add(g);
                    repository.Commit();
                    repository.Dispose();
                }
                catch (Exception e)
                {
                    throw;
                }
            }

            return g;
        }

        public Lancamento Update(Lancamento g)
        {
            if (g != null)
            {
                try
                {
                    repository.Update(g);
                    repository.Commit();
                    repository.Dispose();
                }
                catch (Exception e)
                {
                    throw;
                }
            }

            return g;
        }

        public void Delete(Lancamento g)
        {
            if (g != null)
            {
                try
                {
                    repository.Delete(g);
                    repository.Commit();
                    repository.Dispose();
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }

        public List<Lancamento> GetAll()
        {
            List<Lancamento> ls = repository.GetAll().ToList();
            return ls;
        }

        public Lancamento GetAllById(int id)
        {
            Lancamento g = repository.GetAll().Where(x => x.Id == id).FirstOrDefault();
            return g;
        }
    }
}

using Domain;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Business
{
    public class DesenvolvedorBusiness
    {
        DesenvolvedorRepository repository = new DesenvolvedorRepository();

        public Desenvolvedor Add(Desenvolvedor g)
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

        public Desenvolvedor Update(Desenvolvedor g)
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

        public void Delete(Desenvolvedor d)
        {
            if (d != null)
            {
                try
                {
                    repository.Delete(d);
                    repository.Commit();
                    repository.Dispose();
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }

        public List<Desenvolvedor> GetAll()
        {
            List<Desenvolvedor> ls = repository.GetAll().ToList();
            return ls;
        }

        public Desenvolvedor GetAllById(int id)
        {
            Desenvolvedor g = repository.GetAll().Where(x => x.Id == id).FirstOrDefault();
            return g;
        }
    }
}

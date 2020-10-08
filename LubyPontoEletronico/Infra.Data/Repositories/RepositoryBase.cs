using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly Context _con;

        public RepositoryBase(Context con)
            : base()
        {
            _con = con;
        }

        public void Create(TEntity entity)
        {
            _con.InitTransacao();
            _con.Set<TEntity>().Add(entity);
            _con.SendChanges();
        }

        public void CreateRange(List<TEntity> entities)
        {
            _con.InitTransacao();
            _con.Set<TEntity>().AddRange(entities);
            _con.SendChanges();
        }

        public List<TEntity> GetAll()
        {
            return _con.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _con.Set<TEntity>().Find(id);
        }

        public void Remove(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _con.InitTransacao();
                _con.Set<TEntity>().Remove(entity);
                _con.SendChanges();
            }
        }

        public void Remove(TEntity entity)
        {
            _con.InitTransacao();
            _con.Set<TEntity>().Remove(entity);
            _con.SendChanges();
        }

        public void RemoveRange(List<TEntity> entities)
        {
            _con.InitTransacao();
            _con.Set<TEntity>().RemoveRange(entities);
            _con.SendChanges();
        }

        public void Update(TEntity entity)
        {
            _con.InitTransacao();
            _con.Set<TEntity>().Attach(entity);
            _con.Entry(entity).State = EntityState.Modified;
            _con.SendChanges();
        }

        public void UpdateRange(List<TEntity> entities)
        {
            _con.InitTransacao();
            _con.Set<TEntity>().AttachRange(entities);
            _con.Entry(entities).State = EntityState.Modified;
            _con.SendChanges();
        }
    }
}

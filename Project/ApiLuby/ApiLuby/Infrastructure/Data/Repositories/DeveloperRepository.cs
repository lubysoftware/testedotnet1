using ApiLuby.Business.Entities;
using ApiLuby.Business.Entities.Repositories;
using System;
using System.Linq;

namespace ApiLuby.Infrastructure.Data.Repositories
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly BankOfHoursDbContext _context;

        public DeveloperRepository(BankOfHoursDbContext context)
        {
           _context = context;
        }

        public void Add(Developer developer)
        {
          _context.Developer.Add(developer);
           
        }

        public void Commit()
        {
           _context.SaveChanges();
        }

        public Developer GetDeveloper(string login)
        {
           return  _context.Developer.FirstOrDefault(u => u.Login == login);
        }
    }
}

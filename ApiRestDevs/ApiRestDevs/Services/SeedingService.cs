using ApiRestDevs.Data;
using ApiRestDevs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDevs.Services
{
    public class SeedingService
    {
        private readonly DataContext _context;

        public SeedingService(DataContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Users.Any())
            {
                return; // Banco de dados ja foi Populado
            }

            var u1 = new User
            {
                Id = 1,
                Username = "teste",
                Password = "teste",
                Role = "all"
            };

            _context.Add(u1);
            _context.SaveChanges();

        }

    }
}

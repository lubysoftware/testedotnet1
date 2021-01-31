using ApiLuby.Business.Entities;
using ApiLuby.Business.Entities.Repositories;
using ApiLuby.Configurations;
using ApiLuby.Models;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLuby.Infrastructure.Data.Repositories
{
    public class BankOfHoursRepository : IBankOfHoursRepository
    {


       BankOfHoursDbContext _context;

        public BankOfHoursRepository()
        {
        }

        public BankOfHoursRepository(BankOfHoursDbContext context)
        {
            _context = context;
        }

        public void Add(BankOfHours bankOfHours)
        {
            _context.BankOfHours.Add(bankOfHours);
        }


        public void Commit()
        {
            _context.SaveChanges();
        }

        public IList<BankOfHours> GetPerDeveloper(int codigoDeveloper) //return _context.BankOfHours.Where(w => w.TotalHours) OrderByDescending()posso usar algo assim aq pra bvuscar o rank
        {
            return _context.BankOfHours.Include(i => i.Developer).Where(w => w.CodigoDeveloper == codigoDeveloper).ToList();
        }

        public IList<BankOfHours> GetRank(int codigoDeveloper)
        {
            var listHoras = _context.BankOfHours.Include(i => i.Developer).Where(w => w.TotalHours > 0).ToList();

            return _context.BankOfHours.Include(i => i.Developer).Where(w => w.TotalHours > 0).ToList();

        }

        public List<BankOfHoursVM> GetTotalHours(int developerCode)
        {
            List<BankOfHoursVM> data = new List<BankOfHoursVM>();

            string sql = "stp_SelRankingHoras";

            DynamicParameters parameters = new DynamicParameters();

       

            using (var conn = DbFactoryBcContext.FactoryNewConnection(true))
            {
                data = conn.Query<BankOfHoursVM>(sql, parameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
            }

            return data;
        }

    }
}


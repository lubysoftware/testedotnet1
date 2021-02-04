using apiLuby.Context;
using apiLuby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace apiLuby.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly MSSQLContext context;

        private DbSet<Appointment> appointmentContext;

        public AppointmentsController(MSSQLContext context)
        {
            this.context = context;
            this.appointmentContext = this.context.Set<Appointment>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var res = await appointmentContext.ToListAsync();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
            var appointment = await appointmentContext.FindAsync(id);
            return Ok(appointment);
        }

        [HttpPost]
        public async Task<IActionResult> PostAppointment([FromBody] Appointment appointment)
        {
            await appointmentContext.AddAsync(appointment);
            await context.SaveChangesAsync();
            return Ok(appointment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Appointment>> PutAppointment(int id, [FromBody] Appointment appointment)
        {
            if (appointment.Id != id)
            {
                return BadRequest();
            }

            context.Entry(appointment).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
                return Ok(appointment);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Appointment>> DeleteAppointment(int id)
        {
            var appointment = await appointmentContext.FindAsync(id);

            if(appointment == null)
            {
                return NotFound();
            }

            appointmentContext.Remove(appointment);
            await context.SaveChangesAsync();
            return Ok(appointment);
        }

        [HttpGet("/Ranking")]
        public ActionResult<Appointment> Ranking()
        {
            return Ok(Teste(DateTime.Today, DateTime.Today.AddDays(-7)));
        }

        private object Teste(DateTime inicial, DateTime final)
        {
            var result = (from c in appointmentContext
                         where c.FinishedAt <= inicial && c.FinishedAt >= new DateTime(final.Year, final.Month, final.Day, 23, 59, 59)
                         select new { c.IdDeveloper, c.Developer.Name, c.FinishedAt, c.StartedAt })
                         .ToList()
                         .GroupBy(c => new { c.IdDeveloper, c.Name })
                         .Select(c => new { c.Key.IdDeveloper, c.Key.Name, hours = c.Select(d => (d.FinishedAt - d.StartedAt).TotalHours).Sum(),
                             hoursStr = c.Select(d => (d.FinishedAt - d.StartedAt).TotalHours).Sum().ToString("F2")
                         })
                         .OrderByDescending(c => c.hours)
                         .ToList()
                         .Take(5);

            return result;
        }
    }
}

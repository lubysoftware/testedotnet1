using apiLuby.Context;
using apiLuby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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
    }
}

using LubySoftware.Domain.Models;
using LubySoftware.Domain.Repositories;
using System.Threading.Tasks;

namespace LubySoftware.RegisterHours.Services
{
    public class RegisterService
    {
        readonly IRegisterHoursRepository RegisterHoursRepository;

        public RegisterService(IRegisterHoursRepository registerHoursRepository)
        {
            RegisterHoursRepository = registerHoursRepository;
        }

        public async Task Save(RegisterHourModel registerHour)
        {
            await RegisterHoursRepository.Save(registerHour);
        }

        public async Task<RegisterHourModel> Find(long id)
        {
            return await RegisterHoursRepository.Find(id);
        }

        public async Task Delete(long id)
        {
            await RegisterHoursRepository.Delete(id);
        }

        public async Task Update(RegisterHourModel registerHour)
        {
            await RegisterHoursRepository.Update(registerHour);
        }
    }
}

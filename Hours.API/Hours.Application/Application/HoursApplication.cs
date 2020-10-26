using AutoMapper;
using Hours.Application.DataContract.Request.Hours;
using Hours.Application.DataContract.Response;
using Hours.Application.DataContract.Response.Base;
using Hours.Application.DataContract.Response.Hours;
using Hours.Application.Interface;
using Hours.Domain.Entities;
using Hours.Domain.Filters;
using Hours.Domain.Interfaces.Services.Hours;
using Hours.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hours.Application.Application
{
    public class HoursApplication : IHoursApplication
    {
        private readonly IMapper _mapper;
        private readonly IHoursService _hoursService;

        public HoursApplication(IMapper mapper, IHoursService hoursServices
            )
        {
            _mapper = mapper;
            _hoursService = hoursServices;
        }    

        public async Task<Response<List<HoursGeneralResponse>>> GetAllAsync()
        {
            var data = await _hoursService.GetAllAsync();

            return new Response<List<HoursGeneralResponse>>(_mapper.Map<List<HoursGeneralResponse>>(data));          
        }

        public async Task<Response<List<HoursGeneralResponse>>> GetAsync(HoursFilterRequest filter)
        {
            var result = _mapper.Map<HoursFilters>(filter);

            var data = await _hoursService.GetAsync(result);

            return new Response<List<HoursGeneralResponse>>(_mapper.Map<List<HoursGeneralResponse>>(data));
        }

        public async Task<Response<HoursGeneralResponse>> GetByIdAsync(Guid id)
        {
            var data = await _hoursService.GetByIdAsync(id);

            return new Response<HoursGeneralResponse>(_mapper.Map<HoursGeneralResponse>(data));
        }

        public async Task<Response<List<HoursRankingResponse>>> GetRankingDevsAsync()
        {
            var data = await _hoursService.GetRankingDevsAsync();

            return new Response<List<HoursRankingResponse>>(_mapper.Map<List<HoursRankingResponse>>(data));
        }

        public async Task<Response> SaveAsync(HoursRequest request)
        {
            var response = new Response();

            var data = _mapper.Map<HoursEntity>(request);

            var validation = new HoursValidator();

            var result = validation.Validate(data);
            if (!result.IsValid)
            {
                foreach (var erro in result.Errors)
                    response.Reports.Add(new Reports { Code = erro.PropertyName, Message = erro.ErrorMessage });

                 return response;
            }

            await _hoursService.SaveAsync(data);  

            return response;
        }

        public async Task<Response> UpdateAsync(HoursRequest request)
        {
            var response = new Response();

            var data = _mapper.Map<HoursEntity>(request);

            var validation = new HoursValidator();

            var result = validation.Validate(data);
            if (!result.IsValid)
            {
                foreach (var erro in result.Errors)
                    response.Reports.Add(new Reports { Code = erro.PropertyName, Message = erro.ErrorMessage });

                return response;
            }

            await _hoursService.UpdateAsync(data);

            return response;
        }

        public async Task<Response> DeleteAsync(Guid id)
        {
            var response = new Response();

            var dataHours = _hoursService.GetByIdAsync(id);
            if (dataHours == null)
                response.Reports.Add(new Reports { Code = id.ToString(), Message = "There is no registration with the code." });

            await _hoursService.DeleteAsync(id);

            return response;
        }
    }
}
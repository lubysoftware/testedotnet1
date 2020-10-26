using Hours.Application.DataContract.Request.Hours;
using Hours.Application.DataContract.Response;
using Hours.Application.DataContract.Response.Hours;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hours.Application.Interface
{
    public interface IHoursApplication
    {
        Task<Response> SaveAsync(HoursGeneralRequest data);
        Task<Response> UpdateAsync(HoursRequest data);
        Task<Response> DeleteAsync(Guid id);
        Task<Response<HoursGeneralResponse>> GetByIdAsync(Guid id);
        Task<Response<List<HoursGeneralResponse>>> GetAsync(HoursFilterRequest filters);
        Task<Response<List<HoursGeneralResponse>>> GetAllAsync();
        Task<Response<List<HoursRankingResponse>>> GetRankingDevsAsync();
    }
}
using Hours.Application.DataContract.Request.User;
using Hours.Application.DataContract.Response;
using Hours.Application.DataContract.Response.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace User.Application.Interface
{
    public interface IUserApplication
    {
        Task<Response> SaveAsync(UserRequest data);
        Task<Response> UpdateAsync(UserRequest data);
        Task<Response> DeleteAsync(Guid id);
        Task<Response<UserResponse>> GetByIdAsync(Guid id);
        Task<Response<List<UserResponse>>> GetAsync(UserFilterRequest filters);
        Task<Response<List<UserResponse>>> GetAllAsync();
    }
}
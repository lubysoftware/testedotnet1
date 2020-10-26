using AutoMapper;
using Hours.Application.DataContract.Request.User;
using Hours.Application.DataContract.Response;
using Hours.Application.DataContract.Response.User;
using Hours.Domain.Entities;
using Hours.Domain.Filters;
using Hours.Domain.Interfaces.Services.User;
using Hours.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using User.Application.Interface;
using Hours.Application.DataContract.Response.Base;

namespace User.Application.Application
{
    public class UserApplication : IUserApplication
    {
        private readonly IMapper _mapper;
        private readonly IUserService _UserService;

        public UserApplication(IMapper mapper, IUserService UserServices
            )
        {
            _mapper = mapper;
            _UserService = UserServices;
        }    

        public async Task<Response<List<UserResponse>>> GetAllAsync()
        {
            var data = await _UserService.GetAllAsync();

            return new Response<List<UserResponse>>(_mapper.Map<List<UserResponse>>(data));          
        }

        public async Task<Response<List<UserResponse>>> GetAsync(UserFilterRequest filter)
        {
            var result = _mapper.Map<UserFilters>(filter);

            var data = await _UserService.GetAsync(result);

            return new Response<List<UserResponse>>(_mapper.Map<List<UserResponse>>(data));
        }

        public async Task<Response<UserResponse>> GetByIdAsync(Guid id)
        {
            var data = await _UserService.GetByIdAsync(id);

            return new Response<UserResponse>(_mapper.Map<UserResponse>(data));
        }      

        public async Task<Response> SaveAsync(UserRequest request)
        {
            var response = new Response();

            var data = _mapper.Map<UsersEntity>(request);

            var validation = new UserValidator();

            var result = validation.Validate(data);
            if (!result.IsValid)
            {
                foreach (var erro in result.Errors)
                    response.Reports.Add(new Reports { Code = erro.PropertyName, Message = erro.ErrorMessage });

                 return response;
            }

            await _UserService.SaveAsync(data);  

            return response;
        }

        public async Task<Response> UpdateAsync(UserRequest request)
        {
            var response = new Response();

            var data = _mapper.Map<UsersEntity>(request);

            var validation = new UserValidator();

            var result = validation.Validate(data);
            if (!result.IsValid)
            {
                foreach (var erro in result.Errors)
                    response.Reports.Add(new Reports { Code = erro.PropertyName, Message = erro.ErrorMessage });

                return response;
            }

            await _UserService.UpdateAsync(data);

            return response;
        }

        public async Task<Response> DeleteAsync(Guid id)
        {
            var response = new Response();

            var dataUser = _UserService.GetByIdAsync(id);
            if (dataUser == null)
                response.Reports.Add(new Reports { Code = id.ToString(), Message = "There is no registration with the code." });

            await _UserService.DeleteAsync(id);

            return response;
        }
    }
}
using Hours.Application.DataContract.Response;
using Hours.Application.DataContract.Response.User;
using System.Threading.Tasks;

namespace User.Application.Interface
{
    public interface ILoginApplication
    {
        Task<Response<object>> FindByLoginAsync(LoginResponse data);
    }
}
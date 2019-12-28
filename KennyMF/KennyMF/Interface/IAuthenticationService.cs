using KennyMF.Models.HttpResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KennyMF.Interface
{
    public interface IAuthenticationService
    {
        Task<HttpResponse<LoginResponse>> Login(string email, string password);
    }
}

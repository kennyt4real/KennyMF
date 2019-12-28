using KennyMF.Interface;
using KennyMF.Models.HttpResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KennyMF.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationService()
        {

        }
        public Task<HttpResponse<LoginResponse>> Login(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}

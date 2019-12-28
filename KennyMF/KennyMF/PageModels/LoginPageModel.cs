using KennyMF.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace KennyMF.PageModels
{
    public class LoginPageModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public ICommand LoginCmd { get; set; }

        private readonly IAuthenticationService _authenticationService;
        
    }
}

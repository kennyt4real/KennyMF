using System;
using System.Collections.Generic;
using System.Text;

namespace KennyMF.Entities
{
    public class Login : BaseEntity
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}

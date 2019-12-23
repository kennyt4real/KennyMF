using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace KennyMF.Services
{
    public static class ConnectionService
    {
        public static bool HasInternetAccess()
        {
            var current = Connectivity.NetworkAccess;
            if(current== NetworkAccess.Internet)
            {
                return true;
            }
            return false;
        }
    }
}

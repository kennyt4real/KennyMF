using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace KennyMF
{
    public static class AppConfig
    {
        public const string BaseEndPoint = "https://dev.cforce.live/api";
        public const string BaseEndPointDev = "https://mt-netcore-api-sandbox.azuewebsites.net/api";

        public static string FormsEndPoint
        {
            get
            {
                string val = BaseEndPoint + "/form";
                return val;
            }
        }
        public static string RecordsEndPoint
        {
            get
            {
                string val = BaseEndPoint + "/record";
                return val;
            }
        }

        public static string RecordsUploadEndPoint
        {
            get
            {
                string val = BaseEndPoint + "/user/register";
                return val;
            }
        }

        public static string UserEndPoint
        {
            get
            {
                string val = BaseEndPoint + "/user";
                return val;
            }
        }

        public static string PasswordRecoveryEndPoint
        {
            get
            {
                string val = BaseEndPoint + "user/forgotpassword";
                return val;
            }
        }

        public static string GetLocalEndpointForPlatform()
        {
            if (Device.RuntimePlatform == Device.Android)
                return "http://10.0.2.2:5001/api";
            else if (Device.RuntimePlatform == Device.iOS)
                return "http://localhost:5001/api";
            else throw new NotSupportedException("Platform is not supported.");
        }
    }
}

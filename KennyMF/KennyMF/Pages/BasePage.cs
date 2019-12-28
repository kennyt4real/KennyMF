using Acr.UserDialogs;
using KennyMF.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace KennyMF.Pages
{
    public class BasePage : ContentPage
    {
        private static bool _subscribed = false;
        public BasePage()
        {
            if (!_subscribed)
            {
                MessagingCenter.Subscribe<HttpService>(this, "NONETWORKACCESS", (sender) =>
                {
                    UserDialogs.Instance.Alert("You need Internet access for this action", "Error, No Internet", "Close");
                });

                //MessagingCenter.Subscribe<HttpService>(this, "SESSIONEXPIRED", (sender) =>
                //{
                //    UserDialogs.Instance.Alert("Your session has expired, please login");
                //})
                _subscribed = true;
            }
        }
    }
}

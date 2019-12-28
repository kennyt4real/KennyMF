using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using KennyMF.Interface;

namespace KennyMF.Droid.Services
{
    public class NativeNavigationService : INativeNavigationService
    {
        public void CloseAppication()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}
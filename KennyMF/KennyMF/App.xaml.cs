using DLToolkit.Forms.Controls;
using KennyMF.Data;
using KennyMF.Entities;
using KennyMF.Services;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KennyMF
{
    public partial class App : Application
    {
        public static int ScreenHeight { get; set; }
        public static int ScreenWidth { get; set; }
        public IContainer Container { get; }
        public string Token { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Team CurrentTeam { get; set; }
        public Form CurrentForm { get; set; }

        static Database dataBase;
        public static INavigation Nav { get; set; }
        public App(Module module) 
        {
            RegisterSyncfusion();
            InitializeComponent();
            FlowListView.Init();


            Container = BuilContainer(module);

            var localUser = Database.GetItemsAsync<LocalUser>()
                .GetAwaiter().GetResult()?
                .OrderByDescending(i => i.Id)
                .FirstOrDefault();

            if (localUser != null)
                Email = localUser?.Email;

            if (Email == string.Empty)
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                if (ConnectionService.HasInternetAccess())
                {
                    Login login = Database.GetItemsAsync<Login>()
                        .GetAwaiter().GetResult()?
                        .OrderByDescending(i => i.Id)
                        .FirstOrDefault();

                    if(login==null|| login.CreatedAt < DateTime.Now.AddDays(-29))
                    {
                        MainPage = new NavigationPage(new LoginPage());
                    }
                    else
                    {
                        Token = login.AccessToken;
                        MainPage = (new LoginPage());
                    }
                }
                else
                {
                    MainPage = new TeamPage();
                }
            }

            Nav = MainPage.Navigation;
        }

        private static Database Database
        {
            get
            {
                if (dataBase == null)
                {
                    dataBase = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MicroTaskDb.db3"));
                }
                return dataBase;
            }
        }

        private IContainer BuilContainer(Module module)
        {
            var builder = new ContainerBuilder();
        }

        private void RegisterSyncfusion()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTAzMjM2QDMxMzcyZTMxMmUzMGlscFNBNDUrSmdmaWlRMm9IdFVadFRFSlRndFhkVlNpQ0tTVXo0c3lOYVE9");

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

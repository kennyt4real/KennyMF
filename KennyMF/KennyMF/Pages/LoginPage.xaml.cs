using Autofac;
using KennyMF.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KennyMF.Pages
{
#if RELEASE
    [XamlCompilation(XamlCompilationOptions.Compile)]
#endif
    public partial class LoginPage : BasePage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = (Application.Current as App).Container.Resolve<LoginPageModel>();

        }
    }
}
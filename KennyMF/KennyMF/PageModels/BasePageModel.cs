using KennyMF.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace KennyMF.PageModels
{
    public class BasePageModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected readonly NavigationService NavigationService;
        public BasePageModel(NavigationService navigationService)
        {
            NavigationService = navigationService;
        }
        //public virtual Task Initialize
    }
}

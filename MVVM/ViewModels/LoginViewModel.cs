using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace AuthenticationTesting2.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel 
    {
        //Propertys
        public LoginFormViewModel LoginFormViewModel { get; }

        //Constructor
        public LoginViewModel(LoginFormViewModel loginFormViewModel)
        {
            LoginFormViewModel = loginFormViewModel;
        }
    }
}

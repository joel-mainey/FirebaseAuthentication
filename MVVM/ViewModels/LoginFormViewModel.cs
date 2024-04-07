using AuthenticationTesting2.MVVM.Services;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using PropertyChanged;

namespace AuthenticationTesting2.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class LoginFormViewModel 
    {
        //Propertys
        public string Email { get; set; }
        public string Password { get; set; }

        //Login command
        public ICommand LoginService { get; }

        //Constructor
        public LoginFormViewModel(FirebaseAuthClient authClient)
        {
            var loginService = new LoginService(this, authClient);
            LoginService = new RelayCommand(async () => await loginService.Execute());
        }
    }
}

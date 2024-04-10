using System;
using System.Windows.Input;
using AuthenticationTesting2.MVVM.Models;
using AuthenticationTesting2.MVVM.Services;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using PropertyChanged;

namespace AuthenticationTesting2.MVVM.ViewModels
{
    // Represents the view model for the login view
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel 
    {
        // Model for user login data
        public LoginModel Users { get; set; }

        // Command for login action
        public ICommand LoginService { get; }

        // Constructor
        public LoginViewModel()
        {
            // Initialize the login model
            Users = new LoginModel();  

            // Create an instance of login service
            var loginService = new LoginService(Users);

            // Assign command to execute login service
            LoginService = new RelayCommand(async () => await loginService.Execute());
        }
    }
}

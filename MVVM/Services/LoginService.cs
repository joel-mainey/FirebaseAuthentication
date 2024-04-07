using AuthenticationTesting2.MVVM.ViewModels;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationTesting2.MVVM.Services
{
    public class LoginService 
    {
        //Propertys
        private readonly LoginFormViewModel _viewModel;
        private readonly FirebaseAuthClient _authclient;

        //Constructor
        public LoginService(LoginFormViewModel viewModel, FirebaseAuthClient authclient)
        {
            _viewModel = viewModel;
            _authclient = authclient;
        }

        //Logs in user with firebase auth client
        public async Task Execute()
        {
            try
            {
                //Gets email and password from viewmodel
                await _authclient.SignInWithEmailAndPasswordAsync(_viewModel.Email, _viewModel.Password);

                await Application.Current.MainPage.DisplayAlert("Success", "Successfully logged in!", "Ok");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging in: {ex.Message}");

                await Application.Current.MainPage.DisplayAlert("Error", "Failed to Log in. Please try again later.", "Ok");
            }

        }
    }
}

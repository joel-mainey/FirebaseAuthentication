using AuthenticationTesting2.MVVM.ViewModels;
using Firebase.Auth;
using System;
using AuthenticationTesting2.MVVM.Models;

namespace AuthenticationTesting2.MVVM.Services
{
    // Service responsible for handling login functionality
    public class LoginService 
    {
        // Property to hold the login model
        public LoginModel LoginModel;

        // Constructor
        public LoginService(LoginModel loginModel)
        {
            // Initialize LoginModel property
            LoginModel = loginModel;
        }

        // Logs in user with firebase auth client
        public async Task Execute()
        {
            try
            {
                // Attempt to sign in with email and password
                await LoginModel.AuthClient.SignInWithEmailAndPasswordAsync(LoginModel.Emails, LoginModel.Password);

                // Display success message if login is successful
                await Application.Current.MainPage.DisplayAlert("Success", "Successfully logged in!", "Ok");
            }
            catch (Exception ex)
            {
                // Display error message if login fails
                Console.WriteLine($"Error logging in: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error", "Error logging in, please try again later.", "Ok");
            }

        }
    }
}

using AuthenticationTesting2.MVVM.ViewModels;
using Firebase.Auth;
using AuthenticationTesting2.MVVM.Services;
using Firebase.Auth.Providers;
using AuthenticationTesting2.MVVM.Models;

namespace AuthenticationTesting2.MVVM.Views;

public partial class LoginView : ContentPage
{
    // Sets binding context for login page
    public LoginView()
	{
		InitializeComponent();
		
		// Create instance of loginViewModel and set as BindingContext
		LoginViewModel viewModel = new LoginViewModel();
		BindingContext = viewModel;
	}
}
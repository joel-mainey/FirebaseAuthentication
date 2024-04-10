using AuthenticationTesting2.MVVM.ViewModels;

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
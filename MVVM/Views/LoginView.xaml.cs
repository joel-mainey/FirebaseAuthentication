namespace AuthenticationTesting2.MVVM.Views;

public partial class LoginView : ContentPage
{
	//Sets binding context for login page
	public LoginView(object bindingContext)
	{
		InitializeComponent();
		BindingContext = bindingContext;
	}
}
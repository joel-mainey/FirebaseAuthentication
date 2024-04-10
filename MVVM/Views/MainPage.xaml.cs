using AuthenticationTesting2.MVVM.ViewModels;
using AuthenticationTesting2.MVVM.Services;
using Firebase.Auth;

namespace AuthenticationTesting2.MVVM.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    //Navigates from mainpage to login page
    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginView());
    }
}

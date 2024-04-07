using AuthenticationTesting2.MVVM.ViewModels;
using AuthenticationTesting2.MVVM.Views;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Microsoft.Extensions.Logging;

namespace AuthenticationTesting2
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddTransient<LoginFormViewModel>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<LoginView>(
                s => new LoginView(s.GetRequiredService<LoginViewModel>()));

            try
            {
                //Connecting to firebase authentication
                builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
                {
                    ApiKey = "AIzaSyCXqyEDIS6fjLFy6d8dnqMnOb9nDCq1in4",
                    AuthDomain = "hukutaia-domain.firebaseapp.com",
                    Providers = new FirebaseAuthProvider[]
                    {
                    new EmailProvider()
                    }
                }));
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error connecting to firebase: {ex.Message}");
            }


#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

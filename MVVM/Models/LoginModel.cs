using Firebase.Auth;
using Firebase.Auth.Providers;
using System;

namespace AuthenticationTesting2.MVVM.Models
{
    // Represents the model for user login data
    public class LoginModel
    {
        // Properties to hold user's email and password
        public string? Emails { get; set; }
        public string? Password { get; set; }


        // Firebase authentication client
        public FirebaseAuthClient AuthClient = new FirebaseAuthClient(new FirebaseAuthConfig()
        {
            // Configuration for Firebase authentication
            ApiKey = "AIzaSyCXqyEDIS6fjLFy6d8dnqMnOb9nDCq1in4",
            AuthDomain = "hukutaia-domain.firebaseapp.com",
            Providers = new FirebaseAuthProvider[]
        {
           // Provider for email authentication
           new EmailProvider()
        }
        });

    }
}

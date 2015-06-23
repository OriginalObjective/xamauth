using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Xamarin.Forms;
using FacebookContacts;
using FacebookContacts.WinPhone;
using Xamarin.Forms.Platform.WinPhone;
using Xamarin.Auth;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
namespace FacebookContacts.WinPhone
{
    public partial class LoginPageRenderer : PageRenderer
    {
        public LoginPageRenderer()
        {
            var auth = new OAuth2Authenticator
            (
            clientId: "YOUR_OAUTH2_CLIENT_ID",
            scope: "WHAT_ARE_YOU_ACCESSING_DELIMITED_+_SYMBOLS",
            authorizeUrl: new Uri("AUTH_URL_FOR_SERVICE"),
            redirectUrl: new Uri("REDIRECT_URL_FOR_THE_SERVICE")
            );
            auth.Completed += (sender, eventArgs) =>
            {
                FacebookContacts.App.SuccessfulLoginAction.Invoke();
                if (eventArgs.IsAuthenticated)
                    FacebookContacts.App.SaveFacebookToken(eventArgs.Account.Properties["access_token"]);
                else
                {
                    // cancelled
                }
            };

            MainPage.StaticMainPage.NavigationService.Navigate(auth.GetUI());
        }
    }
}

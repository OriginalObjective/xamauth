using System;
using Xamarin.Forms;
using FacebookContacts;
using FacebookContacts.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
namespace FacebookContacts.iOS
{
    public class LoginPageRenderer : PageRenderer
    {
        bool IsShown;

        public override void ViewDidAppear(bool animated)
        {
            if (!IsShown)
            {
                IsShown = true;
                base.ViewDidAppear(animated);

                var auth = new OAuth2Authenticator(
                               clientId: "YOUR_OAUTH2_CLIENT_ID",
                               scope: "WHAT_ARE_YOU_ACCESSING_DELIMITED_+_SYMBOLS",
                               authorizeUrl: new Uri("AUTH_URL_FOR_SERVICE"),
                               redirectUrl: new Uri("REDIRECT_URL_FOR_THE_SERVICE")
                           );
                auth.Completed += (sender, eventArgs) =>
                {
                    App.SuccessfulLoginAction.Invoke();
                    if (eventArgs.IsAuthenticated)
                        App.SaveFacebookToken(eventArgs.Account.Properties["access_token"]);
                    else
                    {
                        // cancelled
                    }
                };

                PresentViewController(auth.GetUI(), true, null);
            }
        }
    }
}


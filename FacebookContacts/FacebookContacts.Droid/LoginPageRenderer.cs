using System;
using Android.App;
using FacebookContacts;
using FacebookContacts.Droid;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(LoginPage), typeof(LoginPageRenderer))]
namespace FacebookContacts.Droid
{
    public class LoginPageRenderer : PageRenderer
    {
        protected override void OnModelChanged(VisualElement oldModel, VisualElement newModel)
        {
            //base.OnModelChanged(oldModel, newModel);
            var activity = this.Context as Activity;
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

            activity.StartActivity(auth.GetUI((activity)));
        }
    }
}


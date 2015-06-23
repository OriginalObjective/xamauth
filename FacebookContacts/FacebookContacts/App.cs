using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FacebookContacts
{
    public class App : Application
    {
        static NavigationPage NavPage;
        static string FacebookToken;

        public static bool IsLoggedIn
        {
            get { return !string.IsNullOrWhiteSpace(FacebookToken); }
        }

        public static string Token
        {
            get { return FacebookToken; }
        }

        public static void SaveFacebookToken(string token)
        {
            FacebookToken = token;
        }

        public static Action SuccessfulLoginAction
        {
            get
            {
                return new Action(() =>
                  {
                      NavPage.Navigation.PopModalAsync();
                  });
            }
        }
        public static Page GetMainPage()
        {
            NavPage = new NavigationPage(new ProfilePage());
            return NavPage;
        }
        public App()
        {
            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						}
					}
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

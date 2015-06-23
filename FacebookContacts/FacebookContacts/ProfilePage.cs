using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace FacebookContacts
{

    public class BaseContentPage : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!App.IsLoggedIn)
                Navigation.PushModalAsync(new LoginPage());
        }
    }
    public class ProfilePage : BaseContentPage
    {
        public ProfilePage()
        {
            Content = new StackLayout
            {
                Children = {
					new Label { Text = "Profile Page",
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand}
				}
            };
        }
    }
}

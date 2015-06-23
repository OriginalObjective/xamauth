using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using FacebookContacts;

namespace FacebookContacts.WinPhone
{
    public partial class MainPage : global::Xamarin.Forms.Platform.WinPhone.FormsApplicationPage
    {
        public static MainPage StaticMainPage;
        public MainPage()
        {
            InitializeComponent();
            StaticMainPage = this;

            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new FacebookContacts.App());
        }
    }
}

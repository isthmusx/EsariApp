using System;
using System.IO;
using Acr.UserDialogs;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: ExportFont("BebasNeue-Regular.ttf", Alias ="Bebas-Neue")]
[assembly: ExportFont("Athiti-Regular.ttf", Alias = "Athiti-Regular")]
[assembly: ExportFont("Athiti-SemiBold.ttf", Alias = "Athiti-SemiBold")]

namespace EsariApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);


            if (!string.IsNullOrEmpty(Preferences.Get("MyfirebaseRefreshToken", "")))
            {
                MainPage = new NavigationPage(new Homepage());
            }
            else
            {
                MainPage = new NavigationPage(new LoginUI());
            }
            
            
        }
 
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

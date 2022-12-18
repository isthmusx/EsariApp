using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Firebase.Auth;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace EsariApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginUI : ContentPage
    {

        public string WebAPIKey = "AIzaSyDOnIArEwj7-fFgIb0NRDrVmiltactZE5E";

        public LoginUI()
        {
            InitializeComponent();
        }

        async private void BTNLogin(object sender, EventArgs e)
        {

            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(txtEmailLogin.Text, txtPasswordLogin.Text);
                var content = await auth.GetFreshAuthAsync();
                var serializedContent = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", serializedContent);
                await Navigation.PushAsync(new Homepage());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "Ok");
            }

        }

        private void BTNRegister(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

        private void BTNForgotPass(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgotPassPage());
        }
    }
}
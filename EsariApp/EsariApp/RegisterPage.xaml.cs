using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace EsariApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public string WebAPIKey = "AIzaSyDOnIArEwj7-fFgIb0NRDrVmiltactZE5E";
        public RegisterPage()
        {
            InitializeComponent();
        }
        private void BTNLogin(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginUI());
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(txtEmail.Text, txtPassword.Text);
                string getToken = auth.FirebaseToken;
                await App.Current.MainPage.DisplayAlert("Alert", getToken, "Ok");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "Ok");
            }
            
        }
    }
}
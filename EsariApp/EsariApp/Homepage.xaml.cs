using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EsariApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Homepage : ContentPage
    {
        public string WebAPIKey = "AIzaSyDOnIArEwj7-fFgIb0NRDrVmiltactZE5E";
        public Homepage()
        {
            InitializeComponent();

            GetProfileInformationAndRefreshToken();

        }

        private async void GetProfileInformationAndRefreshToken()
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
            try
            {
                var savedFirebaseAuth = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("MyFirebaseRefreshToken", ""));
                var refreshedContent = await authProvider.RefreshAuthAsync(savedFirebaseAuth);
                Preferences.Set("MyFirebaseRefreshToken", JsonConvert.SerializeObject(refreshedContent));

                MyUserName.Text = savedFirebaseAuth.User.Email;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await App.Current.MainPage.DisplayAlert("Alert", "Oh no! Token expired.", "Ok");
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginUI());
        }
    }
}
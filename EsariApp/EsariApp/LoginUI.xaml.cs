using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsariApp.Tables;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EsariApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginUI : ContentPage
    {
        public LoginUI()
        {
            InitializeComponent();

          

        }

        private void BTNLogin(object sender, EventArgs e)
        {

            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);
            var myquery = db.Table<RegisterUserTable>().Where(u=>u.UserName.Equals(txtUsername.Text) && u.Password.Equals(txtPassword.Text));

           if (myquery != null)
            {
                App.Current.MainPage = new NavigationPage(new Homepage());
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                    {
                        var result = await this.DisplayAlert("Error!", "Invalid account", "Ok", "Cancel");

                        if (result)
                        {
                            await Navigation.PushAsync(new LoginUI());
                        }
                        else
                        {
                            await Navigation.PushAsync(new LoginUI());
                        }
                    });
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
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

            if (txtUsername.Text == "admin" && txtPassword.Text == "12345")
            {
                Navigation.PushAsync(new Homepage());
            }
            else
            {
                DisplayAlert("Invalid Account!", "Please try again", "OK");
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
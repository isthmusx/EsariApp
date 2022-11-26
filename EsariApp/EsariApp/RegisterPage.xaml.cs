using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EsariApp.Tables;

namespace EsariApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }
        private void BTNLogin(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginUI());
        }

        void Button_Clicked(object sender, EventArgs e)
        {

            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UserDatabase.db");
            var db = new SQLiteConnection(dbpath);

            db.CreateTable<RegisterUserTable>();

            var item = new RegisterUserTable()
            {
                Email = txtEmail.Text,
                PhoneNumber = txtPhone.Text,
                StoreName = txtSN.Text,
                UserName = txtUN.Text,
                Password = txtPW.Text,
            };
            db.Insert(item);
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Success!", "Account registarion succesful", "Ok", "Cancel");

                if (result)
                {
                    await Navigation.PushAsync(new LoginUI());
                }
            });
        }
    }
}
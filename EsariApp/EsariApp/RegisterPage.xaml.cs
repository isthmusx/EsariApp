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

        }
    }
}
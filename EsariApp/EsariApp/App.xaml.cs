using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: ExportFont("BebasNeue-Regular.ttf", Alias ="Bebas-Neue")]
[assembly: ExportFont("Athiti-Regular.ttf", Alias = "Athiti-Regular")]
[assembly: ExportFont("Athiti-SemiBold.ttf", Alias = "Athiti-SemiBold")]

namespace EsariApp
{
    public partial class App : Application
    {
        private static Database database;
        public static Database Database
        {
            get
            {
                if (Database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "user.db3"));
                }
                return database;
            }
        }


        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginUI());
            {
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

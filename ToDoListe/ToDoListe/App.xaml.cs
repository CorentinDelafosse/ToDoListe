using RestSharp;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoListe
{
    public partial class App : Application
    {

       
        
        public static RestClient Client;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            Client = new RestClient();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

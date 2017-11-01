using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinCP.Service;

namespace XamarinCP
{
    public partial class App : Application
    {
        public static ServiceManager ServiceManager { get; private set; }
        public App()
        {
            InitializeComponent();
            ServiceManager=new ServiceManager(new CompanyService(),new AccountService());
            MainPage = new NavigationPage(new XamarinCP.MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

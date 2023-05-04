using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
namespace Товары_и_склад
{
    public partial class App : Application
    {
        public static NavigationPage navigationPage = new NavigationPage();
        
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
            App.navigationPage = (NavigationPage)App.Current.MainPage;
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

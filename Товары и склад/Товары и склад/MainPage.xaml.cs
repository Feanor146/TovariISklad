using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using Xamarin.Essentials;
namespace Товары_и_склад
{
    public partial class MainPage : ContentPage
    {
        public static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public MainPage()
        {
            InitializeComponent();
            DataBaseWork.CreateifNotExistDataBase();
            Registration_Click.Clicked += Registration_Click_Clicked;
            Autorization_Click.Clicked += Autorization_Click_Clicked;
        }
        private async void Autorization_Click_Clicked(object sender, EventArgs e)
        {
            try
            {
                DataBaseWork.users.Single(x => x.Login == Login.Text & x.Password == Password.Text);
                Tovars tovars = new Tovars();
                await App.navigationPage.PushAsync(tovars);
            }
            catch
            {
                await DisplayAlert("Внимание", "Неверно введён логин или пароль", "ок");
            }            
        }
        private async void Registration_Click_Clicked(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            await App.navigationPage.PushAsync(registration);
            
        }
    }
}

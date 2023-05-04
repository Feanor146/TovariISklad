using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace Товары_и_склад
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registration : ContentPage
    {
        public Registration()
        {
            InitializeComponent();
            Autorization.Clicked += Autorization_Clicked;
            Registration1.Clicked += Registration1_Clicked;
        }
        private void Registration1_Clicked(object sender, EventArgs e)
        {
            try
            {
                DataBaseWork.users.Single(x=>x.Login == Login.Text);
                DisplayAlert("Внимание","Учётная запись с таким логином уже существует!","ок");
                return;
            }
            catch
            {
                DataBaseWork.Connection.Insert(new User { Login = Login.Text, Password = Password.Text, Surname = Surname.Text, Name = Name.Text, FatherName = FatherName.Text });
                DisplayAlert("Внимание", "Регистрация выполнена успешно", "ок");
            }
        }
        private async void Autorization_Clicked(object sender, EventArgs e)
        {
            MainPage Autorization = new MainPage();
            await App.navigationPage.PushAsync(Autorization);

        }
    }
}
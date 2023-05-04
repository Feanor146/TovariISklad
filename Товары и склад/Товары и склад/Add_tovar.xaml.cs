using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;
using static Xamarin.Essentials.AppleSignInAuthenticator;
namespace Товары_и_склад
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add_tovar : ContentPage
    {
        
        byte[] a = null;
        FileResult fileResult = null;
        public Add_tovar()
        {
            InitializeComponent();
            ToolbarItems.Add(MenuApp.toolbarItem1);
            ToolbarItems.Add(MenuApp.toolbarItem3);
            Select_Photo.Clicked += Select_Photo_Clicked;
            Add_tovar1.Clicked += Add_tovar1_Clicked;
        }
        private void Add_tovar1_Clicked(object sender, EventArgs e)
        {
            try
            {
                DataBaseWork.Connection.Insert(new Product { ProductName = Name.Text, QuantityStock = Convert.ToInt64(Quantity.Text), Cost = Convert.ToDecimal(Cost.Text), Photo = a });
                DisplayAlert("Внимание", "Товар успешено добавлен", "ок");
                Tovars.products = DataBaseWork.products;
            }
            catch
            {
                DisplayAlert("Внимание", "При добавлении товара произошла ошибка", "ок");
            }
        }
        private async void Select_Photo_Clicked(object sender, EventArgs e)
        {
            fileResult = await FilePicker.PickAsync(PickOptions.Images);                        
            Photo.Source =  FileImageSource.FromFile(fileResult.FullPath);
            a = File.ReadAllBytes(fileResult.FullPath);
        }
    }
}
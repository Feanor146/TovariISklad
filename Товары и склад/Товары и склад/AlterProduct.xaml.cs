using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Data;
namespace Товары_и_склад
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlterProduct : ContentPage
    {
        private Product product;
        byte[] a = null;
        FileResult fileResult = null;
        public AlterProduct(Product product)
        {
            InitializeComponent();
            this.product = product;
            Name.Text = product.ProductName;
            Quantity.Text = Convert.ToString(product.QuantityStock);
            Cost.Text = Convert.ToString(product.Cost);
            Photo.Source = product.source;
            Select_Photo.Clicked += Select_Photo_Clicked;
            Save_alter.Clicked += Save_alter_Clicked;
            Delete.Clicked += Delete_Clicked;
        }
        private async void Delete_Clicked(object sender, EventArgs e)
        {
            DataBaseWork.Connection.Delete(product);
            await DisplayAlert("Внимание", "Товар удалён", "ок");
            Tovars.products = DataBaseWork.products;
        }
        private async void Save_alter_Clicked(object sender, EventArgs e)
        {
            product.ProductName = Name.Text;
            product.Cost = Convert.ToDecimal(Cost.Text);
            product.QuantityStock = Convert.ToInt64(Quantity.Text);
            if (a != null)
            {
                product.Photo = a;
            }            
            DataBaseWork.Connection.Update(product);
            await DisplayAlert("Внимание", "Данные успешно изменены", "ок");
            Tovars tovars = new Tovars();
            await App.navigationPage.PushAsync(tovars);
            Tovars.products = DataBaseWork.products;
        }
        private async void Select_Photo_Clicked(object sender, EventArgs e)
        {
            fileResult = await FilePicker.PickAsync(PickOptions.Images);
            Photo.Source = FileImageSource.FromFile(fileResult.FullPath);
            a = File.ReadAllBytes(fileResult.FullPath);
        }
    }
}
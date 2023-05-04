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
    public partial class Tovars : ContentPage
    {
        public static List<Product> products = DataBaseWork.products;
        public Tovars()
        {
            InitializeComponent();
            Product.ItemsSource = products;
            Product.ItemSelected += Product_ItemSelected;
            ToolbarItems.Add(MenuApp.toolbarItem1);
            ToolbarItems.Add(MenuApp.toolbarItem2);
            App.navigationPage.Popped += NavigationPage_Popped;
        }
        private void NavigationPage_Popped(object sender, NavigationEventArgs e)
        {
            products = DataBaseWork.products;
            Product.ItemsSource = products;
        }
        private async void Product_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            AlterProduct alterProduct = new AlterProduct((Product)Product.SelectedItem);
            await App.navigationPage.PushAsync(alterProduct);
        }
    }
}
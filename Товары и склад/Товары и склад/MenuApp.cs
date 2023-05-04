using System;
using Xamarin;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace Товары_и_склад
{
    public class MenuApp
    {
        public static ToolbarItem toolbarItem1 
        { get
            {
                var toolbarItem1 = new ToolbarItem();
                toolbarItem1.Text = "Фильтры";
                toolbarItem1.Clicked += ToolbarItem1_Clicked;
                return toolbarItem1;
            } 
        }
        public static ToolbarItem toolbarItem2 
        { get 
            {
                var toolbarItem2 = new ToolbarItem();
                toolbarItem2.Text = "Добавить товар";
                toolbarItem2.Clicked += ToolbarItem2_Clicked;
                return toolbarItem2;
            } 
        }
        public static ToolbarItem toolbarItem3
        {
            get
            {
                var toolbarItem3 = new ToolbarItem();
                toolbarItem3.Text = "Просмотр товаров";
                toolbarItem3.Clicked += ToolbarItem3_Clicked;
                return toolbarItem3;
            }
        }
        static private async void ToolbarItem1_Clicked(object sender, EventArgs e)
        {
            Filtres filtres = new Filtres();
            await App.navigationPage.PushAsync(filtres);
        }
        static private async void ToolbarItem2_Clicked(object sender, EventArgs e)
        {
            Add_tovar add_Tovar = new Add_tovar();
            await App.navigationPage.PushAsync(add_Tovar);
        }
        static private async void ToolbarItem3_Clicked(object sender, EventArgs e)
        {
            Tovars tovars = new Tovars();
            await App.navigationPage.PushAsync(tovars);
        }
    }
}

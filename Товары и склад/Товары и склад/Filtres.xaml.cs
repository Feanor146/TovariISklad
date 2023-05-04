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
    public partial class Filtres : ContentPage
    {
        public Filtres()
        {
            InitializeComponent();
            ToolbarItems.Add(MenuApp.toolbarItem2);
            ToolbarItems.Add(MenuApp.toolbarItem3);
            if (DataBaseWork.products.Count == 0)
            {
                DisplayAlert("Внимание", "В базе нету данных", "ок");
            }
            else
            {
                MinCost.Text = Convert.ToString(DataBaseWork.products.Min(x => x.Cost));
                MaxCost.Text = Convert.ToString(DataBaseWork.products.Max(x => x.Cost));
            }            
            Sorting.Items.Add("Наименование по возрастанию");
            Sorting.Items.Add("Наименование по убыванию");
            Sorting.Items.Add("Цена по возрастанию");
            Sorting.Items.Add("Цена по убыванию");
            Sorting.SelectedItem = "Наименование по возрастанию";
            FiltrOk.Clicked += FiltrOk_Clicked;
            FiltrCancel.Clicked += FiltrCancel_Clicked;
        }
        private async void FiltrCancel_Clicked(object sender, EventArgs e)
        {
            Tovars.products = DataBaseWork.products.ToList();
            Tovars tovars = new Tovars();
            await App.navigationPage.PushAsync(tovars);
        }
        private async void FiltrOk_Clicked(object sender, EventArgs e)
        {
            if (Sorting.SelectedItem == "Наименование по возрастанию")
            {
                Tovars.products = Tovars.products.OrderBy(x => x.ProductName).Where(x=>x.Cost >= Convert.ToDecimal(MinCost.Text) & x.Cost <= Convert.ToDecimal(MaxCost.Text)).ToList();
            }
            if (Sorting.SelectedItem == "Наименование по убыванию")
            {
                Tovars.products = Tovars.products.OrderByDescending(x => x.ProductName).Where(x => x.Cost >= Convert.ToDecimal(MinCost.Text) & x.Cost <= Convert.ToDecimal(MaxCost.Text)).ToList();
            }
            if (Sorting.SelectedItem == "Цена по возрастанию")
            {
                Tovars.products = Tovars.products.OrderBy(x => x.Cost).Where(x => x.Cost >= Convert.ToDecimal(MinCost.Text) & x.Cost <= Convert.ToDecimal(MaxCost.Text)).ToList();
            }
            if (Sorting.SelectedItem == "Цена по убыванию")
            {
                Tovars.products = Tovars.products.OrderByDescending(x => x.Cost).Where(x => x.Cost >= Convert.ToDecimal(MinCost.Text) & x.Cost <= Convert.ToDecimal(MaxCost.Text)).ToList();
            }
            Tovars tovars = new Tovars();
            await App.navigationPage.PushAsync(tovars);
        }
    }
}
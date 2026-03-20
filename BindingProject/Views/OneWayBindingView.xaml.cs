using BindingProject.Localization;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BindingProject.Views
{
    public partial class OneWayBindingView : UserControl
    {
        public OneWayBindingView()
        {
            InitializeComponent();
        }

        private void SetLaptop_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is ViewModels.MainViewModel vm)
            {
                var langService = Application.Current.Resources["LanguageService"] as ILanguageService;
                string productName = langService?.GetString("Product_Laptop") ?? "Ноутбук";

                vm.CurrentProduct.Name = productName;
                vm.CurrentProduct.Price = 75000;
                vm.CurrentProduct.Quantity = 2;
                vm.LastUpdateTime = DateTime.Now;
            }
        }

        private void SetPhone_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is ViewModels.MainViewModel vm)
            {
                var langService = Application.Current.Resources["LanguageService"] as ILanguageService;
                string productName = langService?.GetString("Product_Phone") ?? "Телефон";

                vm.CurrentProduct.Name = productName;
                vm.CurrentProduct.Price = 45000;
                vm.CurrentProduct.Quantity = 5;
                vm.LastUpdateTime = DateTime.Now;
            }
        }

        private void SetPrice25000_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is ViewModels.MainViewModel vm)
            {
                vm.CurrentProduct.Price = 25000;
                vm.LastUpdateTime = DateTime.Now;
            }
        }

        private void SetPrice75000_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is ViewModels.MainViewModel vm)
            {
                vm.CurrentProduct.Price = 75000;
                vm.LastUpdateTime = DateTime.Now;
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is ViewModels.MainViewModel vm)
            {
                var langService = Application.Current.Resources["LanguageService"] as ILanguageService;
                string defaultName = langService?.GetString("Product_Default") ?? "Товар";

                vm.CurrentProduct.Name = defaultName;
                vm.CurrentProduct.Price = 1000;
                vm.CurrentProduct.Quantity = 1;
                vm.LastUpdateTime = DateTime.Now;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BindingProject.Views
{
    /// <summary>
    /// Логика взаимодействия для OneWayBindingView.xaml
    /// </summary>
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
                // Берем название из текущего словаря
                string productName = LanguageManager.GetString("Product_Laptop");
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
                string productName = LanguageManager.GetString("Product_Phone");
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
                string defaultName = LanguageManager.GetString("Product_Default");
                vm.CurrentProduct.Name = defaultName;
                vm.CurrentProduct.Price = 1000;
                vm.CurrentProduct.Quantity = 1;
                vm.LastUpdateTime = DateTime.Now;
            }
        }
    }
}

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
                vm.SetProductNameKey("ProductName_LaptopASUS");
                vm.CurrentProduct.Price = 65000;
                vm.CurrentProduct.Quantity = 3;
                vm.LastUpdateTime = DateTime.Now;
            }
        }

        private void SetPhone_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is ViewModels.MainViewModel vm)
            {
                vm.SetProductNameKey("ProductName_PhoneSamsung");
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
                vm.SetProductNameKey("ProductName_Default");
                vm.CurrentProduct.Price = 1000;
                vm.CurrentProduct.Quantity = 1;
                vm.LastUpdateTime = DateTime.Now;
            }
        }
    }
}

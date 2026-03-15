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
    /// Логика взаимодействия для OneTimeBindingView.xaml
    /// </summary>
    public partial class OneTimeBindingView : UserControl
    {
        public OneTimeBindingView()
        {
            InitializeComponent();
        }

        private void SetLaptop_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is ViewModels.MainViewModel vm)
            {
                vm.CurrentProduct.Name = "Ноутбук";
                vm.CurrentProduct.Price = 75000;
                vm.CurrentProduct.Quantity = 2;
            }
        }

        private void SetPhone_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is ViewModels.MainViewModel vm)
            {
                vm.CurrentProduct.Name = "Смартфон";
                vm.CurrentProduct.Price = 45000;
                vm.CurrentProduct.Quantity = 5;
            }
        }

        private void SetPrice50000_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is ViewModels.MainViewModel vm)
            {
                vm.CurrentProduct.Price = 50000;
            }
        }

        private void ResetAll_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is ViewModels.MainViewModel vm)
            {
                vm.CurrentProduct.Name = "Товар";
                vm.CurrentProduct.Price = 1000;
                vm.CurrentProduct.Quantity = 1;
            }
        }
    }
}

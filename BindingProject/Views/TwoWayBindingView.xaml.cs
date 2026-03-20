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
    /// Логика взаимодействия для TwoWayBindingView.xaml
    /// </summary>
    public partial class TwoWayBindingView : UserControl
    {
        public TwoWayBindingView()
        {
            InitializeComponent();
        }

        private void SetHighPrice_Click(object sender, RoutedEventArgs e)
        {
            // Находим ViewModel через DataContext
            if (DataContext is ViewModels.MainViewModel viewModel)
            {
                viewModel.CurrentProduct.Price = 99999;
            }
        }

        private void ResetName_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is ViewModels.MainViewModel vm)
            {
                string newProductName = LanguageManager.GetString("Product_NewProduct");
                vm.CurrentProduct.Name = newProductName;
            }
        }
    }
}

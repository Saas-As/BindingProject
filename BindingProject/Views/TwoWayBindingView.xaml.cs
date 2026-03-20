using System;
using System.Windows;
using System.Windows.Controls;

namespace BindingProject.Views
{
    public partial class TwoWayBindingView : UserControl
    {
        public TwoWayBindingView()
        {
            InitializeComponent();
        }

        private void SetHighPrice_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is ViewModels.MainViewModel viewModel)
            {
                viewModel.CurrentProduct.Price = 99999;
                viewModel.LastUpdateTime = DateTime.Now;

                // Получаем переведенное сообщение из ресурсов
                string messageTemplate = (string)Application.Current.Resources["Message_PriceChanged"];
                string message = string.Format(messageTemplate, viewModel.CurrentProduct.Price);
                string title = (string)Application.Current.Resources["MainWindow_Title"];

                MessageBox.Show(message, title);
            }
        }

        private void ResetName_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is ViewModels.MainViewModel vm)
            {
                // Получаем переведенное название из ресурсов
                string newProductName = (string)Application.Current.Resources["Product_NewProduct"];
                vm.CurrentProduct.Name = newProductName;
                vm.LastUpdateTime = DateTime.Now;
            }
        }
    }
}
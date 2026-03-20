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
    /// Логика взаимодействия для DefaultBindingView.xaml
    /// </summary>
    public partial class DefaultBindingView : UserControl
    {
        public DefaultBindingView()
        {
            InitializeComponent();
        }

        private void ResetToDefault_Click(object sender, RoutedEventArgs e)
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

using BindingProject.Localization;
using System.Windows;
using System.Windows.Controls;

namespace BindingProject.Views
{
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
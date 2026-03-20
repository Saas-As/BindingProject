using BindingProject.Localization;
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
            if (DataContext is ViewModels.MainViewModel vm)
            {
                vm.CurrentProduct.Price = 99999;
                vm.LastUpdateTime = DateTime.Now;

                var langService = Application.Current.Resources["LanguageService"] as ILanguageService;
                if (langService != null)
                {
                    string message = string.Format(langService.GetString("Message_PriceChanged"), vm.CurrentProduct.Price);
                    MessageBox.Show(message);
                }
            }
        }

        private void ResetName_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is ViewModels.MainViewModel vm)
            {
                var langService = Application.Current.Resources["LanguageService"] as ILanguageService;
                string newName = langService?.GetString("Product_NewProduct") ?? "Новый товар";

                vm.CurrentProduct.Name = newName;
                vm.LastUpdateTime = DateTime.Now;
            }
        }
    }
}
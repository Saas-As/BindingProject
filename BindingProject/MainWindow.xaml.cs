using BindingProject.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BindingProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();

            // Язык по умолчанию: русский
            if (Application.Current?.Resources["Loc"] is ResxLocalizer loc)
            {
                loc.SetCulture("ru-RU");
            }

            if (LanguageComboBox.Items.Count > 0)
            {
                LanguageComboBox.SelectedIndex = 0;
            }

            if (DataContext is MainViewModel vm)
            {
                vm.UpdateProductNameFromKey();
            }
        }

        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LanguageComboBox.SelectedItem is ComboBoxItem item && item.Tag is string cultureName)
            {
                if (Application.Current?.Resources["Loc"] is ResxLocalizer loc)
                {
                    loc.SetCulture(cultureName);
                }

                if (DataContext is MainViewModel vm)
                {
                    vm.UpdateProductNameFromKey();
                }
            }
        }
    }
}
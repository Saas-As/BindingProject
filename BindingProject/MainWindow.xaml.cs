using BindingProject.Localization;
using System.Windows;
using System.Windows.Controls;

namespace BindingProject
{
    public partial class MainWindow : Window
    {
        private ILanguageService _languageService;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModels.MainViewModel();

            _languageService = Application.Current.Resources["LanguageService"] as ILanguageService;

            if (_languageService != null)
            {
                _languageService.LanguageChanged += OnLanguageChanged;
            }

            LanguageComboBox.SelectedIndex = 0;
        }

        private void OnLanguageChanged()
        {
            // Обновляем DataContext, чтобы перерисовать все привязки
            var oldContext = DataContext;
            DataContext = null;
            DataContext = oldContext;

            // Или перезагружаем все вкладки
            var mainViewModel = DataContext as ViewModels.MainViewModel;
            if (mainViewModel != null)
            {
                mainViewModel.RefreshLanguage();
            }
        }

        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LanguageComboBox.SelectedItem is ComboBoxItem item && _languageService != null)
            {
                string language = item.Tag.ToString();
                _languageService.SetLanguage(language);
            }
        }
    }
}
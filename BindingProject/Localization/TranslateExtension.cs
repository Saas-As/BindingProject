using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace BindingProject.Localization
{
    public class TranslateExtension : MarkupExtension
    {
        private readonly string _key;

        public TranslateExtension(string key)
        {
            _key = key;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var app = Application.Current;
            if (app?.Resources["LanguageService"] is ILanguageService service)
            {
                // Создаем Binding к свойству LocalizedString.Value
                var binding = new Binding
                {
                    Source = new LocalizedString(service, _key),
                    Path = new PropertyPath("Value"),
                    Mode = BindingMode.OneWay
                };
                return binding.ProvideValue(serviceProvider);
            }
            return _key;
        }

        private class LocalizedString : System.ComponentModel.INotifyPropertyChanged
        {
            private readonly ILanguageService _languageService;
            private readonly string _key;

            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

            public LocalizedString(ILanguageService languageService, string key)
            {
                _languageService = languageService;
                _key = key;
                _languageService.LanguageChanged += OnLanguageChanged;
            }

            private void OnLanguageChanged()
            {
                PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(Value)));
            }

            public string Value => _languageService.GetString(_key);
        }
    }
}
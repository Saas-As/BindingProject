using BindingProject.Properties;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;

namespace BindingProject
{
    /// <summary>
    /// Локализатор на основе RESX. Поддерживает динамическое переключение языка
    /// за счёт INotifyPropertyChanged.
    /// </summary>
    public sealed class ResxLocalizer : INotifyPropertyChanged
    {
        private CultureInfo _culture = new CultureInfo("ru-RU");

        public event PropertyChangedEventHandler? PropertyChanged;

        public CultureInfo Culture
        {
            get => _culture;
            private set => _culture = value;
        }

        /// <summary>
        /// Индексатор для биндинга: Path=Item[SomeKey]
        /// </summary>
        public string this[string key]
        {
            get
            {
                var value = Strings.ResourceManager.GetString(key, Strings.Culture);
                return value ?? key;
            }
        }

        public void SetCulture(string cultureName)
        {
            var culture = new CultureInfo(cultureName);
            Culture = culture;

            // Strings.Culture — internal static в сгенерированном Strings.Designer.cs (в рамках той же сборки)
            Strings.Culture = culture;

            // Для корректного форматирования строк в привязках (StringFormat и т.п.)
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            // Сообщаем, что изменились все ресурсы.
            OnPropertyChanged(string.Empty);
        }

        private void OnPropertyChanged(string? propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


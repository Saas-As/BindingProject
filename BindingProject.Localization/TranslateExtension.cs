using System;
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
            var app = System.Windows.Application.Current;
            if (app != null && app.Resources.Contains("LanguageService"))
            {
                var service = app.Resources["LanguageService"] as ILanguageService;
                if (service != null)
                {
                    return service.GetString(_key);
                }
            }
            return _key;
        }
    }
}
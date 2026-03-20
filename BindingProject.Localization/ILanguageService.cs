using System.Collections.Generic;

namespace BindingProject.Localization
{
    public interface ILanguageService
    {
        string GetString(string key);
        void SetLanguage(string languageCode);
        string CurrentLanguage { get; }
        event System.Action LanguageChanged;
    }
}
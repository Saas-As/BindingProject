using System.Windows;

namespace BindingProject
{
    public static class LanguageManager
    {
        public static void ChangeLanguage(string languageCode)
        {
            var dict = new ResourceDictionary();

            if (languageCode == "en")
            {
                dict.Source = new Uri("Dictionaries/LangEn.xaml", UriKind.Relative);
            }
            else
            {
                dict.Source = new Uri("Dictionaries/LangRu.xaml", UriKind.Relative);
            }

            var appResources = Application.Current.Resources;
            var mergedDictionaries = appResources.MergedDictionaries;

            // Удаляем старый словарь с переводом
            var oldDict = mergedDictionaries.FirstOrDefault(d =>
                d.Source != null &&
                (d.Source.OriginalString.Contains("LangRu") ||
                 d.Source.OriginalString.Contains("LangEn")));

            if (oldDict != null)
            {
                mergedDictionaries.Remove(oldDict);
            }

            // Добавляем новый словарь
            mergedDictionaries.Add(dict);


        }
        public static string GetString(string key)
        {
            var dict = Application.Current.Resources.MergedDictionaries
                .FirstOrDefault(d => d.Source != null &&
                    (d.Source.OriginalString.Contains("LangRu") ||
                     d.Source.OriginalString.Contains("LangEn")));

            if (dict != null && dict.Contains(key))
            {
                return dict[key] as string ?? key;
            }

            return key;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Xml;

namespace BindingProject.Localization
{
    public class LanguageService : ILanguageService
    {
        private Dictionary<string, Dictionary<string, string>> _translations;
        private string _currentLanguage;

        public event Action LanguageChanged;

        public string CurrentLanguage => _currentLanguage;

        public LanguageService()
        {
            _translations = new Dictionary<string, Dictionary<string, string>>();
            LoadTranslations();
            _currentLanguage = "ru";
        }

        private void LoadTranslations()
        {
            // Русские переводы
            var ruTranslations = new Dictionary<string, string>
            {
                // Заголовки вкладок
                { "Tab_DefaultBinding", "Привязка по умолчанию" },
                { "Tab_TwoWayBinding", "Двухсторонняя привязка" },
                { "Tab_OneTimeBinding", "Одноразовая привязка" },
                { "Tab_OneWayBinding", "Односторонние привязки" },
                { "Tab_Triggers", "Триггеры" },
                
                // Заголовок окна
                { "MainWindow_Title", "Локализация WPF (External Library)" },
                
                // Общие надписи
                { "Product_Name", "Название" },
                { "Product_Price", "Цена" },
                { "Product_Quantity", "Количество" },
                { "Product_Total", "Итого" },
                
                // Кнопки
                { "Button_Reset", "Сброс" },
                { "Button_SetHighPrice", "Установить цену 99999" },
                { "Button_SetLaptop", "Ноутбук" },
                { "Button_SetPhone", "Телефон" },
                { "Button_SetPrice25000", "Цена 25000" },
                { "Button_SetPrice75000", "Цена 75000" },
                
                // Сообщения
                { "Message_PriceChanged", "Цена изменена на {0} рублей" },
                
                // Язык
                { "Language_Label", "Язык:" },
                { "Language_Russian", "Русский" },
                { "Language_English", "English" },
                
                // DefaultBindingView
                { "DefaultBindingView_Title", "🔹 Привязка по умолчанию (Default)" },
                { "DefaultBindingView_Description", "Default привязка: WPF сам выбирает режим. Для TextBox это TwoWay (при потере фокуса), для TextBlock это OneWay." },
                { "DefaultBindingView_EditableFieldsTitle", "✏️ Редактируемые поля (TextBox)" },
                { "DefaultBindingView_DisplayDataTitle", "👁️ Отображение данных (TextBlock)" },
                { "DefaultBindingView_UpdateSourceTriggerDemoTitle", "⚡ Демонстрация UpdateSourceTrigger" },
                { "DefaultBindingView_NormalTextBoxLabel", "Обычный TextBox (обновление при потере фокуса):" },
                { "DefaultBindingView_PropertyChangedTextBoxLabel", "TextBox с PropertyChanged (обновление после каждой буквы):" },
                { "DefaultBindingView_DifferenceText", "✏️ Разница: во втором поле изменения видны сразу в блоке отображения выше" },
                { "DefaultBindingView_WhatDefaultShowsLabel", "📌 Что демонстрирует привязка Default:" },
                { "DefaultBindingView_Bullet1", "При изменении текста в полях и потере фокуса - обновляется блок отображения" },
                { "DefaultBindingView_Bullet2", "ИТОГО обновляется автоматически при изменении цены или количества" },
                { "DefaultBindingView_Bullet3", "UpdateSourceTrigger=PropertyChanged - обновление после каждого символа" },
                { "Button_DefaultBinding_ResetToDefault", "↺ Сбросить к значениям по умолчанию" },
                
                // TwoWayBindingView
                { "TwoWayBindingView_Title", "🔄 Двухсторонняя привязка (TwoWay)" },
                { "TwoWayBindingView_Description", "Двусторонняя привязка: изменения в любом поле обновляют все связанные элементы" },
                { "TwoWayBindingView_Example1_Title", "📌 ПРИМЕР 1: Два текстбокса связаны с одним свойством" },
                { "TwoWayBindingView_Label_ProductNameEditAnyField", "Название товара (редактируй любое поле):" },
                { "TwoWayBindingView_UpHintText", "⬆️ Изменяй текст в любом поле — второй обновляется сразу" },
                { "TwoWayBindingView_Example2_Title", "📌 ПРИМЕР 2: Слайдер и текстбокс для цены" },
                { "TwoWayBindingView_PriceInstruction", "Цена (двигай слайдер или вводи число):" },
                { "TwoWayBindingView_Example3_Title", "📌 ПРИМЕР 3: CheckBox управляет видимостью" },
                { "TwoWayBindingView_ShowExtraInfoLabel", "Показать дополнительную информацию" },
                { "TwoWayBindingView_ExtraInfoText", "Это дополнительная информация, которая появляется/скрывается по чекбоксу" },
                { "TwoWayBindingView_Example4_Title", "📌 ПРИМЕР 4: Изменение данных в коде" },
                { "TwoWayBindingView_ExplanationTitle", "📌 Что демонстрирует TwoWay привязка:" },
                { "TwoWayBindingView_ExplanationBullet1", "• Изменения в интерфейсе → обновляют модель" },
                { "TwoWayBindingView_ExplanationBullet2", "• Изменения в модели (кнопки) → обновляют интерфейс" },
                { "TwoWayBindingView_ExplanationBullet3", "• Все элементы синхронизированы между собой" },
                { "Button_TwoWay_ResetNameToNewProduct", "Сбросить название на \"Новый товар\"" },
                
                // Названия товаров
                { "Product_Laptop", "Ноутбук" },
                { "Product_Phone", "Телефон" },
                { "Product_NewProduct", "Новый товар" },
                { "Product_Default", "Товар" },
                { "Currency_RublesShort", "руб" },
                
                // OneTimeBindingView
                { "OneTimeBindingView_Title", "⏱️ Одноразовая привязка (OneTime)" },
                { "OneTimeBindingView_DescPart1", "OneTime привязка обновляет интерфейс " },
                { "OneTimeBindingView_DescPart2", "только один раз" },
                { "OneTimeBindingView_DescPart3", " при загрузке. Дальнейшие изменения данных " },
                { "OneTimeBindingView_DescPart4", "не обновляют" },
                { "OneTimeBindingView_DescPart5", " интерфейс." },
                { "OneTimeBindingView_Example1_Title", "📌 ПРИМЕР 1: OneTime привязка (не обновляется)" },
                { "OneTimeBindingView_Header_Editor", "Редактируемые поля (TwoWay)" },
                { "OneTimeBindingView_Header_OneTimeFixed", "OneTime привязка (не меняется)" },
                { "OneTimeBindingView_Section_ChangeDataInCode", "🔄 Изменяем данные в коде" },
                { "OneTimeBindingView_SliderDemoTitle", "🎚️ Слайдер меняет цену (TwoWay)" },
                { "OneTimeBindingView_PriceLabel", "Цена: " },
                { "OneTimeBindingView_ExplanationTitle", "📌 Что демонстрирует OneTime привязка:" },
                { "OneTimeBindingView_Bullet_LeftColumn", "Левая колонка (TwoWay) - данные обновляются при любых изменениях" },
                { "OneTimeBindingView_Bullet_RightColumnFixed", "Правая колонка (OneTime) - застыла при загрузке и не меняется" },
                { "OneTimeBindingView_Bullet_KeepRightColumnUnchanged", "Нажимай кнопки, двигай слайдер - правая колонка остается неизменной" },
                { "OneTimeBindingView_Conclusion", "OneTime привязка берет значение модели один раз при загрузке и больше не обновляется, даже если модель меняется" },
                { "Button_OneTime_SetLaptop", "Установить \"Ноутбук\"" },
                { "Button_OneTime_SetPhone", "Установить \"Телефон\"" },
                { "Button_SetPrice50000", "Цена 50000" },
                { "Button_OneTime_ResetAll", "Сбросить" },
                { "Label_NameOneTimeColon", "Название (OneTime):" },
                { "Label_PriceOneTimeColon", "Цена (OneTime):" },
                { "Label_QuantityOneTimeColon", "Количество (OneTime):" },
                { "Label_TotalOneTimeColon", "Итого (OneTime):" },
                { "Label_TotalColon", "Итого:" },
                
                // OneWayBindingView
                { "OneWayBindingView_Title", "➡️ Односторонние привязки (OneWay)" },
                { "OneWayBindingView_DescPart1", "OneWay привязка: данные текут " },
                { "OneWayBindingView_DescPart2", "только из модели в интерфейс" },
                { "OneWayBindingView_DescPart3", ". Пользователь может видеть данные, но не может их изменить через этот элемент." },
                { "OneWayBindingView_Example1_Title", "📌 ПРИМЕР 1: TextBlock с OneWay (только просмотр)" },
                { "OneWayBindingView_Header_EditTwoWay", "Редактирование (TwoWay)" },
                { "OneWayBindingView_Header_ViewOneWay", "Просмотр (OneWay)" },
                { "OneWayBindingView_Example2_Title", "📊 ПРИМЕР 2: Визуальные элементы с OneWay" },
                { "Label_ProgressPrice", "Прогресс цены:" },
                { "Label_LastUpdateTime", "Последнее изменение:" },
                { "OneWayBindingView_Example3_Title", "🎚️ ПРИМЕР 3: Слайдер (TwoWay) и индикаторы (OneWay)" },
                { "OneWayBindingView_ControlSliderLabel", "Управляй ценой через слайдер:" },
                { "OneWayBindingView_CurrentPriceLabel", "Текущая цена: " },
                { "OneWayBindingView_ProductNameLabel", "Название товара: " },
                { "OneWayBindingView_Example4_Title", "🔄 ПРИМЕР 4: OneWay vs OneTime (наглядное сравнение)" },
                { "OneWayBindingView_CompareGrid_Header_Editor", "Редактор (TwoWay)" },
                { "OneWayBindingView_CompareGrid_Header_OneWay", "OneWay (обновляется)" },
                { "OneWayBindingView_CompareGrid_Header_OneTime", "OneTime (застыл)" },
                { "OneWayBindingView_TestButtonsTitle", "🎮 Тестовые кнопки (меняют данные в модели)" },
                { "OneWayBindingView_ExplanationTitle", "📌 Что демонстрирует OneWay привязка:" },
                { "OneWayBindingView_Bullet1", "OneWay элементы показывают данные, но не могут их изменить" },
                { "OneWayBindingView_Bullet2", "При изменении модели все OneWay элементы обновляются автоматически" },
                { "OneWayBindingView_Bullet3", "Идеально для отображения информации, статистики, прогресса" },
                { "OneWayBindingView_Bullet4", "В отличие от OneTime, OneWay продолжает следить за изменениями" },
                
                // TriggersView
                { "TriggersView_Title", "⚡ Триггеры в WPF" },
                { "TriggersView_Subtitle", "Триггеры позволяют изменять внешний вид элементов при выполнении определенных условий" },
                { "TriggersView_PropertyTriggerTitle", "🔹 1. PropertyTrigger (свойство элемента)" },
                { "TriggersView_PropertyTriggerExplanation", "Срабатывает при изменении свойства самого элемента (IsMouseOver, IsFocused, IsChecked)" },
                { "Triggers_Button_HoverMouse", "Наведи мышку" },
                { "Triggers_CheckBox_MarkMe", "Отметь меня" },
                { "TriggersView_DataTriggerTitle", "🔹 2. DataTrigger (привязка к данным)" },
                { "TriggersView_DataTriggerExplanation", "Срабатывает при изменении данных в модели (привязка к свойству)" },
                { "Triggers_Table_Header_Product", "Товар" },
                { "Triggers_Table_Header_Price", "Цена" },
                { "Triggers_Table_Header_Quantity", "Кол-во" },
                { "Triggers_Table_Header_Status", "Статус" },
                { "TriggersView_Status_Normal", "Обычный" },
                { "TriggersView_Status_Free", "Бесплатно" },
                { "TriggersView_Status_NotAvailable", "Нет в наличии" },
                { "TriggersView_Status_Premium", "Премиум" },
                { "TriggersView_EventTriggerTitle", "🔹 3. EventTrigger (события и анимация)" },
                { "TriggersView_EventTriggerExplanation", "Срабатывает при возникновении события (Click, Loaded, MouseEnter) и запускает анимацию" },
                { "Triggers_Button_ClickMe", "Нажми меня" },
                { "TriggersView_MultiTriggerTitle", "🔹 4. MultiTrigger и MultiDataTrigger (несколько условий)" },
                { "TriggersView_MultiTriggerExplanation", "Срабатывают при выполнении нескольких условий одновременно" },
                { "Triggers_Discount_ConditionsLabel", "Условия для скидки:" },
                { "Triggers_CheckBox_RegularCustomer", "Постоянный клиент" },
                { "Triggers_CheckBox_HasPromoCode", "Есть промокод" },
                { "Triggers_CheckBox_IsHoliday", "Праздничный день" },
                { "Triggers_MyDiscountLabel", "Ваша скидка:" },
                { "TriggersView_SummaryTitle", "📊 Сводка по триггерам:" },
                { "TriggersView_Summary_PropertyTrigger", "PropertyTrigger" },
                { "TriggersView_Summary_PropertyTriggerDescription", "Реагирует на свойства элемента (IsMouseOver, IsFocused и др.)" },
                { "TriggersView_Summary_DataTrigger", "DataTrigger" },
                { "TriggersView_Summary_DataTriggerDescription", "Реагирует на изменения в данных (привязка к модели)" },
                { "TriggersView_Summary_EventTrigger", "EventTrigger" },
                { "TriggersView_Summary_EventTriggerDescription", "Запускает анимацию при событии (Click, Loaded и др.)" },
                { "TriggersView_Summary_MultiTrigger", "MultiTrigger" },
                { "TriggersView_Summary_MultiTriggerDescription", "Срабатывает при выполнении нескольких условий" }
            };

            // Английские переводы
            var enTranslations = new Dictionary<string, string>
            {
                // Tab headers
                { "Tab_DefaultBinding", "Default Binding" },
                { "Tab_TwoWayBinding", "TwoWay Binding" },
                { "Tab_OneTimeBinding", "OneTime Binding" },
                { "Tab_OneWayBinding", "OneWay Binding" },
                { "Tab_Triggers", "Triggers" },
                
                // Window title
                { "MainWindow_Title", "WPF Localization (External Library)" },
                
                // Common labels
                { "Product_Name", "Name" },
                { "Product_Price", "Price" },
                { "Product_Quantity", "Quantity" },
                { "Product_Total", "Total" },
                
                // Buttons
                { "Button_Reset", "Reset" },
                { "Button_SetHighPrice", "Set price 99999" },
                { "Button_SetLaptop", "Laptop" },
                { "Button_SetPhone", "Phone" },
                { "Button_SetPrice25000", "Price 25000" },
                { "Button_SetPrice75000", "Price 75000" },
                
                // Messages
                { "Message_PriceChanged", "Price changed to {0} rubles" },
                
                // Language
                { "Language_Label", "Language:" },
                { "Language_Russian", "Русский" },
                { "Language_English", "English" },
                
                // DefaultBindingView
                { "DefaultBindingView_Title", "🔹 Default Binding" },
                { "DefaultBindingView_Description", "Default binding: WPF chooses the mode. For TextBox it's TwoWay (on LostFocus), for TextBlock it's OneWay." },
                { "DefaultBindingView_EditableFieldsTitle", "✏️ Editable fields (TextBox)" },
                { "DefaultBindingView_DisplayDataTitle", "👁️ Data display (TextBlock)" },
                { "DefaultBindingView_UpdateSourceTriggerDemoTitle", "⚡ UpdateSourceTrigger Demo" },
                { "DefaultBindingView_NormalTextBoxLabel", "Normal TextBox (updates on LostFocus):" },
                { "DefaultBindingView_PropertyChangedTextBoxLabel", "TextBox with PropertyChanged (updates on every keystroke):" },
                { "DefaultBindingView_DifferenceText", "✏️ Difference: changes in the second field are immediately visible in the display block above" },
                { "DefaultBindingView_WhatDefaultShowsLabel", "📌 What Default binding demonstrates:" },
                { "DefaultBindingView_Bullet1", "When text changes in fields and focus is lost - display block updates" },
                { "DefaultBindingView_Bullet2", "TOTAL updates automatically when price or quantity changes" },
                { "DefaultBindingView_Bullet3", "UpdateSourceTrigger=PropertyChanged - updates after every character" },
                { "Button_DefaultBinding_ResetToDefault", "↺ Reset to default values" },
                
                // TwoWayBindingView
                { "TwoWayBindingView_Title", "🔄 TwoWay Binding" },
                { "TwoWayBindingView_Description", "TwoWay binding: changes in any field update all linked elements" },
                { "TwoWayBindingView_Example1_Title", "📌 EXAMPLE 1: Two textboxes bound to one property" },
                { "TwoWayBindingView_Label_ProductNameEditAnyField", "Product name (edit any field):" },
                { "TwoWayBindingView_UpHintText", "⬆️ Change text in any field — the second updates immediately" },
                { "TwoWayBindingView_Example2_Title", "📌 EXAMPLE 2: Slider and textbox for price" },
                { "TwoWayBindingView_PriceInstruction", "Price (move slider or enter number):" },
                { "TwoWayBindingView_Example3_Title", "📌 EXAMPLE 3: CheckBox controls visibility" },
                { "TwoWayBindingView_ShowExtraInfoLabel", "Show additional information" },
                { "TwoWayBindingView_ExtraInfoText", "This is additional info that appears/hides by checkbox" },
                { "TwoWayBindingView_Example4_Title", "📌 EXAMPLE 4: Changing data in code" },
                { "TwoWayBindingView_ExplanationTitle", "📌 What TwoWay binding demonstrates:" },
                { "TwoWayBindingView_ExplanationBullet1", "• Changes in UI → update model" },
                { "TwoWayBindingView_ExplanationBullet2", "• Changes in model (buttons) → update UI" },
                { "TwoWayBindingView_ExplanationBullet3", "• All elements are synchronized with each other" },
                { "Button_TwoWay_ResetNameToNewProduct", "Reset name to \"New Product\"" },
                
                // Product names
                { "Product_Laptop", "Laptop" },
                { "Product_Phone", "Phone" },
                { "Product_NewProduct", "New Product" },
                { "Product_Default", "Product" },
                { "Currency_RublesShort", "rub" },
                
                // OneTimeBindingView
                { "OneTimeBindingView_Title", "⏱️ OneTime Binding" },
                { "OneTimeBindingView_DescPart1", "OneTime binding updates the interface " },
                { "OneTimeBindingView_DescPart2", "only once" },
                { "OneTimeBindingView_DescPart3", " at load. Further data changes " },
                { "OneTimeBindingView_DescPart4", "do not update" },
                { "OneTimeBindingView_DescPart5", " the interface." },
                { "OneTimeBindingView_Example1_Title", "📌 EXAMPLE 1: OneTime binding (does not update)" },
                { "OneTimeBindingView_Header_Editor", "Editable fields (TwoWay)" },
                { "OneTimeBindingView_Header_OneTimeFixed", "OneTime binding (fixed)" },
                { "OneTimeBindingView_Section_ChangeDataInCode", "🔄 Changing data in code" },
                { "OneTimeBindingView_SliderDemoTitle", "🎚️ Slider changes price (TwoWay)" },
                { "OneTimeBindingView_PriceLabel", "Price: " },
                { "OneTimeBindingView_ExplanationTitle", "📌 What OneTime binding demonstrates:" },
                { "OneTimeBindingView_Bullet_LeftColumn", "Left column (TwoWay) - data updates on any changes" },
                { "OneTimeBindingView_Bullet_RightColumnFixed", "Right column (OneTime) - frozen at load and doesn't change" },
                { "OneTimeBindingView_Bullet_KeepRightColumnUnchanged", "Click buttons, move slider - right column remains unchanged" },
                { "OneTimeBindingView_Conclusion", "OneTime binding takes the model value once at load and never updates again, even if the model changes" },
                { "Button_OneTime_SetLaptop", "Set \"Laptop\"" },
                { "Button_OneTime_SetPhone", "Set \"Phone\"" },
                { "Button_SetPrice50000", "Price 50000" },
                { "Button_OneTime_ResetAll", "Reset" },
                { "Label_NameOneTimeColon", "Name (OneTime):" },
                { "Label_PriceOneTimeColon", "Price (OneTime):" },
                { "Label_QuantityOneTimeColon", "Quantity (OneTime):" },
                { "Label_TotalOneTimeColon", "Total (OneTime):" },
                { "Label_TotalColon", "Total:" },
                
                // OneWayBindingView
                { "OneWayBindingView_Title", "➡️ OneWay Binding" },
                { "OneWayBindingView_DescPart1", "OneWay binding: data flows " },
                { "OneWayBindingView_DescPart2", "only from model to interface" },
                { "OneWayBindingView_DescPart3", ". User can see data but cannot change it through this element." },
                { "OneWayBindingView_Example1_Title", "📌 EXAMPLE 1: TextBlock with OneWay (view only)" },
                { "OneWayBindingView_Header_EditTwoWay", "Edit (TwoWay)" },
                { "OneWayBindingView_Header_ViewOneWay", "View (OneWay)" },
                { "OneWayBindingView_Example2_Title", "📊 EXAMPLE 2: Visual elements with OneWay" },
                { "Label_ProgressPrice", "Price progress:" },
                { "Label_LastUpdateTime", "Last update:" },
                { "OneWayBindingView_Example3_Title", "🎚️ EXAMPLE 3: Slider (TwoWay) and indicators (OneWay)" },
                { "OneWayBindingView_ControlSliderLabel", "Control price with slider:" },
                { "OneWayBindingView_CurrentPriceLabel", "Current price: " },
                { "OneWayBindingView_ProductNameLabel", "Product name: " },
                { "OneWayBindingView_Example4_Title", "🔄 EXAMPLE 4: OneWay vs OneTime (visual comparison)" },
                { "OneWayBindingView_CompareGrid_Header_Editor", "Editor (TwoWay)" },
                { "OneWayBindingView_CompareGrid_Header_OneWay", "OneWay (updates)" },
                { "OneWayBindingView_CompareGrid_Header_OneTime", "OneTime (frozen)" },
                { "OneWayBindingView_TestButtonsTitle", "🎮 Test buttons (change data in model)" },
                { "OneWayBindingView_ExplanationTitle", "📌 What OneWay binding demonstrates:" },
                { "OneWayBindingView_Bullet1", "OneWay elements show data but cannot change it" },
                { "OneWayBindingView_Bullet2", "When model changes, all OneWay elements update automatically" },
                { "OneWayBindingView_Bullet3", "Ideal for displaying information, statistics, progress" },
                { "OneWayBindingView_Bullet4", "Unlike OneTime, OneWay continues to track changes" },
                
                // TriggersView
                { "TriggersView_Title", "⚡ Triggers in WPF" },
                { "TriggersView_Subtitle", "Triggers allow changing the appearance of elements when certain conditions are met" },
                { "TriggersView_PropertyTriggerTitle", "🔹 1. PropertyTrigger (element property)" },
                { "TriggersView_PropertyTriggerExplanation", "Triggers when an element's property changes (IsMouseOver, IsFocused, IsChecked)" },
                { "Triggers_Button_HoverMouse", "Hover mouse" },
                { "Triggers_CheckBox_MarkMe", "Check me" },
                { "TriggersView_DataTriggerTitle", "🔹 2. DataTrigger (data binding)" },
                { "TriggersView_DataTriggerExplanation", "Triggers when data in the model changes (binding to a property)" },
                { "Triggers_Table_Header_Product", "Product" },
                { "Triggers_Table_Header_Price", "Price" },
                { "Triggers_Table_Header_Quantity", "Qty" },
                { "Triggers_Table_Header_Status", "Status" },
                { "TriggersView_Status_Normal", "Normal" },
                { "TriggersView_Status_Free", "Free" },
                { "TriggersView_Status_NotAvailable", "Out of stock" },
                { "TriggersView_Status_Premium", "Premium" },
                { "TriggersView_EventTriggerTitle", "🔹 3. EventTrigger (events and animation)" },
                { "TriggersView_EventTriggerExplanation", "Triggers on event occurrence (Click, Loaded, MouseEnter) and starts animation" },
                { "Triggers_Button_ClickMe", "Click me" },
                { "TriggersView_MultiTriggerTitle", "🔹 4. MultiTrigger and MultiDataTrigger (multiple conditions)" },
                { "TriggersView_MultiTriggerExplanation", "Triggers when multiple conditions are met simultaneously" },
                { "Triggers_Discount_ConditionsLabel", "Discount conditions:" },
                { "Triggers_CheckBox_RegularCustomer", "Regular customer" },
                { "Triggers_CheckBox_HasPromoCode", "Has promo code" },
                { "Triggers_CheckBox_IsHoliday", "Holiday" },
                { "Triggers_MyDiscountLabel", "Your discount:" },
                { "TriggersView_SummaryTitle", "📊 Triggers summary:" },
                { "TriggersView_Summary_PropertyTrigger", "PropertyTrigger" },
                { "TriggersView_Summary_PropertyTriggerDescription", "Reacts to element properties (IsMouseOver, IsFocused, etc.)" },
                { "TriggersView_Summary_DataTrigger", "DataTrigger" },
                { "TriggersView_Summary_DataTriggerDescription", "Reacts to data changes (binding to model)" },
                { "TriggersView_Summary_EventTrigger", "EventTrigger" },
                { "TriggersView_Summary_EventTriggerDescription", "Starts animation on events (Click, Loaded, etc.)" },
                { "TriggersView_Summary_MultiTrigger", "MultiTrigger" },
                { "TriggersView_Summary_MultiTriggerDescription", "Triggers when multiple conditions are met" }
            };

            _translations["ru"] = ruTranslations;
            _translations["en"] = enTranslations;
        }

        public string GetString(string key)
        {
            if (_translations.ContainsKey(_currentLanguage) &&
                _translations[_currentLanguage].ContainsKey(key))
            {
                return _translations[_currentLanguage][key];
            }

            // Если не найдено, возвращаем ключ
            return key;
        }

        public void SetLanguage(string languageCode)
        {
            if (_translations.ContainsKey(languageCode) && _currentLanguage != languageCode)
            {
                _currentLanguage = languageCode;
                LanguageChanged?.Invoke();
            }
        }
    }
}
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BindingProject.Model
{
    /// <summary>
    /// Модель Product с использованием CommunityToolkit.MVVM
    /// </summary>
    public partial class Product : ObservableObject
    {
        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private double _price;

        [ObservableProperty]
        private int _quantity;

        // Вычисляемое свойство - Total зависит от Price и Quantity
        public double Total => Price * Quantity;

        // Частичный метод, который вызывается после изменения Price
        partial void OnPriceChanged(double value)
        {
            OnPropertyChanged(nameof(Total));
        }

        // Частичный метод, который вызывается после изменения Quantity
        partial void OnQuantityChanged(int value)
        {
            OnPropertyChanged(nameof(Total));
        }
    }
}
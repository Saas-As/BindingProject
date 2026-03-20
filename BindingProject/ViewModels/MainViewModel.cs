using BindingProject.Model;
using BindingProject.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BindingProject.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Product _currentProduct;
        private string _productNameKey = "ProductName_Default";

        public MainViewModel()
        {
            CurrentProduct = new Product
            {
                Name = Strings.ResourceManager.GetString(_productNameKey, Strings.Culture) ?? "Товар",
                Price = 1000,
                Quantity = 1
            };
            LastUpdateTime = DateTime.Now;
            ShowExtraInfo = true;
        }

        public Product CurrentProduct
        {
            get => _currentProduct;
            set
            {
                _currentProduct = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _showExtraInfo;
        public bool ShowExtraInfo
        {
            get => _showExtraInfo;
            set
            {
                _showExtraInfo = value;
                OnPropertyChanged();
            }
        }

        private DateTime _lastUpdateTime;
        public DateTime LastUpdateTime
        {
            get => _lastUpdateTime;
            set
            {
                _lastUpdateTime = value;
                OnPropertyChanged();
            }
        }

        public void SetProductNameKey(string nameKey)
        {
            _productNameKey = nameKey;
            UpdateProductNameFromKey();
        }

        public void UpdateProductNameFromKey()
        {
            var localized = Strings.ResourceManager.GetString(_productNameKey, Strings.Culture);
            if (!string.IsNullOrEmpty(localized))
            {
                CurrentProduct.Name = localized;
            }
        }
    }
}

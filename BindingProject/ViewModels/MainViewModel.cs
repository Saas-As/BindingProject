using BindingProject.Model;
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

        public MainViewModel()
        {
            CurrentProduct = new Product
            {
                Name = "Товар",
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
        public void RefreshLanguage()
        {
            // Вызываем PropertyChanged для всех свойств, которые отображаются в интерфейсе
            OnPropertyChanged(nameof(CurrentProduct));
            OnPropertyChanged(nameof(LastUpdateTime));
            OnPropertyChanged(nameof(ShowExtraInfo));
        }
    }
}

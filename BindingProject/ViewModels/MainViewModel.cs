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
                Name = "Ножницы",
                Price = 150,
                Quantity = 10,
            };
            ShowExtraInfo = true; // По умолчанию показываем
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
    }
}

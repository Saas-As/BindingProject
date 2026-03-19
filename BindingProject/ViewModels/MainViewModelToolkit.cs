using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using BindingProject.Model;
using System;

namespace BindingProject.ViewModels
{
    public partial class MainViewModelToolkit : ObservableObject
    {
        [ObservableProperty]
        private Product _currentProduct;

        [ObservableProperty]
        private DateTime _lastUpdateTime;

        [ObservableProperty]
        private bool _showExtraInfo;

        public MainViewModelToolkit()
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

        // RelayCommand для TwoWayBindingView
        [RelayCommand]
        private void SetHighPrice()
        {
            CurrentProduct.Price = 99999;
            LastUpdateTime = DateTime.Now;
        }

        [RelayCommand]
        private void SetName(string name)
        {
            CurrentProduct.Name = "Новый товар";
            LastUpdateTime = DateTime.Now;
        }

        // RelayCommand для OneTimeBindingView
        [RelayCommand]
        private void SetLaptop()
        {
            CurrentProduct.Name = "Ноутбук";
            CurrentProduct.Price = 75000;
            CurrentProduct.Quantity = 2;
            LastUpdateTime = DateTime.Now;
        }

        [RelayCommand]
        private void SetPhone()
        {
            CurrentProduct.Name = "Телефон";
            CurrentProduct.Price = 45000;
            CurrentProduct.Quantity = 5;
            LastUpdateTime = DateTime.Now;
        }

        [RelayCommand]
        private void SetPrice(object price)
        {
                CurrentProduct.Price = 50000;
                LastUpdateTime = DateTime.Now;
        }

        [RelayCommand]
        private void ResetProduct()
        {
            CurrentProduct.Name = "Товар";
            CurrentProduct.Price = 1000;
            CurrentProduct.Quantity = 1;
            LastUpdateTime = DateTime.Now;
        }

        // RelayCommand для OneWayBindingView
        [RelayCommand]
        private void SetPrice25000()
        {
            CurrentProduct.Price = 25000;
            LastUpdateTime = DateTime.Now;
        }

        [RelayCommand]
        private void SetPrice75000()
        {
            CurrentProduct.Price = 75000;
            LastUpdateTime = DateTime.Now;
        }
    }
}
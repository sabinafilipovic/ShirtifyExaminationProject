using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExaminationProject.Model;
using ExaminationProject.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationProject.ViewModel
{
    public partial class DetailViewModel : ObservableObject
    {
        public ShirtService ShirtService => ShirtService.Instance;

        [ObservableProperty]
        public Shirt selectedShirt;

        [ObservableProperty]
        public string color;

        [ObservableProperty]
        public string category;

        [ObservableProperty]
        public string history;

        [ObservableProperty]
        public int amountUsed;

        [ObservableProperty]
        public Shirt dailyShirt;

        public DetailViewModel()
        {
            dailyShirt = ShirtService.CurrentShirt;
        }

        [RelayCommand]
        async Task GoToInventory()
        {
            await AppShell.Current.GoToAsync("InventoryPage");
        }

        [RelayCommand]
        async Task UseShirt()
        {
            ShirtService.SetCurrentShirt(dailyShirt);
            await AppShell.Current.GoToAsync("///MainPage");
        }
    }
}

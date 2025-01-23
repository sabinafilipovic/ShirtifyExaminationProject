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
        public string lastTimeUsed;

        [ObservableProperty]
        public int amountUsed;

        [ObservableProperty]
        public Shirt dailyShirt;

        public DetailViewModel()
        {
            dailyShirt = ShirtService.CurrentShirt;
            amountUsed = ShirtService.AmountOfTimesUsed;
            lastTimeUsed = ShirtService.LastTimeUsed.ToString("dd MMM yyyy");
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
            ShirtService.AmountOfTimesUsed++;
            await AppShell.Current.GoToAsync("///MainPage");
        }
    }
}

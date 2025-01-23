using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ExaminationProject.Services;
using ExaminationProject.Model;


namespace ExaminationProject.ViewModel
{
    public partial class InventoryViewModel : CrudViewModel
    {
        public ShirtService ShirtService => ShirtService.Instance;

        private readonly PhotoService _photoService;

        public InventoryViewModel(PhotoService photoService) : base(photoService)
        {
            _photoService = photoService;
        }



        [ObservableProperty]
        public Shirt selectedItem;
        
        
        

        [RelayCommand]
        async void UseShirt(Shirt selectedShirt)
        {
            if (selectedShirt == null)
                return;

            ShirtService.CurrentShirt = selectedShirt;

            await AppShell.Current.GoToAsync("DetailPage");
        }

        [RelayCommand]
        async Task RegisterNewShirt()
        {
            await AppShell.Current.GoToAsync("RegisterShirtPage");
        }
    }

}

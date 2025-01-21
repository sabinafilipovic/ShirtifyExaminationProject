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
        private readonly PhotoService _photoService;

        public InventoryViewModel(PhotoService photoService) : base(photoService)
        {
            _photoService = photoService;
        }

        [ObservableProperty]
        public Shirt selectedPicture;
        
        
        

        [RelayCommand]
        async void UseShirt()
        {
            //send "current" shirt to database.
            //Set "current" shirt as your "Selected" shirt for today.
            //Send user back to main page
            await AppShell.Current.GoToAsync("//MainPage");
        }

        [RelayCommand]
        async void RegisterNewShirt()
        {
            await AppShell.Current.GoToAsync("RegisterShirtPage");
        }
    }

}

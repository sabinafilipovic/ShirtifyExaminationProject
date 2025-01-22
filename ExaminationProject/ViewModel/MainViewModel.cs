using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Storage;
using ExaminationProject.Model;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using ExaminationProject.Services;
using ExaminationProject.View;

namespace ExaminationProject.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        public ShirtService ShirtService => ShirtService.Instance;

        [ObservableProperty]
        ObservableCollection<string> items = new ObservableCollection<string>();

        [ObservableProperty]
        ImageSource savedImageSource;

        [ObservableProperty]
        string text;

        [ObservableProperty]
        Shirt dailyShirt;

        [ObservableProperty]
        string shirtName;

        [ObservableProperty]
        string shirtName2;

        [ObservableProperty]
        string shirtColor;

        [ObservableProperty]
        ObservableCollection<Shirt> shirts = new ObservableCollection<Shirt>();

        private bool isShirtRandomized = false;

        public Shirt CurrentShirt
        {
            get => ShirtService.CurrentShirt;
            set
            {
                ShirtService.SetCurrentShirt(value);
                OnPropertyChanged(nameof(CurrentShirt));
            }
        }

        public MainViewModel()
        {
            // Ensure shirts are loaded and a shirt is randomized on startup
            dailyShirt = ShirtService.CurrentShirt;
        }

        public Shirt getDailyShirt() 
        {
            return dailyShirt;
        }

        public void loadShirts() 
        {
            Shirts.Clear();

            var shirtsFromDatabase = DatabaseService.GetShirts();
            foreach (var shirt in shirtsFromDatabase)
            {
                Shirts.Add(shirt);
            }
        }

        [RelayCommand]
        async void ClickButton()
        {
            if (string.IsNullOrEmpty(Text))
            {
                return;
            }
            /*Shirt newShirt = new Shirt()
           {
               Name = shirtName,
               Color = "White"
           };

           //add our item
           DatabaseService.AddShirt(newShirt);
           Shirts.Add(newShirt);*/

            //add our item
            Items.Add(Text);
        }

        [RelayCommand]
        async void GoToPage1()
        {
            await AppShell.Current.GoToAsync("Page1");
        }

        [RelayCommand]
        async Task GoToAdminPage()
        {
            await AppShell.Current.GoToAsync(nameof(AdminPage));
        }

        [RelayCommand]
        async void GoToCrudPage()
            {
                await AppShell.Current.GoToAsync(nameof(CrudPage));
            }

        [RelayCommand]
        async void GoToDetailPage()
        {
            AppShell.Current.GoToAsync("DetailPage");
        }
    }
}
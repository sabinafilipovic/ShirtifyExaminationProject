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
        private readonly ShirtService _shirtService;
        public ShirtService ShirtService => ShirtService.Instance;

        [ObservableProperty]
        private Shirt _dailyShirt;

        [ObservableProperty]
        ObservableCollection<string> items = new ObservableCollection<string>();

        [ObservableProperty]
        ImageSource savedImageSource;

        [ObservableProperty]
        string text;

        // Removed duplicate property
        // [ObservableProperty]
        // Shirt dailyShirt;

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
            _shirtService = ShirtService.Instance;
            _shirtService.CurrentShirtChanged += OnCurrentShirtChanged;
            DailyShirt = _shirtService.CurrentShirt;

            if (DailyShirt == null)
            {
                _shirtService.LoadShirts();

                if (_shirtService.Shirts.Count > 0)
                {
                    _shirtService.RandomizeShirt();
                }

                return;
            }
            

        }
        private void OnCurrentShirtChanged(object sender, EventArgs e)
        {
            DailyShirt = _shirtService.CurrentShirt;
        }

        [RelayCommand]
        async Task GoToDetailPageAsync(Shirt selectedShirt)
        {
            await Shell.Current.GoToAsync(nameof(DetailPage), true, new Dictionary<string, object>
            {
                { "SelectedShirt", selectedShirt }
            });
        }

        public Shirt getDailyShirt()
        {
            return _dailyShirt;
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
        async Task ClickButton()
        {
            if (string.IsNullOrEmpty(Text))
            {
                return;
            }

            Items.Add(Text);
        }

        [RelayCommand]
        async Task GoToPage1()
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
        async void GoToInventory()
        {
            await AppShell.Current.GoToAsync(nameof(InventoryPage));
        }

        // Har en ny metod som heter GoToDetailPageAsync
        //[RelayCommand]
        //async void GoToDetailPage()
        //{
        //    AppShell.Current.GoToAsync("DetailPage");
        //}
    }
}
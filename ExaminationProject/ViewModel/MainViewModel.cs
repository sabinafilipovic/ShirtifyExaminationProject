using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExaminationProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationProject.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<string> items = new ObservableCollection<string>();

        [ObservableProperty]
        string text;

        [ObservableProperty]
        string shirtName;

        [ObservableProperty]
        string shirtName2;

        [ObservableProperty]
        string shirtColor;

        [ObservableProperty]
        ObservableCollection<Shirt> shirts = new ObservableCollection<Shirt>();

        public MainViewModel()
        {
            loadShirts();
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
        public void DeleteShirt(int shirtId)
        {
            if (shirtId == 0)
            {
                return;
            }


            // Remove the shirt from the database
            DatabaseService.RemoveShirt(shirtId);

            loadShirts();
        }

        [RelayCommand]
        async void ClickButton()
        {
            if (string.IsNullOrEmpty(shirtName))
            {
                return;
            }

            Shirt newShirt = new Shirt()
            {
                Name = shirtName,
                Color = "White"
            };

            //add our item
            DatabaseService.AddShirt(newShirt);
            Shirts.Add(newShirt);
        }

        [RelayCommand]
        async void GoToPage1()
        {
            AppShell.Current.GoToAsync("Page1");
        }
       
    }
}
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExaminationProject.Model;
using System.Collections.ObjectModel;

namespace ExaminationProject.ViewModel
{
    public partial class CrudViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Shirt> shirts = new ObservableCollection<Shirt>();

        [ObservableProperty]
        string shirtName;

        [ObservableProperty]
        string shirtColor;

        public CrudViewModel()
        {
            LoadShirts();
        }

        private void LoadShirts()
        {
            Shirts.Clear();
            var shirtsFromDb = DatabaseService.GetShirts();
            foreach (var shirt in shirtsFromDb)
            {
                Shirts.Add(shirt);
            }
        }

        [RelayCommand]
        public void AddShirt()
        {
            if (string.IsNullOrWhiteSpace(ShirtName) || string.IsNullOrWhiteSpace(ShirtColor))
                return;

            var newShirt = new Shirt
            {
                Name = ShirtName,
                Color = ShirtColor
            };

            DatabaseService.AddShirt(newShirt);
            LoadShirts();

            ShirtName = string.Empty;
            ShirtColor = string.Empty;
        }

        [RelayCommand]
        public void EditShirt(int shirtId)
        {
            var shirtToEdit = DatabaseService.GetShirtById(shirtId);
            if (shirtToEdit != null)
            {
                shirtToEdit.Name = ShirtName;
                shirtToEdit.Color = ShirtColor;

                DatabaseService.UpdateShirt(shirtToEdit);
                LoadShirts();
            }
        }

        [RelayCommand]
        public void DeleteShirt(int shirtId)
        {
            DatabaseService.RemoveShirt(shirtId);
            LoadShirts();
        }
    }
}
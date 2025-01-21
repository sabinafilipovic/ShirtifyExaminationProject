using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExaminationProject.Model;
using System.Collections.ObjectModel;

namespace ExaminationProject.ViewModel
{
    public partial class AdminColorsViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Model.Color> colors = new();

        [ObservableProperty]
        string newColorName;

        [ObservableProperty]
        string editColorName;

        private Model.Color selectedColor;
        public Model.Color SelectedColor
        {
            get => selectedColor;
            set
            {
                if (SetProperty(ref selectedColor, value))
                {
                    editColorName = selectedColor?.Name;
                }
            }
        }

        public AdminColorsViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            Colors.Clear();
            foreach (var color in DatabaseService.GetColors())
                Colors.Add(color);
        }

        [RelayCommand]
        void AddColor()
        {
            if (string.IsNullOrWhiteSpace(NewColorName)) return;

            var newColor = new Model.Color { Name = NewColorName };
            DatabaseService.AddColor(newColor);
            Colors.Add(newColor);

            NewColorName = string.Empty; // Clear the input
        }

        [RelayCommand]
        void EditColor()
        {
            if (SelectedColor == null || string.IsNullOrWhiteSpace(EditColorName)) return;

            SelectedColor.Name = EditColorName;
            DatabaseService.UpdateColor(SelectedColor); // Update in DB
            LoadData(); // Refresh the list

            EditColorName = string.Empty; // Clear the input
        }

        [RelayCommand]
        void DeleteColor(Model.Color color)
        {
            DatabaseService.DeleteColor(color.Id);
            Colors.Remove(color);
        }

        [RelayCommand]
        async Task GoBack()
        {
            await AppShell.Current.GoToAsync("///MainPage");
        }
    }
}

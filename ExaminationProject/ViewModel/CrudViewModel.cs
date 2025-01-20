using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExaminationProject.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationProject.ViewModel
{
    public partial class CrudViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Shirt> shirts = new ObservableCollection<Shirt>();

        [ObservableProperty]
        ObservableCollection<Category> categories = new();

        [ObservableProperty]
        ObservableCollection<Model.Color> colors = new();

        [ObservableProperty]
        string shirtBrand;

        [ObservableProperty]
        int shirtColor;

        [ObservableProperty]
        Category selectedCategory;

        [ObservableProperty]
        Model.Color selectedColor;

        public CrudViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            Shirts.Clear();
            foreach (var shirt in DatabaseService.GetShirts())
                Shirts.Add(shirt);

            Categories.Clear();
            foreach (var category in DatabaseService.GetCategories())
                Categories.Add(category);

            Colors.Clear();
            foreach (var color in DatabaseService.GetColors())
                Colors.Add(color);
        }

        [RelayCommand]
        public async Task AddShirt()
        {
            if (string.IsNullOrWhiteSpace(ShirtBrand)) return;

            var categoryId = Categories.FirstOrDefault(c => c.Id == SelectedCategory?.Id)?.Id ?? 0;
            var colorId = Colors.FirstOrDefault(c => c.Id == SelectedColor?.Id)?.Id ?? 0;

            if (categoryId == 0 || colorId == 0) return;

            var newShirt = new Shirt
            {
                Brand = ShirtBrand,
                Category_Id = categoryId,
                Color_Id = colorId
            };

            DatabaseService.AddShirt(newShirt);
            Shirts.Add(newShirt);
        }

        [RelayCommand]
        public async Task AddCategory(string categoryName)
        {
            if (!string.IsNullOrWhiteSpace(categoryName))
            {
                var newCategory = new Category { Name = categoryName };
                DatabaseService.AddCategory(newCategory);
                Categories.Add(newCategory);
            }
        }

        [RelayCommand]
        public async Task AddColor(string colorName)
        {
            if (!string.IsNullOrWhiteSpace(colorName))
            {
                var newColor = new Model.Color { Name = colorName };
                DatabaseService.AddColor(newColor);
                Colors.Add(newColor);
            }
        }

        [RelayCommand]
        public async Task EditShirt(int shirtId)
        {
            var shirtToEdit = DatabaseService.GetShirtById(shirtId);
            if (shirtToEdit != null)
            {
                shirtToEdit.Brand = ShirtBrand;
                shirtToEdit.Color_Id = ShirtColor;

                DatabaseService.UpdateShirt(shirtToEdit);
                LoadData();
            }
        }

        [RelayCommand]
        public async Task DeleteShirt(int shirtId)
        {
            DatabaseService.RemoveShirt(shirtId);
            LoadData();
        }
    }
}

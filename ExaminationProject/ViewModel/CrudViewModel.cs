using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExaminationProject.Model;
using ExaminationProject.Services;
using System.Collections.ObjectModel;

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

        private readonly PhotoService _photoService;

        [ObservableProperty]
        int shirtColor;

        [ObservableProperty]
        Category selectedCategory; // Selected Category Name

        [ObservableProperty]
        Model.Color selectedColor;    // Selected Color Name

        public CrudViewModel(PhotoService photoservice)
        {
            _photoService = photoservice;
            LoadData();
        }

        private void LoadData()
        {
            // Load Shirts
            Shirts.Clear();
            foreach (var shirt in DatabaseService.GetShirts())
                Shirts.Add(shirt);

            // Load Categories
            Categories.Clear();
            foreach (var category in DatabaseService.GetCategories())
                Categories.Add(category);

            // Load Colors
            Colors.Clear();
            foreach (var color in DatabaseService.GetColors())
                Colors.Add(color);
        }

        [RelayCommand]
        async public Task AddShirt()
        {
            //Console.WriteLine($"Brand : {ShirtBrand}, Category: {selectedCategory}, Color: {selectedColor}");
            
            if (string.IsNullOrWhiteSpace(ShirtBrand))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Beskriv tröjan.", "OK");
                return;
                
            }
            
            if (SelectedCategory == null || SelectedColor == null)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Välj kategori och färg.", "OK");
                return;
            } 

            }

            // Find the corresponding IDs for the selected category and color
            var categoryId = Categories.FirstOrDefault(c => c.Id == SelectedCategory.Id)?.Id ?? 0;
            var colorId = Colors.FirstOrDefault(c => c.Id == SelectedColor.Id)?.Id ?? 0;
            try
            {
                // Capture the photo using PhotoService
                var pictureId = await _photoService.CapturePhotoAsync();

            if (categoryId == 0 || colorId == 0)
            {
                
                return;

                
            }
                
                if (pictureId == 0)
                {
                    System.Diagnostics.Debug.WriteLine("⚠️ No photo was captured.");
                    return;
                }

                // Create a new Shirt object
                var newShirt = new Shirt
                {
                    Brand = ShirtBrand,
                    Category_Id = SelectedCategory.Id,
                    Color_Id = SelectedColor.Id,
                    Picture_Id = pictureId
                };

                // Save to the database
                DatabaseService.AddShirt(newShirt);
                Shirts.Add(newShirt); // Update the UI collection
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ Error adding shirt: {ex.Message}");
            }
            DatabaseService.AddShirt(newShirt);
            Shirts.Add(newShirt);

            await AppShell.Current.GoToAsync("InventoryPage");
        }

        [RelayCommand]
        public void AddCategory(string categoryName)
        {
            if (!string.IsNullOrWhiteSpace(categoryName))
            {
                var newCategory = new Category { Name = categoryName };
                DatabaseService.AddCategory(newCategory);
                Categories.Add(newCategory);
            }
        }

        [RelayCommand]
        public void AddColor(string colorName)
        {
            if (!string.IsNullOrWhiteSpace(colorName))
            {
                var newColor = new Model.Color { Name = colorName };
                DatabaseService.AddColor(newColor);
                Colors.Add(newColor);
            }
        }

        [RelayCommand]
        public void EditShirt(int shirtId)
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
        public void DeleteShirt(int shirtId)
        {
            if (shirtId == 0)
            {
                return;
            }
            DatabaseService.RemoveShirt(shirtId);
            LoadData();
        }
    }
}
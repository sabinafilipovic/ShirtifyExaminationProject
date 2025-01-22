using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExaminationProject.Model;
using ExaminationProject.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ExaminationProject.ViewModel
{
    public partial class CrudViewModel : ObservableObject
    {
        [ObservableProperty]
        public int pictureId = 0;

        [ObservableProperty]
        ObservableCollection<Shirt> shirts = new ObservableCollection<Shirt>();

        [ObservableProperty]
        ObservableCollection<Category> categories = new();

        [ObservableProperty]
        ObservableCollection<Model.Color> colors = new();

        [ObservableProperty]
        string shirtBrand;

        [ObservableProperty]
        string pictureFilepath;

        private readonly PhotoService _photoService;

        [ObservableProperty]
        int shirtColor;

        [ObservableProperty]
        Shirt selectedShirt;

        [ObservableProperty]
        Category selectedCategory;

        [ObservableProperty]
        Model.Color selectedColor;

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
        async Task CapturePhoto()
        {
            pictureId = await _photoService.CapturePhotoAsync();
            pictureFilepath = DatabaseService.GetFilepathById(pictureId);
            OnPropertyChanged(nameof(PictureFilepath));
        }

        [RelayCommand]
        async Task SelectPhoto()
        {
            var selectedFilePath = await _photoService.SelectPhotoFromGalleryAsync();

            if (selectedFilePath == null)
            {
                System.Diagnostics.Debug.WriteLine("No photo was selected or the operation was canceled.");
                return;
            }

            pictureId = selectedFilePath.Id;

            if (!string.IsNullOrEmpty(selectedFilePath.Filepath))
            {
                PictureFilepath = selectedFilePath.Filepath;
                OnPropertyChanged(nameof(PictureFilepath));
            }
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

        

            // Find the corresponding IDs for the selected category and color
            var categoryId = Categories.FirstOrDefault(c => c.Id == SelectedCategory.Id)?.Id ?? 0;
            var colorId = Colors.FirstOrDefault(c => c.Id == SelectedColor.Id)?.Id ?? 0;
            try
            
        {
                // Capture the photo using PhotoService
                //var pictureId = await _photoService.CapturePhotoAsync();

                

                if (categoryId == 0 || colorId == 0)
            {
                
                return;

                
            }
                
                if (pictureId == 0)
                {
                    System.Diagnostics.Debug.WriteLine("⚠️ Bild Saknas");
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
           

            await AppShell.Current.GoToAsync("InventoryPage");
        }

        [RelayCommand]
        public void EditShirt()
        {
            if (SelectedShirt == null)
                return;

            // Update the selected shirt's properties
            if (!string.IsNullOrWhiteSpace(ShirtBrand))
                SelectedShirt.Brand = ShirtBrand;

            if (SelectedCategory != null)
                SelectedShirt.Category_Id = SelectedCategory.Id;

            if (SelectedColor != null)
                SelectedShirt.Color_Id = SelectedColor.Id;

            // Update the database
            DatabaseService.UpdateShirt(SelectedShirt);

            // Reload the data to reflect changes
            LoadData();

            // Update the selected shirt references to reflect changes in the UI
            SelectedCategory = Categories.FirstOrDefault(c => c.Id == SelectedShirt.Category_Id);
            SelectedColor = Colors.FirstOrDefault(c => c.Id == SelectedShirt.Color_Id);
            ShirtBrand = SelectedShirt.Brand;
        }

        [RelayCommand]
        public void DeleteShirt()
        {
            if (SelectedShirt == null)
                return;

            DatabaseService.RemoveShirt(SelectedShirt.Id);
            Shirts.Remove(SelectedShirt);
        }

        [RelayCommand]
        async Task GoBack()
        {
            await AppShell.Current.GoToAsync("///MainPage");
        }
    }
}

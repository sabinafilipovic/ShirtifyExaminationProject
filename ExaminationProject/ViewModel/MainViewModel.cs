using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Storage;
using ExaminationProject.Model;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using ExaminationProject.Services;

namespace ExaminationProject.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<string> items = new ObservableCollection<string>();

        [ObservableProperty]
        ImageSource savedImageSource;

        [ObservableProperty]
        string text;

        private readonly PhotoService _photoService = new PhotoService();

        [ObservableProperty]
        string shirtName;

        [ObservableProperty]
        string shirtName2;

        [ObservableProperty]
        string shirtColor;

        [ObservableProperty]
        ObservableCollection<Shirt> shirts = new ObservableCollection<Shirt>();

        public MainViewModel(PhotoService photoService)
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
        public async void TakePhoto()
        {
            System.Diagnostics.Debug.WriteLine("✅ LYCKADES KALLA PÅ METOD 'TAKEPHOTO'");

            try
            {
                string photoPath = await _photoService.CapturePhotoAsync();

                if (!string.IsNullOrEmpty(photoPath))
                {
                    SavedImageSource = ImageSource.FromFile(photoPath);
                    System.Diagnostics.Debug.WriteLine($"✅ FOTO SPARAT I {photoPath}");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("⚠️ INGEN BILD TAGEN");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ Error capturing photo: {ex.Message}");
            }
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
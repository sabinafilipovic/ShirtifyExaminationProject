using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Storage;
using ExaminationProject.Model;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;

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
        async void GoToCrudPage()
            {
                await AppShell.Current.GoToAsync(nameof(CrudPage));
            }

        [RelayCommand]
        public async void TakePhoto()
        {
            System.Diagnostics.Debug.WriteLine("✅ LYCKADES KALLA PÅ METOD");

            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();
                System.Diagnostics.Debug.WriteLine("✅ INGA KONSTIGHETER MED BEHÖRIGHET");

                if (photo != null)
                {
                    string localFilePath = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);

                    System.Diagnostics.Debug.WriteLine($"✅ DITT FOTO HAR SPARATS SOM {photo.FileName} I {localFilePath}");

                    using Stream sourceStream = await photo.OpenReadAsync();
                    using FileStream localFileStream = File.OpenWrite(localFilePath);
                    await sourceStream.CopyToAsync(localFileStream);

                    SavedImageSource = ImageSource.FromFile(localFilePath);
                    System.Diagnostics.Debug.WriteLine("✅ WE MADE IT");
                }
            }
        }

        [RelayCommand]
        async void GoToDetailPage()
        {
            AppShell.Current.GoToAsync("DetailPage");
        }



    }
}
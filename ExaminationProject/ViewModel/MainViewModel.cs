using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Storage;
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

        [RelayCommand]
        async void ClickButton()
        {
            if (string.IsNullOrEmpty(Text))
            {
                return;
            }

            Items.Add(Text);

            Text = string.Empty;
        }

        [RelayCommand]
        async void GoToPage1()
        {
            await AppShell.Current.GoToAsync("Page1");
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
    }
}
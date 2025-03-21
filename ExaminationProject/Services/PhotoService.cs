﻿using Microsoft.Maui.Storage;
using System.IO;
using System.Threading.Tasks;
using ExaminationProject.Model;

namespace ExaminationProject.Services
{
    public class PhotoService
    {
        public async Task<int> CapturePhotoAsync()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                try
                {
                    // Capture the photo
                    FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                    if (photo == null)
                    {
                        System.Diagnostics.Debug.WriteLine("Photo capture was canceled.");
                        return 0; // Exit gracefully
                    }

                    if (photo != null)
                    {
                        // Platform-independent directory for saving photos
                        string fileName = photo.FileName;
                        string localFilePath = Path.Combine(FileSystem.AppDataDirectory, fileName);

                        // Save the photo temporarily in AppDataDirectory
                        using (Stream sourceStream = await photo.OpenReadAsync())
                        using (FileStream localFileStream = File.OpenWrite(localFilePath))
                        {
                            await sourceStream.CopyToAsync(localFileStream);
                        }

                        // Save the photo to the gallery
                        string galleryPath = await SaveToGalleryAsync(fileName, localFilePath);

                        // Save the photo information to the database
                        Picture picture = new Picture
                        {
                            Filepath = galleryPath
                        };

                        DatabaseService.AddPicture(picture); 

                        return picture.Id; // Return the gallery paths ID
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"❌ Error capturing photo: {ex.Message}");
                }
            }

            return 0; // Return null if no photo was captured or an error occurred
        }

        public async Task<Picture> SelectPhotoFromGalleryAsync()
        {
            try
            {
                // Open the gallery picker
                FileResult photo = await MediaPicker.Default.PickPhotoAsync();

                if (photo == null)
                {
                    System.Diagnostics.Debug.WriteLine("Photo selection was canceled by the user.");
                    return null; // Exit and return null
                }

                if (photo != null)
                {
                    // Save the selected photo temporarily in AppDataDirectory
                    string fileName = photo.FileName;
                    string localFilePath = Path.Combine(FileSystem.AppDataDirectory, fileName);

                    using (Stream sourceStream = await photo.OpenReadAsync())
                    using (FileStream localFileStream = File.OpenWrite(localFilePath))
                    {
                        await sourceStream.CopyToAsync(localFileStream);
                    }

                    var newPicture = new Picture
                    {
                        Filepath = localFilePath
                    };
                    DatabaseService.AddPicture(newPicture);

                    return newPicture; // Return the local file path of the selected photo
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ Error selecting photo: {ex.Message}");
            }

            return null; // Return null if no photo was selected or an error occurred
        }

        private async Task<string> SaveToGalleryAsync(string fileName, string sourceFilePath)
        {
#if ANDROID
            // Android-specific implementation
            string picturesDirectory = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures).AbsolutePath;
            string destinationPath = Path.Combine(picturesDirectory, fileName);

            // Copy file to Pictures directory
            File.Copy(sourceFilePath, destinationPath, overwrite: true);

            // Notify the gallery to update
            var context = Android.App.Application.Context;
            Android.Media.MediaScannerConnection.ScanFile(context, new[] { destinationPath }, null, null);

            return destinationPath;

#elif IOS
            // iOS-specific implementation
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            string destinationPath = Path.Combine(documentsPath, fileName);

            // Copy file to Camera Roll
            File.Copy(sourceFilePath, destinationPath, overwrite: true);

            // Notify Photos app to update
            await Task.CompletedTask; // No additional work needed on iOS
            return destinationPath;

#else
            throw new PlatformNotSupportedException("Saving to gallery is not supported on this platform.");
#endif
        }
    }
}
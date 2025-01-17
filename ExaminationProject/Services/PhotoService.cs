using Microsoft.Maui.Storage;
using System.IO;
using System.Threading.Tasks;
using ExaminationProject.Model;

namespace ExaminationProject.Services
{
    public class PhotoService
    {
        public async Task<string> CapturePhotoAsync()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {
                    // Save the photo to a local path
                    string localFilePath = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);

                    using Stream sourceStream = await photo.OpenReadAsync();
                    using FileStream localFileStream = File.OpenWrite(localFilePath);
                    await sourceStream.CopyToAsync(localFileStream);

                    return localFilePath; // Return the local file path
                }
            }

            return null; // Return null if no photo was captured
        }
    }
}
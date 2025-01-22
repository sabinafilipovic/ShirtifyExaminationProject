using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExaminationProject.Services;




namespace ExaminationProject.ViewModel
{
    public partial class RegisterShirtViewModel : CrudViewModel
    {
        private readonly PhotoService _photoService;

        public RegisterShirtViewModel(PhotoService photoService) : base(photoService)
        {
            _photoService = photoService;
        }


        [ObservableProperty]
        string pictureFilepath;        

        [RelayCommand]
        async void CapturePhoto()
        {
            pictureId = await _photoService.CapturePhotoAsync();

            pictureFilepath = DatabaseService.GetFilepathById(pictureId);


            // Update the page
            OnPropertyChanged(nameof(PictureFilepath));
        }

        [RelayCommand]
        async void SelectPhoto()
        {
            var selectedFilePath = await _photoService.SelectPhotoFromGalleryAsync();

            if (selectedFilePath == null) 
            {
                System.Diagnostics.Debug.WriteLine("No photo was selected or the operation was canceled.");
                return; // Exit the method gracefully
            }
            pictureId = selectedFilePath.Id;

            if (!string.IsNullOrEmpty(selectedFilePath.Filepath))
            {
                pictureFilepath = selectedFilePath.Filepath;
                OnPropertyChanged(nameof(PictureFilepath));
            }
        }
    }
}

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

        [RelayCommand]
        async void GoBack()
        {
            if (Shell.Current.Navigation.NavigationStack.Count > 1)
            {
                await Shell.Current.Navigation.PopAsync();
            }
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
    }
}

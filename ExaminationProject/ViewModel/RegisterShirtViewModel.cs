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
    }
}

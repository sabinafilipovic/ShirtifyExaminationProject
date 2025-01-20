using CommunityToolkit.Mvvm.Input;


namespace ExaminationProject.ViewModel
{
    public partial class RegisterShirtViewModel : CrudViewModel
    {
        
        [RelayCommand]
        async void GoBack()
        {
            if (Shell.Current.Navigation.NavigationStack.Count > 1)
            {
                await Shell.Current.Navigation.PopAsync();
            }
        }
    }
}

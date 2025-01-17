using CommunityToolkit.Mvvm.Input;


namespace ExaminationProject.ViewModel
{
   public partial class RegisterShirtViewModel : CrudViewModel
    {
        

        [RelayCommand]
        async void RegisterShirt()
        {
            //send shirt to database
            //send user back to inventory
            await AppShell.Current.GoToAsync("InventoryPage");
        }

    }
}

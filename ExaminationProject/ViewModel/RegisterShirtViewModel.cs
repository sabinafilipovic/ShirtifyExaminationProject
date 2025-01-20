using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationProject.ViewModel
{
   public partial class RegisterShirtViewModel : ObservableObject
    {
        [RelayCommand]
        async Task RegisterShirt()
        {
            //send shirt to database
            //send user back to inventory
            await AppShell.Current.GoToAsync("InventoryPage");
        }

    }
}

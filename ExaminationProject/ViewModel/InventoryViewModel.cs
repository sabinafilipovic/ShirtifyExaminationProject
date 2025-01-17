using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExaminationProject.ViewModel
{
    public partial class InventoryViewModel : ObservableObject
    {
        [RelayCommand]
        async void UseShirt()
        {
            //send "current" shirt to database.
            //Set "current" shirt as your "Selected" shirt for today.
            //Send user back to homepage
            AppShell.Current.GoToAsync("..");


        }

        [RelayCommand]
        async void RegisterNewShirt()
        {
            AppShell.Current.GoToAsync("RegisterShirtPage");
        }
    }

}

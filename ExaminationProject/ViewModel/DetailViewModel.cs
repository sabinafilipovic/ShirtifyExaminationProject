using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationProject.ViewModel
{
    public partial class DetailViewModel : ObservableObject
    {
        [ObservableProperty]
        public string color;
        

        [ObservableProperty]
        public string category;

        [ObservableProperty]
        public string history;
        //behöver vara en klass som innehåller en string för datum och en string för färgen på skjortan.

        [ObservableProperty]
        public int amountUsed;





        [RelayCommand]
        async void GoToInventory()
        {
            AppShell.Current.GoToAsync("InventoryPage");
        }

        [RelayCommand]
        async void UseShirt()
        {
            //send "current" shirt to database.
            //Set "current" shirt as your "Selected" shirt for today.
            //Send user back to homepage
            AppShell.Current.GoToAsync("..");


        }



    }
}

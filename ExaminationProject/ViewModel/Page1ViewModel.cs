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
    public partial class Page1ViewModel : ObservableObject
    {
        [RelayCommand]
        async void GoToHome()
        {
            AppShell.Current.GoToAsync("..");
        }

    }
}

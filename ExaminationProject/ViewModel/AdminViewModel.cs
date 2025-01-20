using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExaminationProject.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationProject.ViewModel
{
    public partial class AdminViewModel : ObservableObject
    {
        [RelayCommand]
        async void GoToAdminCategoriesPage()
        {
            await AppShell.Current.GoToAsync("AdminCategoriesPage");
        }
        [RelayCommand]
        async void GoToAdminColorsPage()
        {
            await AppShell.Current.GoToAsync(nameof(AdminColorsPage));
        }

        [RelayCommand]
        async Task GoBack()
        {
            await AppShell.Current.GoToAsync("///MainPage");
        }
    }
}

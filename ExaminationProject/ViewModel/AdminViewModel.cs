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
        async void GoToAdminShirtsPage()
        {
            await AppShell.Current.GoToAsync(nameof(CrudPage));
        }
        [RelayCommand]
        async Task GoToAdminCategoriesPage()
        {
            await AppShell.Current.GoToAsync(nameof(AdminCategoriesPage));
        }
        [RelayCommand]
        async Task GoToAdminColorsPage()
        {
            await AppShell.Current.GoToAsync(nameof(AdminColorsPage));
        }

        
    }
}

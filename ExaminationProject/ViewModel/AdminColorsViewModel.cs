using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExaminationProject.Model;
using ExaminationProject.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationProject.ViewModel
{
    public partial class AdminColorsViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Model.Color> colors = new();


        [RelayCommand]
        async Task GoBack()
        {
            await AppShell.Current.GoToAsync("///MainPage");
        }
    }
}

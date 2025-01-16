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
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<string> items = new ObservableCollection<string>();

        [ObservableProperty]
        string text;

        [RelayCommand]
        async void ClickButton()
        {

            if (string.IsNullOrEmpty(Text))
            {
                return;
            }

            //add our item
            Items.Add(Text);

            Text = string.Empty;
        }

        [RelayCommand]
        async void GoToPage1()
        {
            AppShell.Current.GoToAsync("Page1");
        }
       
    }
}
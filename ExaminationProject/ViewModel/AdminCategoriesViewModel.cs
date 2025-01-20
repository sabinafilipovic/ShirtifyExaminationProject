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
    public partial class AdminCategoriesViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Category> categories = new();

        [ObservableProperty]
        string newCategoryName;

        [ObservableProperty]
        string editCategoryName;

        [ObservableProperty]
        Category selectedCategory;

        public AdminCategoriesViewModel() 
        {
            LoadData();
        }

        private void LoadData()
        {
            // Load Categories
            Categories.Clear();
            foreach (var category in DatabaseService.GetCategories())
                Categories.Add(category);
        }

        [RelayCommand]
        void AddCategory()
        {
            if (string.IsNullOrWhiteSpace(NewCategoryName)) return;

            var newCategory = new Category { Name = NewCategoryName };
            DatabaseService.AddCategory(newCategory);
            Categories.Add(newCategory);

            NewCategoryName = string.Empty; // Clear the input
        }

        [RelayCommand]
        void EditCategory()
        {
            if (SelectedCategory == null || string.IsNullOrWhiteSpace(EditCategoryName)) return;

            SelectedCategory.Name = EditCategoryName;
            DatabaseService.AddCategory(SelectedCategory); // Update in DB
            LoadData(); // Refresh the list

            EditCategoryName = string.Empty; // Clear the input
        }

        [RelayCommand]
        void DeleteCategory()
        {
            if (SelectedCategory == null) return;

            DatabaseService.DeleteCategory(SelectedCategory.Id);
            Categories.Remove(SelectedCategory);
        }

        [RelayCommand]
        async Task GoBack()
        {
            await AppShell.Current.GoToAsync("///MainPage");
        }

        
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExaminationProject;
using ExaminationProject.Model;
using System.Collections.ObjectModel;

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

        private Category selectedCategory;
        public Category SelectedCategory
        {
            get => selectedCategory;
            set
            {
                if (SetProperty(ref selectedCategory, value))
                {
                    // Automatically update the EditCategoryName field when selection changes
                    editCategoryName = selectedCategory?.Name;
                }
            }
        }

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
            DatabaseService.UpdateCategory(SelectedCategory); // Update in DB
            LoadData(); // Refresh the list

            EditCategoryName = string.Empty; // Clear the input
        }

        [RelayCommand]
        void DeleteCategory(Category category)
        {
            DatabaseService.DeleteCategory(category.Id);
            Categories.Remove(category);
        }

        [RelayCommand]
        async Task GoBack()
        {
            await AppShell.Current.GoToAsync("///MainPage");
        }
    }
}

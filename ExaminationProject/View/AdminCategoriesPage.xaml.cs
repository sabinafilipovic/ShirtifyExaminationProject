using ExaminationProject.ViewModel;

namespace ExaminationProject.View;

public partial class AdminCategoriesPage : ContentPage
{
	public AdminCategoriesPage(AdminCategoriesViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
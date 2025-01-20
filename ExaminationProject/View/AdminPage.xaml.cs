using ExaminationProject.ViewModel;

namespace ExaminationProject.View;

public partial class AdminPage : ContentPage
{
	public AdminPage(AdminViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
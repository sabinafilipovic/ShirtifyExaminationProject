using ExaminationProject.ViewModel;

namespace ExaminationProject.View;

public partial class AdminColorsPage : ContentPage
{
	public AdminColorsPage(AdminColorsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
using ExaminationProject.ViewModel;

namespace ExaminationProject;

public partial class CrudPage : ContentPage
{
	public CrudPage(CrudViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
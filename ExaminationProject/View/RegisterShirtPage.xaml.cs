using ExaminationProject.ViewModel;

namespace ExaminationProject.View;

public partial class RegisterShirtPage : ContentPage
{
	public RegisterShirtPage(RegisterShirtViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}
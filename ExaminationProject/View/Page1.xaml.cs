using ExaminationProject.ViewModel;

namespace ExaminationProject.View;

public partial class Page1 : ContentPage
{
    public Page1(Page1ViewModel vm)
    {
		InitializeComponent();
        BindingContext = vm;
    }
}
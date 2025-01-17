using ExaminationProject.ViewModel;

namespace ExaminationProject.View;

public partial class DetailPage : ContentPage
{
	public DetailPage(DetailViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;

    }
}
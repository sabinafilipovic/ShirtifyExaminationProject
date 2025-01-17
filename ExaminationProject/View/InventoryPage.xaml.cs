using ExaminationProject.ViewModel;

namespace ExaminationProject.View;

public partial class InventoryPage : ContentPage
{
    public InventoryPage(InventoryViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}
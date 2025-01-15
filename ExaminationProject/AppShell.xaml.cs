using ExaminationProject.View;

namespace ExaminationProject
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Page1), typeof(Page1));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));

        }
    }
}

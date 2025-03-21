﻿using ExaminationProject.View;

namespace ExaminationProject
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
            Routing.RegisterRoute(nameof(InventoryPage), typeof(InventoryPage));
            Routing.RegisterRoute(nameof(RegisterShirtPage), typeof(RegisterShirtPage));

            Routing.RegisterRoute(nameof(Page1), typeof(Page1));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(CrudPage), typeof(CrudPage));
            
            Routing.RegisterRoute(nameof(AdminPage), typeof(AdminPage));
            Routing.RegisterRoute(nameof(AdminCategoriesPage), typeof(AdminCategoriesPage));
            Routing.RegisterRoute(nameof(AdminColorsPage), typeof(AdminColorsPage));
        }
    }
}

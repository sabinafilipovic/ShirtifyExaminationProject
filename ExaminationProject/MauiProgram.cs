﻿using ExaminationProject.Services;
using ExaminationProject.View;
using ExaminationProject.ViewModel;
using Microsoft.Extensions.Logging;

namespace ExaminationProject
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Chewy.ttf", "Chewy");
                    fonts.AddFont("IndieFlower.ttf", "IndieFlower");
                    fonts.AddFont("PoppinsMedium.ttf", "PoppinsMedium");
                    fonts.AddFont("PoppinsRegular.ttf", "PoppinsRegular");
                    fonts.AddFont("PoppinsBold.ttf", "PoppinsBold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<PhotoService>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddSingleton<WeatherService>();

            builder.Services.AddTransient<Page1>();
            builder.Services.AddTransient<Page1ViewModel>();

            builder.Services.AddTransient<DetailPage>();
            builder.Services.AddTransient<DetailViewModel>();

            builder.Services.AddTransient<InventoryPage>();
            builder.Services.AddTransient<InventoryViewModel>();

            builder.Services.AddTransient<RegisterShirtPage>();
            builder.Services.AddTransient<RegisterShirtViewModel>();

            builder.Services.AddTransient<CrudPage>();
            builder.Services.AddTransient<CrudViewModel>();

            builder.Services.AddTransient<AdminPage>();
            builder.Services.AddTransient<AdminViewModel>();

            builder.Services.AddTransient<AdminCategoriesPage>();
            builder.Services.AddTransient<AdminCategoriesViewModel>();

            builder.Services.AddTransient<AdminColorsPage>();
            builder.Services.AddTransient<AdminColorsViewModel>();

            return builder.Build();
        }
    }
}

using Microsoft.Extensions.Logging;
using PruebaFinalSantiagoConlago.Services;
using PruebaFinalSantiagoConlago.ViewModels;
using PruebaFinalSantiagoConlago.Views;

namespace PruebaFinalSantiagoConlago
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
                });

            // Registrar servicios
            builder.Services.AddSingleton<DatabaseService>();
            builder.Services.AddSingleton<FileService>(_ => new FileService("TuApellido")); // Cambiar por tu apellido

            // Registrar ViewModels
            builder.Services.AddTransient<DispositivoViewModel>();
            builder.Services.AddTransient<ListaDispositivosViewModel>();
            builder.Services.AddTransient<LogsViewModel>();

            // Registrar Views
            builder.Services.AddTransient<AgregarDispositivoPage>();
            builder.Services.AddTransient<ListaDispositivosPage>();
            builder.Services.AddTransient<LogsPage>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

using PruebaFinalSantiagoConlago.Services;
using PruebaFinalSantiagoConlago.ViewModels;
using PruebaFinalSantiagoConlago.Views;
using Microsoft.Maui.Controls;

namespace PruebaFinalSantiagoConlago
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Configuración de servicios
            var dbService = new DatabaseService();
            var fileService = new FileService("Conlago");

            // Registra las rutas
            Routing.RegisterRoute(nameof(AgregarDispositivoPage), typeof(AgregarDispositivoPage));
            Routing.RegisterRoute(nameof(ListaDispositivosPage), typeof(ListaDispositivosPage));
            Routing.RegisterRoute(nameof(LogsPage), typeof(LogsPage));

            MainPage = new AppShell();


            // Crear páginas con sus ViewModels
            var tabs = new TabbedPage
            {
                Children =
            {
                new NavigationPage(new AgregarDispositivoPage(
                    new DispositivoViewModel(dbService, fileService)))
                {
                    Title = "Registrar",
                    IconImageSource = "add.png"
                },
                new NavigationPage(new ListaDispositivosPage(
                    new ListaDispositivosViewModel(dbService)))
                {
                    Title = "Dispositivos",
                    IconImageSource = "list.png"
                },
                new NavigationPage(new LogsPage(
                    new LogsViewModel(fileService)))
                {
                    Title = "Logs",
                    IconImageSource = "log.png"
                }
            }
            };

            MainPage = tabs;
        }
    }
    }

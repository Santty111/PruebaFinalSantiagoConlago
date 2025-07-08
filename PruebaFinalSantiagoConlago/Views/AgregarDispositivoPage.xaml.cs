using PruebaFinalSantiagoConlago.ViewModels;

namespace PruebaFinalSantiagoConlago;

public partial class AgregarDispositivoPage : ContentPage
{
    public AgregarDispositivoPage(DispositivoViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel; // Esto es lo más importante
    }
}
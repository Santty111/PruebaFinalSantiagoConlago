using PruebaFinalSantiagoConlago.ViewModels;

namespace PruebaFinalSantiagoConlago.Views;

public partial class AgregarDispositivoPage : ContentPage
{
    public AgregarDispositivoPage(DispositivoViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
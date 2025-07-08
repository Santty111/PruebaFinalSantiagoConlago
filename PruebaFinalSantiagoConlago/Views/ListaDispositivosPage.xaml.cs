using PruebaFinalSantiagoConlago.ViewModels;

namespace PruebaFinalSantiagoConlago.Views;

public partial class ListaDispositivosPage : ContentPage
{
    public ListaDispositivosPage(ListaDispositivosViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
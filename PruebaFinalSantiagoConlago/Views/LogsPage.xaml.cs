using PruebaFinalSantiagoConlago.ViewModels;

namespace PruebaFinalSantiagoConlago.Views;

public partial class LogsPage : ContentPage
{
    public LogsPage(LogsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
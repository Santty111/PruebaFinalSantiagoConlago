using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PruebaFinalSantiagoConlago.Models;
using PruebaFinalSantiagoConlago.Services;
using System.Windows.Input;

namespace PruebaFinalSantiagoConlago.ViewModels
{
    public class ListaDispositivosViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly DatabaseService _dbService;
        public ObservableCollection<Dispositivo> Dispositivos { get; } = new();

        public ICommand RefrescarCommand { get; }

        public ListaDispositivosViewModel(DatabaseService dbService)
        {
            _dbService = dbService;
            RefrescarCommand = new Command(async () => await CargarDispositivos());

            _ = CargarDispositivos();
        }

        public async Task CargarDispositivos()
        {
            try
            {
                var dispositivos = await _dbService.GetDispositivosAsync();
                Dispositivos.Clear();
                foreach (var dispositivo in dispositivos)
                {
                    Dispositivos.Add(dispositivo);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Error al cargar dispositivos: {ex.Message}", "OK");
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

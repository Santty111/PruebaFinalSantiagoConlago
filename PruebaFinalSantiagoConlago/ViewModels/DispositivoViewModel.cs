using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PruebaFinalSantiagoConlago.Models;
using PruebaFinalSantiagoConlago.Services;

namespace PruebaFinalSantiagoConlago.ViewModels
{
    public class DispositivoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Dispositivo _dispositivo = new Dispositivo();
        private readonly DatabaseService _dbService;
        private readonly FileService _fileService;

        public Dispositivo Dispositivo
        {
            get => _dispositivo;
            set
            {
                _dispositivo = value;
                OnPropertyChanged();
            }
        }

        public ICommand GuardarCommand => new Command(async () => await GuardarDispositivo());

        public DispositivoViewModel(DatabaseService dbService, FileService fileService)
        {
            _dbService = dbService;
            _fileService = fileService;
        }

        private async Task GuardarDispositivo()
        {
            // Validación específica del ejercicio 6
            if (Dispositivo.GarantiaActiva && Dispositivo.VidaUtilMeses < 12)
            {
                await Shell.Current.DisplayAlert("Error",
                    "Cuando la garantía está activa, la vida útil debe ser al menos 12 meses", "OK");
                return;
            }

            try
            {
                await _dbService.SaveDispositivoAsync(Dispositivo);
                await _fileService.AppendLogAsync(
                    $"Se incluyó el registro {Dispositivo.Nombre} el {DateTime.Now:dd/MM/yyyy HH:mm}");

                await Shell.Current.DisplayAlert("Éxito", "Dispositivo registrado correctamente", "OK");
                Dispositivo = new Dispositivo(); // Resetear formulario
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Error al guardar: {ex.Message}", "OK");
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

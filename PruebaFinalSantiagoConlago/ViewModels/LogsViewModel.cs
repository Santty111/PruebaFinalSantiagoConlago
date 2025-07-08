using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PruebaFinalSantiagoConlago.Services;

namespace PruebaFinalSantiagoConlago.ViewModels
{
    public class LogsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly FileService _fileService;
        private string _logsContent;

        public string LogsContent
        {
            get => _logsContent;
            set
            {
                _logsContent = value;
                OnPropertyChanged();
            }
        }

        public ICommand RefrescarCommand { get; }

        public LogsViewModel(FileService fileService)
        {
            _fileService = fileService;
            RefrescarCommand = new Command(async () => await CargarLogs());

            _ = CargarLogs();
        }

        public async Task CargarLogs()
        {
            try
            {
                LogsContent = await _fileService.ReadLogsAsync();
            }
            catch (Exception ex)
            {
                LogsContent = $"Error al cargar logs: {ex.Message}";
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

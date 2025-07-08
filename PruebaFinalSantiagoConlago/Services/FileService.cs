using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaFinalSantiagoConlago.Services
{
    public class FileService
    {
        private readonly string _filePath;

        public FileService(string apellido)
        {
            _filePath = Path.Combine(FileSystem.AppDataDirectory, $"Logs_{apellido}.txt");

            // Crear archivo si no existe
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "Registro de Logs - Control de Dispositivos\n\n");
            }
        }

        public async Task AppendLogAsync(string mensaje)
        {
            await File.AppendAllTextAsync(_filePath, $"{mensaje}\n");
        }

        public async Task<string> ReadLogsAsync()
        {
            return await File.ReadAllTextAsync(_filePath);
        }
    }
}

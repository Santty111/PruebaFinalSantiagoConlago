using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using PruebaFinalSantiagoConlago.Models;

namespace PruebaFinalSantiagoConlago.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            _database = new SQLiteAsyncConnection(
                Path.Combine(FileSystem.AppDataDirectory, "dispositivos.db3"),
                SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache);
            _database.CreateTableAsync<Dispositivo>().Wait();
        }

        public Task<List<Dispositivo>> GetDispositivosAsync()
        {
            return _database.Table<Dispositivo>().OrderByDescending(d => d.FechaRegistro).ToListAsync();
        }

        public Task<int> SaveDispositivoAsync(Dispositivo dispositivo)
        {
            dispositivo.FechaRegistro = DateTime.Now;
            return dispositivo.Id == 0 ?
                _database.InsertAsync(dispositivo) :
                _database.UpdateAsync(dispositivo);
        }
    }
}

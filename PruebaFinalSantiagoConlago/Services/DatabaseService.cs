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

            InitializeDatabase();
        }

        private async Task InitializeDatabase()
        {
            await _database.CreateTableAsync<Dispositivo>();
        }

        public async Task<List<Dispositivo>> GetDispositivosAsync()
        {
            return await _database.Table<Dispositivo>()
                                .OrderByDescending(d => d.FechaRegistro)
                                .ToListAsync();
        }

        public async Task<int> SaveDispositivoAsync(Dispositivo dispositivo)
        {
            dispositivo.FechaRegistro = DateTime.Now;
            return dispositivo.Id == 0 ?
                await _database.InsertAsync(dispositivo) :
                await _database.UpdateAsync(dispositivo);
        }
    }
}

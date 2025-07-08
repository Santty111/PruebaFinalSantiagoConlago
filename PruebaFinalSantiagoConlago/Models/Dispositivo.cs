using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace PruebaFinalSantiagoConlago.Models
{
    public class Dispositivo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public bool GarantiaActiva { get; set; }
        public int VidaUtilMeses { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}

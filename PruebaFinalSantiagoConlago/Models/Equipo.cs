using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace PruebaFinalSantiagoConlago.Models
{
    public class Equipo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Dispositivo { get; set; }
        public string Marca { get; set; }
        public bool GarantiaActiva { get; set; }
        public int VidaUtilMeses { get; set; }
    }
}

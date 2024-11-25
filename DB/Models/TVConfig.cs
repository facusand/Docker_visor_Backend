using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class TVConfig
    {
        public int Id { get; set; }
        public string ScreenName { get; set; }  // Nombre de la pantalla (ej. Televisor Pasillo A)
        public int RefreshInterval { get; set; } // Intervalo de actualización en segundos
        public string DisplayMode { get; set; }  // Modo de visualización (ej. Sólo Clima, Sólo Cámaras)
        public bool IsEnabled { get; set; }     // Si el visor está habilitado o no
        public DateTime LastUpdated { get; set; } // Última vez que se actualizó la configuración
    }
}

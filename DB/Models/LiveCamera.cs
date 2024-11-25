using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class LiveCamera
    {
        public int Id { get; set; }
        public string CameraName { get; set; } // Nombre de la cámara o ubicación
        public string Url { get; set; }        // URL de la transmisión en vivo
        public bool IsActive { get; set; }     // Si la cámara está activa o no
        public DateTime AddedDate { get; set; } // Fecha en que se agregó la cámara
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class WeatherData
    {
        public int Id { get; set; }
        public string City { get; set; }    // Nombre de la ciudad
        public string Country { get; set; } // País
        public double Temperature { get; set; } // Temperatura en grados Celsius
        public string Condition { get; set; }   // Condición meteorológica (ej. Soleado, Nublado)
        public DateTime Timestamp { get; set; } // Fecha y hora de los datos
    }
}

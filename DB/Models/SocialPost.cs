using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class SocialPost
    {
        public int Id { get; set; }
        public string Username { get; set; }    // Nombre de usuario de la cuenta que publicó
        public string Platform { get; set; }    // Plataforma (ej. Twitter, Instagram)
        public string Content { get; set; }     // Contenido de la publicación
        public DateTime PostedDate { get; set; } // Fecha de la publicación
        public string PostUrl { get; set; }     // URL de la publicación
    }
}

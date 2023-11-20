using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursosDigitalApp.Models
{
    public class Administradores
    {
        [PrimaryKey, AutoIncrement]

        public int AdminId { get; set; }

        [MaxLength(50)]

        public string NombreAdmin { get; set; }

        [MaxLength(50)]

        public string Apellidos { get; set; }

        public int Edad { get; set; }

        [MaxLength(50)]

        public string CURP { get; set; }

        [MaxLength(30)]

        public string Email { get; set; }

        [MaxLength(16)]

        public string Pass { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}

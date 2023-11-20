using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursosDigitalApp.Models
{
    public class Empleado
    {
        [PrimaryKey,AutoIncrement]

        public int Noemp { get; set; }

        [MaxLength(60)]

        public string Nombre { get; set; }

        [MaxLength(60)]

        public string Direccion { get; set; }

        [MaxLength(60)]

        public string Telefono { get; set; }

        [MaxLength(60)]

        public string Edad { get; set; }

        [MaxLength(60)]

        public string CURP { get; set; }

        [MaxLength(60)]

        public string Tipoemp { get; set; }
    }
}

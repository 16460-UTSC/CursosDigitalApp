using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursosDigitalApp.Models
{
    public class Curso
    {

        [PrimaryKey,AutoIncrement]

        public int IdCurso { get; set; }

        [MaxLength(100)]

        public string NombreCurso { get; set; }

        [MaxLength(100)]

        public string TipoCurso { get; set; }

        [MaxLength(1000)]

        public string Descripcion { get; set; }

        [MaxLength(60)]

        public string HorasCursi { get; set; }
    }
}

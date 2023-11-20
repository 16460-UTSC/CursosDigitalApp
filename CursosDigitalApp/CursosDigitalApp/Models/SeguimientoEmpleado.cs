using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;
namespace CursosDigitalApp.Models
{
    public class SeguimientoEmpleado
    {
        [PrimaryKey, AutoIncrement]

        public int IdSeg { get; set; }


        public string NombreCurso2 { get; set; }

        [MaxLength(70)]

        public string LugarCurso { get; set; }

        public DateTime Fecha { get; set; }

        public TimeSpan Hora { get; set; }

        [MaxLength(50)]

        public string Estatus { get; set; }

        public int Calificacion { get; set; }



        public int Noemp2 { get; set; }

        [MaxLength(60)]


        public string Nombre2 { get; set; }


    } }


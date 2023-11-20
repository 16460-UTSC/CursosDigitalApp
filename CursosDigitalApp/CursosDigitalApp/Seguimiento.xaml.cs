using CursosDigitalApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CursosDigitalApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Seguimiento : ContentPage
    {
        public Seguimiento()
        {
            InitializeComponent();
            txtEstatus.Items.Add("Programado");
            txtEstatus.Items.Add("En Progreso");
            txtEstatus.Items.Add("Completo");
            llenarDatos2();
            llenarDatos();
            llenarDatos3();
        }

        private void LimpiarControles()
        {
            // Restablecer los Pickers a un estado predeterminado
            txtNombre.SelectedItem = null;
            txtNombreCurso.SelectedItem = null;
            txtEstatus.SelectedItem = null;

            // Limpiar otros controles según sea necesario
            txtLugarCurso.Text = string.Empty;
            txtFecha.Date = DateTime.Now.Date;
            txtHora.Time = TimeSpan.Zero;
            txtCalificacion.Text = string.Empty;
        }

        public async void llenarDatos()
        {
            var SeguimientoList = await App.SQLiteDB.GetSeguimientoAsync();
            if (SeguimientoList != null)
            {
                lsSeguimiento.ItemsSource = SeguimientoList;
            }
        }
        public async void llenarDatos2()
        {
            var Empleado = await App.SQLiteDB.GetEmpleadoAsync();
            if (Empleado != null)
            {
                txtNoemp.ItemsSource = Empleado;
                txtNombre.ItemsSource = Empleado;
            }
        }
        public async void llenarDatos3()
        {
            var NombreCurso = await App.SQLiteDB.GetCursoAsync();
            if (NombreCurso != null)
            {
                txtNombreCurso.ItemsSource = NombreCurso;
            }
        }


        public bool validarDatos2()
        {
            bool respuesta;

            // if (string.IsNullOrEmpty(txtNoemp.SelectedItem.ToString()))
            // {
            //     respuesta = false;
            //  }
            if (string.IsNullOrEmpty(txtNombre.Items[txtNombre.SelectedIndex]))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtNombreCurso.SelectedItem.ToString()))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtLugarCurso.Text))
            {
                respuesta = false;
            }
            else if (txtFecha.Date == null || txtFecha.Date < DateTime.Today)
            {
                respuesta = false;
            }
            else if (txtHora.Time == null || txtHora.Time < TimeSpan.Zero)
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtEstatus.SelectedItem.ToString()))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtCalificacion.Text))
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;

        }



        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEstatus.SelectedItem.ToString();

        }

        private async void Registrarse_Clicked(object sender, EventArgs e)
        {
            if (validarDatos2())
            {
                SeguimientoEmpleado Segui = new SeguimientoEmpleado
                {
                    Nombre2 = txtNombre.Items[txtNombre.SelectedIndex],
                    NombreCurso2 = txtNombreCurso.Items[txtNombreCurso.SelectedIndex],
                    LugarCurso = txtLugarCurso.Text,
                    Fecha = txtFecha.Date,

                    Hora = txtHora.Time,
                    Estatus = txtEstatus.SelectedItem.ToString(),
                    Calificacion = int.Parse(txtCalificacion.Text),

                };

                await App.SQLiteDB.SaveSeguimientoAsyc(Segui);

                txtNombre.SelectedItem = "";
                txtNombreCurso.SelectedItem = "";
                txtLugarCurso.Text = "";
                txtFecha.Date = DateTime.Now.Date;
                txtHora.Time = TimeSpan.Zero;
                txtEstatus.SelectedItem = "";
                txtCalificacion.Text = "";

                await DisplayAlert("Registrado", "El seguimiento fue Registrado", "Ok");

                llenarDatos();


                var SeguimientoList = await App.SQLiteDB.GetSeguimientoAsync();
                if (SeguimientoList != null)
                {
                    lsSeguimiento.ItemsSource = SeguimientoList;
                }
                else
                {
                    await DisplayAlert("AVISO", "Ingresar los Datos", "Ok");
                }
            }
        }

        private async void Actualizar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdSeg.Text))
            {
                SeguimientoEmpleado Segui = new SeguimientoEmpleado
                {
                    IdSeg = int.Parse(txtIdSeg.Text),
                    Nombre2 = txtNombre.Items[txtNombre.SelectedIndex],
                    NombreCurso2 = txtNombreCurso.Items[txtNombreCurso.SelectedIndex],
                    LugarCurso = txtLugarCurso.Text,
                    Fecha = txtFecha.Date,

                    Hora = txtHora.Time,
                    Estatus = txtEstatus.SelectedItem as string,
                    Calificacion = int.Parse(txtCalificacion.Text),
                };

                await App.SQLiteDB.SaveSeguimientoAsyc(Segui);

                txtNombre.SelectedItem = Segui.Nombre2;
                txtNombreCurso.SelectedItem = Segui.NombreCurso2;
                txtLugarCurso.Text = "";
                txtFecha.Date = DateTime.Now.Date;
                txtHora.Time = TimeSpan.Zero;
                txtEstatus.SelectedItem = "";
                txtCalificacion.Text = "";

                await DisplayAlert("ACTUALIZACION", "Se actualizo de Manera Exitosa", "Ok");
                LimpiarControles();
                llenarDatos();

                txtIdSeg.IsVisible = false;
                Actualizar.IsVisible = false;
                Registrarse.IsVisible = true;

            }
        }

        private async void lsSeguimiento_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (SeguimientoEmpleado)e.SelectedItem;

            txtIdSeg.IsVisible = true;
            Actualizar.IsVisible = true;
            Registrarse.IsVisible = false;


            if (!string.IsNullOrEmpty(obj.IdSeg.ToString()))
            {
                var segui = await App.SQLiteDB.GetSeguimientoByIdAsync(obj.IdSeg);

                if (segui != null)
                {
                    txtIdSeg.Text = segui.IdSeg.ToString();
                    // txtNoemp.SelectedItem = segui.Noemp2.ToString();
                    txtNombre.SelectedIndex = txtNombre.Items.IndexOf(segui.Nombre2);
                    txtNombreCurso.SelectedIndex = txtNombreCurso.Items.IndexOf(segui.NombreCurso2);
                    txtLugarCurso.Text = segui.LugarCurso;
                    txtEstatus.SelectedItem = segui.Estatus;
                    txtFecha.Date = segui.Fecha;
                    txtHora.Time = segui.Hora;
                    txtCalificacion.Text = segui.Calificacion.ToString();
                }
            }
        }



    }
}
using CursosDigitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace CursosDigitalApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistroCurso : ContentPage
	{
		public RegistroCurso ()
		{
			InitializeComponent ();
            txtTipoCurso.Items.Add("Interno");
            txtTipoCurso.Items.Add("Externo");
            llenarDatos();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                Curso curs = new Curso
                {
                    NombreCurso = txtNombreCurso.Text,
                    TipoCurso = txtTipoCurso.SelectedItem.ToString(),
                    Descripcion = txtDescripcion.Text,
                    HorasCursi = txtHorasCursi.Text,



                };

              await App.SQLiteDB.SaveCursoAsyc(curs);

                txtNombreCurso.Text = "";
                txtTipoCurso.SelectedItem = "";
                txtDescripcion.Text = "";
                txtHorasCursi.Text = "";


               await DisplayAlert("AVISO", "Se guardo de Manera Exitosa", "Ok");

                llenarDatos();

                var CursoList = await App.SQLiteDB.GetCursoAsync();
                if(CursoList !=null)
                {
                    lsCursos.ItemsSource = CursoList;
                }
            
            }
            else
            {
               await DisplayAlert("AVISO", "INGRESAR LOS DATOS", "Ok");
            }

        }



        public async void llenarDatos()
        {
            var CursoList = await App.SQLiteDB.GetEmpleadoAsync();

        }

        public bool validarDatos()
        {
            bool respuesta;

            if (string.IsNullOrEmpty(txtNombreCurso.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtTipoCurso.SelectedItem.ToString()))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtHorasCursi.Text))
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;

        }

        private async void lsCursos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Curso)e.SelectedItem;

            txtIdCurso.IsVisible = true;
            btnActualizar.IsVisible = true;
            btnBorrar.IsVisible = true;
            btnRegistrar.IsVisible = false;

            if (!string.IsNullOrEmpty(obj.IdCurso.ToString()))
            {
                var capa = await App.SQLiteDB.GetCursoByIdAsync(obj.IdCurso);
                if(capa != null)
                {
                    txtIdCurso.Text = capa.IdCurso.ToString();
                    txtNombreCurso.Text = capa.NombreCurso.ToString();
                    txtTipoCurso.SelectedItem = capa.TipoCurso.ToString();
                    txtDescripcion.Text = capa.Descripcion.ToString();
                    txtHorasCursi.Text = capa.HorasCursi.ToString();
                }
            }
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdCurso.Text))
            {
                Curso curso = new Curso()
                {
                    IdCurso = int.Parse(txtIdCurso.Text),
                    NombreCurso = txtNombreCurso.Text,
                    TipoCurso = txtTipoCurso.SelectedItem.ToString(),
                    Descripcion = txtDescripcion.Text,
                    HorasCursi = txtHorasCursi.Text,
                };

                await App.SQLiteDB.SaveCursoAsyc(curso);
                txtIdCurso.Text = "";
                txtNombreCurso.Text = "";
                txtTipoCurso.SelectedItem = "";
                txtDescripcion.Text = "";
                txtHorasCursi.Text = "";

                txtIdCurso.IsVisible = false;
                btnActualizar.IsVisible = false;
                btnBorrar.IsVisible = false;
                btnRegistrar.IsVisible = true;

                await DisplayAlert("ACTUALIZACION", "Se actualizo de Manera Exitosa", "Ok");
                llenarDatos();
            }
        }

        private async void btnBorrar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdCurso.Text))
            {
                Curso curso = new Curso()
                {
                    IdCurso = int.Parse(txtIdCurso.Text),
                    NombreCurso = txtNombreCurso.Text,
                    TipoCurso = txtTipoCurso.SelectedItem.ToString(),
                    Descripcion = txtDescripcion.Text,
                    HorasCursi = txtHorasCursi.Text,
                };

                await App.SQLiteDB.DeleteCursoAsync(curso);
                txtIdCurso.Text = "";
                txtNombreCurso.Text = "";
                txtTipoCurso.SelectedItem = "";
                txtDescripcion.Text = "";
                txtHorasCursi.Text = "";

                txtIdCurso.IsVisible = false;
                btnActualizar.IsVisible = false;
                btnBorrar.IsVisible = false;
                btnRegistrar.IsVisible = true;

                await DisplayAlert("AVISO", "Se Borro de Manera Exitosa", "Ok");
                llenarDatos();
            }
        }

        private void txtTipoCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTipoCurso.SelectedItem.ToString();
        }
    }
    }

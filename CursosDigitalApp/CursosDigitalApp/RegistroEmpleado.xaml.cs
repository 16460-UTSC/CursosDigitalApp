using CursosDigitalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CursosDigitalApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistroEmpleado : ContentPage
	{
		public RegistroEmpleado ()
		{
			InitializeComponent ();
            txtTipoemp.Items.Add("Planta");
            txtTipoemp.Items.Add("Temporal");
			llenarDatos();
   
		}



        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                Empleado emple = new Empleado
                {
                    Nombre = txtNombre.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    Edad = txtEdad.Text,
                    CURP = txtCURP.Text,
                    Tipoemp=txtTipoemp.SelectedItem.ToString(),
                    
                    
                };

                await App.SQLiteDB.SaveEmpleadoAsyc(emple);

                txtNombre.Text = "";
                txtDireccion.Text = "";
                txtTelefono.Text = "";
                txtEdad.Text = "";
                txtCURP.Text = "";
                txtTipoemp.SelectedItem = "";

                await DisplayAlert("AVISO", "Se guardo de Manera Exitosa", "Ok");

                llenarDatos();

                var EmpleadosList = await App.SQLiteDB.GetEmpleadoAsync();
                if (EmpleadosList != null)
                {
                    lsEmpleados.ItemsSource = EmpleadosList;
                }


            }
            else
            {
                await DisplayAlert("AVISO", "INGRESAR LOS DATOS", "Ok");
            }

        }



        public async void llenarDatos()
        {
            var EmpleadoList = await App.SQLiteDB.GetEmpleadoAsync();
            if(EmpleadoList != null)
            {
                lsEmpleados.ItemsSource = EmpleadoList;
            }
        }
        private async void lsEmpleados_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Empleado)e.SelectedItem;

            btnRegistrar.IsVisible = false;
            txtNoemp.IsVisible = true;
            btnActualizar.IsVisible = true;
            btnBorrar.IsVisible = true;
            

            if (!string.IsNullOrEmpty(obj.Noemp.ToString()))
            {
                var emplea = await App.SQLiteDB.GetEmpleadoByIdAsync(obj.Noemp);

                if (emplea != null)
                {
                    txtNoemp.Text = emplea.Noemp.ToString();
                    txtNombre.Text = emplea.Nombre;
                    txtDireccion.Text = emplea.Direccion;
                    txtTelefono.Text = emplea.Telefono;
                    txtEdad.Text = emplea.Edad;
                    txtCURP.Text = emplea.CURP;
                    txtTipoemp.SelectedItem = emplea.Tipoemp;
                }
            }
        }

        public bool validarDatos()
        {
            bool respuesta;

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtEdad.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtCURP.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtTipoemp.SelectedItem.ToString()))
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;

        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                Empleado emple = new Empleado
                {
                    Nombre = txtNombre.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    Edad = txtEdad.Text,
                    CURP = txtCURP.Text,
                    Tipoemp = txtTipoemp.SelectedItem.ToString(),
                };

                await App.SQLiteDB.SaveEmpleadoAsyc(emple);

                txtNombre.Text = "";
                txtDireccion.Text = "";
                txtTelefono.Text = "";
                txtEdad.Text = "";
                txtCURP.Text = "";
                txtTipoemp.SelectedItem = "";

                await DisplayAlert("AVISO", "Se guardo de Manera Exitosa", "Ok");

                llenarDatos();


                var EmpleadosList = await App.SQLiteDB.GetEmpleadoAsync();
                if (EmpleadosList != null)
                {
                    lsEmpleados.ItemsSource = EmpleadosList;
                }
            }
            else
            {
                await DisplayAlert("AVISO", "INGRESAR LOS DATOS", "Ok");
            }
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNoemp.Text))
            {
                Empleado empleado = new Empleado()
                {
                    Noemp = int.Parse(txtNoemp.Text),
                    Nombre = txtNombre.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    Edad = txtEdad.Text,
                    CURP = txtCURP.Text,
                    Tipoemp = txtTipoemp.SelectedItem.ToString(),
                    
                };

                await App.SQLiteDB.SaveEmpleadoAsyc(empleado);
                txtNoemp.Text = "";
                txtNombre.Text = "";
                txtDireccion.Text = "";
                txtTelefono.Text = "";
                txtEdad.Text = "";
                txtCURP.Text = "";
                txtTipoemp.SelectedItem = "";

                txtNoemp.IsVisible = false;
                btnActualizar.IsVisible = false;
                btnRegistrar.IsVisible = true;
                btnBorrar.IsVisible = false;

                await DisplayAlert("AVISO", "Se actualizo de manera exitosa", "Ok");
                llenarDatos();
            }
        }

        private async void btnBorrar_Clicked(object sender, EventArgs e)
        {
            var empleado = await App.SQLiteDB.GetEmpleadoByIdAsync(int.Parse(txtNoemp.Text));

            if (empleado != null)
            {
                await App.SQLiteDB.DeleteEmpleadoAsync(empleado);
                await DisplayAlert("AVISO", "Se elimino el registro de manera exitosa", "Ok");

                txtNoemp.Text = "";
                txtNombre.Text = "";
                txtDireccion.Text = "";
                txtTelefono.Text = "";
                txtEdad.Text = "";
                txtCURP.Text = "";
                txtTipoemp.SelectedItem = "";

                txtNoemp.IsVisible = false;
                btnRegistrar.IsVisible = true;
                btnActualizar.IsVisible = false;
                btnBorrar.IsVisible = false;
                llenarDatos();
            }
        }

        private void  TomeFoto_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TomeFoto());

        }

        private void txtTipoemp_SelectedIndexChanged(object sender, EventArgs e)
        {
            string es = txtTipoemp.SelectedItem.ToString();
        }
    }
}
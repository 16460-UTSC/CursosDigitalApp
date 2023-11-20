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
    public partial class RegistroAdmin : ContentPage
    {
        public RegistroAdmin()
        {
            InitializeComponent();
        }

        public async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                await DisplayAlert("FALTA NOMBRE", "Favor de escribir su Nombre", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(txtApellidos.Text))
            {
                await DisplayAlert("FALTA APELLIDOS", "Favor de escribir los Apellidos", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(txtEdad.Text))
            {
                await DisplayAlert("FALTA EDAD", "Favor de escribir su Edad", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(txtCURP.Text))
            {
                await DisplayAlert("FALTA CURP", "Favor de escribir el CURP", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                await DisplayAlert("FALTA EMAIL", "Favor de escribir su Correo Electronico", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(txtPass.Text))
            {
                await DisplayAlert("FALTA LA CONTRASEÑA", "Favor de escribir la contraseña", "Ok");
                return;
            }
            Administradores admin = new Administradores()
            {

                NombreAdmin = txtNombre.Text,
                Apellidos = txtApellidos.Text,
                Edad = int.Parse(txtEdad.Text),
                CURP = txtCURP.Text,
                Email = txtEmail.Text,
                Pass = txtPass.Text,
                FechaCreacion = DateTime.Now


            };

            await App.SQLiteDB.SaveAdminAsyc(admin);
            await DisplayAlert("AVISO", "Registro guardado de forma exitosa", "Ok");
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtEdad.Text = "";
            txtCURP.Text = "";
            txtEmail.Text = "";
            txtPass.Text = "";

            await Navigation.PopAsync();
        }

       
    }
}
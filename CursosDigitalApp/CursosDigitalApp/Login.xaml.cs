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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        public async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                await DisplayAlert("FALTA EMAIL", "Debe escribir un email en el campo", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(txtPass.Text))
            {
                await DisplayAlert("FALTA LA CONTRASEÑA", "Debe escribir la contrasena", "Ok");
                return;
            }

            var resultado = await App.SQLiteDB.GetAdminValidate(txtEmail.Text, txtPass.Text);


            if (resultado.Count > 0)
            {
                txtEmail.Text = "";
                txtPass.Text = "";

                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("AVISO", "El email o la contrasena esta incorrecto", "Ok");
                txtEmail.Text = "";
                txtPass.Text = "";
            }
        }

        public async void Button_Clicked_1(object sender, EventArgs e)
        {
            txtEmail.Text = "";
            txtPass.Text = "";

            await Navigation.PushAsync(new RegistroAdmin());
        }
    }
}
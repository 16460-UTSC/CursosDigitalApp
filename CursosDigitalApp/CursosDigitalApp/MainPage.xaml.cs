using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CursosDigitalApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void REmpleados_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistroEmpleado());
        }

        private void RCursos_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistroCurso());
        }

        private void RSeguimiento_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Seguimiento());
        }
    }
}

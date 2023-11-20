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
    public partial class TomeFoto : ContentPage
    {
        public TomeFoto()
        {
            InitializeComponent();
        }

        private async void TomeFoto_Clicked(object sender, EventArgs e)
        {
            var foto = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions());

            if (foto != null)
            {
                Foto.Source = ImageSource.FromStream(() =>
                {
                    return foto.GetStream();
                });
            }
        }
    }
}
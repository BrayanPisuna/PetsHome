using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pets
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Validacion : ContentPage
	{
		public Validacion ()
		{
			InitializeComponent ();
		}

        private async void ButtonDoc_Clicked(object sender, EventArgs e)
        {
			var opcion = new StoreCameraMediaOptions
			{
				SaveToAlbum = true,
				Name = lblNombre + "_" + DateTime.Now
			};
			var foto = CrossMedia.Current.TakePhotoAsync(opcion);
			MiImagen.Source = ImageSource.FromStream(() =>
			{
				var stream = foto.Result.GetStream() ;
				foto.Dispose();
				return stream;
			});

        }
    }
}
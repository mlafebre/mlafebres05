using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mlafebres05
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Modificar : ContentPage
	{
		public Modificar ()
		{
			InitializeComponent ();
		}

        private void btnModificar_Clicked(object sender, EventArgs e)
        {
			try
			{
                WebClient cliente = new WebClient();
                string URL = $"http://127.0.0.1/ws_uisrael/post.php?codigo={txtCodigo.Text}&nombre={txtNombre.Text}&apellido={txtApellido.Text}";
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);
                cliente.UploadValues(URL, "PUT", parametros);
                DisplayAlert("Alerta", "Ingreso Correcto", "Cerrar");
                Navigation.PushAsync(new Insertar());
            }
			catch (Exception)
			{

				throw;
			}
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {

        }
    }
}
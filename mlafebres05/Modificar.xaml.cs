using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
		public Modificar (Datos datos) 
		{
			InitializeComponent ();
            txtCodigo.Text = datos.codigo.ToString();
            txtNombre.Text = datos.nombre;
            txtApellido.Text = datos.apellido;
            txtEdad.Text = datos.edad.ToString();
        }

        private void btnModificar_Clicked(object sender, EventArgs e)
        {
			try
			{
                WebClient cliente = new WebClient();
                string URL = $"http://192.168.17.28/ws_uisrael/post.php?codigo={txtCodigo.Text}&nombre={txtNombre.Text}&apellido={txtApellido.Text}&edad={txtEdad}";
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);
                cliente.UploadValues(URL, "PUT", parametros);
             
               
                //mensaje TOAST
                var mensaje = "Dato Ingresado";
                DependencyService.Get<Mensaje>().LongAlert(mensaje);

                Navigation.PushAsync(new Page1());


            }
            catch (Exception)
			{

				throw;
			}
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient client = new WebClient();

                var parametros = new NameValueCollection();
                string url = $"http://192.168.17.28/ws_uisrael/post.php?codigo={txtCodigo.Text}";


                client.UploadValues(url, "DELETE", parametros);
              
              
                //mensaje TOAST
                var mensaje = "Dato Ingresado";
                DependencyService.Get<Mensaje>().LongAlert(mensaje);

                Navigation.PushAsync(new Page1());


            }
            catch (Exception ex)
            {

                DisplayAlert("Error", "Detalle:" + ex.Message, "Aceptar");
            }
        }
    }
    
}
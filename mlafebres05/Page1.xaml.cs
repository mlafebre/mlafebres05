using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mlafebres05
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage

	{
        private const string Url = "http://192.168.17.28/ws_uisrael/post.php";
        private HttpClient cliente = new HttpClient();
        private ObservableCollection<mlafebres05.Datos> datos;
        public Page1 ()
		{
			InitializeComponent ();
            obtener();
		}
		public async void obtener()

		{
            var contenido = await cliente.GetStringAsync(Url);
            List<mlafebres05.Datos> listPost = JsonConvert.DeserializeObject<List<mlafebres05.Datos>>(contenido);
            datos = new ObservableCollection<Datos>(listPost);
            listaEstudiantes.ItemsSource = datos;
        }

        private void btnMostrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Insertar());
        }

        private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objetoEstudiante = (Datos)e.SelectedItem;
            Navigation.PushAsync(new Modificar(objetoEstudiante));
        }
    }
}
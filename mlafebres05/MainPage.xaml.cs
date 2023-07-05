using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mlafebres05
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.17.28/ws_uisrael/post.php";
        private HttpClient cliente = new HttpClient();
        private ObservableCollection <mlafebres05.Datos> datos;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnMostrar_Clicked(object sender, EventArgs e)
        {
            var contenido = await cliente.GetStringAsync(Url);
            List<mlafebres05.Datos> listPost = JsonConvert.DeserializeObject<List<mlafebres05.Datos>>(contenido);
            datos = new ObservableCollection<Datos>(listPost);
            listaEstudiantes.ItemsSource = datos;
        }
    }
}

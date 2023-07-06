using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using mlafebres05.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
[assembly:Xamarin.Forms.Dependency(typeof(mensajeAndroi))]
namespace mlafebres05.Droid
{
    public class mensajeAndroi : Mensaje
    {
        void Mensaje.LongAlert(string mensaje)
        {
           Toast.MakeText(Application.Context, mensaje, ToastLength.Long).Show();
        }

        void Mensaje.ShortAlert(string mensaje)
        {
            Toast.MakeText(Application.Context,mensaje, ToastLength.Short).Show();
        }
    }
}
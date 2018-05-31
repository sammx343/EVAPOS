using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.PM;
using System.Xml;
using EvaPost.Classes;

namespace EvaPost
{
    [Activity(Label = "Menu", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Landscape)]
    public class Menu : Activity
    {
        LinearLayout venta, configuration;
        protected override void OnCreate(Bundle savedInstanceState)
        {   
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Menu);

            venta = FindViewById<LinearLayout>(Resource.Id.sell);
            configuration = FindViewById<LinearLayout>(Resource.Id.configuration);
            CreateTeclados();

            venta.Click += delegate {
                //Toast.MakeText(this, "Login", ToastLength.Long).Show();
                StartActivity(typeof(PanelDeVenta));
            };

            configuration.Click += delegate {
                //Toast.MakeText(this, "Login", ToastLength.Long).Show();
                StartActivity(typeof(PantallaConfiguracion));
            };
        }

        public void CreateTeclados()
        {
            ConfiguracionTeclado configuracion = new ConfiguracionTeclado();
            configuracion.GetTeclados();
        }
    }
}
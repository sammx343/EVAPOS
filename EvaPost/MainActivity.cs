using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content.PM;
using System;
using System.Web;
using EvaPost.Model;
using Redsis.EVA.Client.Core;
using Redsis.EVA.Client.Core.Solicitudes;
using System.Xml.Linq;
using EvaPOS;

namespace EvaPost
{
    [Activity(Label = "EvaPost", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Landscape)]
    public class MainActivity : Activity 
    {
        public ModelPanelOperador operador { get; set; }
        public ModelVista modelVista { get; set; }
        public ModelEstadoActual modelEstadoActual { get; set; }
        public ModelPanelVenta panelVenta { get; set; }

        public bool errorInicioSesion = true;

        TextView username, password, mensajeError;
        Button button;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            //Respuesta respuesta = new Respuesta();
            //Redsis.EVA.Client.Dispositivos.Devices.Instancia.DispositivoTeclado.ObtenerAccionTeclado("Venta", 6, out respuesta);

            //var login_data = System.Web.HttpUtility.ParseQueryString(""); 
            //var fragment = FragmentManager.FindFragmentById(Resource.Id.fragment_container) as BotoneraPrincipal;
            button = FindViewById<Button>(Resource.Id.loginButton);

            //PruebaCrud pruebaCrud = new PruebaCrud();
            //pruebaCrud.Connection();

            username = FindViewById<TextView>(Resource.Id.username);
            password = FindViewById<TextView>(Resource.Id.password);
            mensajeError = FindViewById<TextView>(Resource.Id.mensajeError);

            button.Click += delegate {
                //Toast.MakeText(this, "Login", ToastLength.Long).Show();
                //StartActivity(typeof(Menu));
                IniciarSesion();

                if (errorInicioSesion)
                {
                    mensajeError.Text = "Usuario o Contraseña inválidos";
                }
                else
                {
                    mensajeError.Text = "";
                }
            };

        }

        public void ErrorUsuario(bool error)
        {
            if (error)
                mensajeError.Text = "Usuario o Contraseña inválidos";
            else
                mensajeError.Text = "";
        }

        private void IniciarSesion()
        {
            try
            {
                modelVista = new ModelVista(this);
                operador = new ModelPanelOperador(this);
                modelEstadoActual = new ModelEstadoActual();
                panelVenta = new ModelPanelVenta(this);

                Entorno.Instancia.Vista = modelVista;
                Entorno.Instancia.Vista.PanelOperador = operador;
                Entorno.Instancia.Vista.EstadoApp = modelEstadoActual;
                Entorno.Instancia.BaseDato = new HandleBaseDatos();
                Entorno.Instancia.Vista.PanelVentas = panelVenta;

                string connectionString = "Data Source=192.168.36.50;Initial Catalog=eva2;User ID=admindb;Password=R3ds1s2016";

                Entorno.Instancia.BaseDato.CadenaConexion = connectionString;

               SolicitudIniciarSesion solicitud2 = new SolicitudIniciarSesion(Redsis.EVA.Client.Core.Enums.Solicitud.IniciarSesion, username.Text, password.Text);

                Reactor.Instancia.Procesar(solicitud2);
            }
            catch (Exception ex)
            {

            }
        }

    }
}


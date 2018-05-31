using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using EvaPost.Classes;
using System.Xml;
using Android.Content.Res;
using System.Text.RegularExpressions;
using static Android.Views.View;
using Android.Preferences;
using EvaPost.Activities;
using Redsis.EVA.Client.Core.Solicitudes;
using Redsis.EVA.Client.Core.Enums;
using Redsis.EVA.Client.Core;

namespace EvaPost
{
    public class FragmentoBotoneraPrincipal : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        String tipoTeclado = "";
        ConfiguracionTeclado configuracionTeclado;
        List<Teclado> teclados;

        public FragmentoBotoneraPrincipal(String tipoTeclado)
        {
            this.tipoTeclado = tipoTeclado;
            configuracionTeclado = new ConfiguracionTeclado();
            teclados = configuracionTeclado.GetTeclados();
        }
        
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            int rows, columns;
            ISharedPreferences preferences = PreferenceManager.GetDefaultSharedPreferences(Application.Context);

            if (preferences.GetString("Rows", "").Equals(""))
                rows = 9;
            else
                rows = int.Parse(preferences.GetString("Rows", "").ToString());

            if (preferences.GetString("Columns", "").Equals(""))
                columns = 9;
            else
                columns = int.Parse(preferences.GetString("Columns", "").ToString());
            
            View rootView = inflater.Inflate(Resource.Layout.FragmentoBotonera, container, false);
            //Layout botonera se encarga de crear el layout vacío principal done van los botones
            LayoutBotonera layoutBotonera = new LayoutBotonera();
            
            rootView = layoutBotonera.rootView(rows, columns);
            switch (tipoTeclado)
            {
                case "principal":
                    List<Boton> botonesPrincipal = configuracionTeclado.GetBotones(teclados, "principal");
                    List<Boton> functionButtons = configuracionTeclado.GetBotones(teclados, "funciones");
                    layoutBotonera.CrearBotonera(layoutBotonera.layouts, botonesPrincipal, 0, botonesPrincipal.Count, Resources);
                    layoutBotonera.CrearBotonera(layoutBotonera.layouts, functionButtons, columns * (rows - 1) + 1, rows * columns, Resources);
                    AsignarFuncionesABotones(botonesPrincipal);
                    AsignarFuncionesABotones(functionButtons);
                    break;
                case "tecladoPagos":
                    List<Boton> botonesPago = configuracionTeclado.GetBotones(teclados, "tecladoPagos");
                    layoutBotonera.CrearBotonera(layoutBotonera.layouts, botonesPago, columns * (rows - 1) + 1, rows * columns, Resources);
                    AsignarFuncionesABotones(botonesPago);
                    break;
            }
            if (tipoTeclado.Contains("Categoria"))
            {
                List<Boton> botones = configuracionTeclado.GetBotones(teclados, "tecladoCat");
                List<Boton> botonesDeCategoria = new List<Boton>();
                //Los botones que se necesitan obtener son aquellos que pertenecen a la categoría dada
                //por ejemplo: Categoría1, se necesitan escoger los botones que pertenecen a tecladoCat, y los
                //botones que pertenecen a Categoría1. La variable tipoTeclado poseé el nombre de la categoria
                foreach (Boton boton in botones)
                {
                    if (boton.getCategorias().Equals(tipoTeclado)) {
                        botonesDeCategoria.Add(boton);
                    }
                }

                layoutBotonera.CrearBotonera(layoutBotonera.layouts, botonesDeCategoria, 0, botonesDeCategoria.Count, Resources);
                AsignarFuncionesABotones(botonesDeCategoria);
            }
            return rootView;
        }

        //Asigna las acciones a los botones del teclado principal
        public void AsignarFuncionesABotones(List<Boton> botones)
        {
            foreach (Boton boton in botones)
            {
                String botonAction = (boton.getLabel().Length > 0) ? boton.getLabel() : boton.getFuncion();
                if (boton.GetButtonLayout() != null)
                {
                    boton.GetButtonLayout().Touch += (s, e) =>
                    {
                        var handled = false;

                        if (e.Event.Action == MotionEventActions.Down)
                        {
                            BotonOnPressColor(boton);
                            handled = true;
                        }

                        if (e.Event.Action == MotionEventActions.Up)
                        {
                            FuncionesBotones(botonAction, boton);
                            handled = true;
                        }

                        e.Handled = handled;
                    };
                }
            }
        }

        private void FuncionesBotones(String botonAction, Boton boton) {
            FragmentoConfiguration fragmentoConfiguration = new FragmentoConfiguration();

            String regexCodigoDato = "\\d.*\\d";
            Regex regex = new Regex(regexCodigoDato, RegexOptions.IgnoreCase);
            if (botonAction.Equals("Pagar"))
            {
                Intent intent = new Intent(Activity, typeof(PanelDePago));
                StartActivity(intent);
            }
            //Algunos volver en ciertos teclados cierran un fragment, no una actividad
            //los que tengan Label vacío cierran fragment, los que no, cierran actividades
            else if (botonAction.Equals("Volver") && boton.getLabel().Length == 0)
            {
                Fragment fragmentoBotoneraPrincipal = FragmentManager.FindFragmentByTag("BOTONERA_PRINCIPAL");
                fragmentoConfiguration.removeFragment(fragmentoBotoneraPrincipal, FragmentManager);
            }
            else if (botonAction.Equals("Volver"))
            {
                Activity.Finish();
            }
            else if (boton.getCategorias().Equals("Categorias"))
            {
                FragmentoBotoneraPrincipal fragmentoBotoneraPrincipal = new FragmentoBotoneraPrincipal(boton.getDato());

                fragmentoConfiguration.replaceFragments(fragmentoBotoneraPrincipal, Resource.Id.fragment_container, "BOTONERA_PRINCIPAL", FragmentManager);
                Toast.MakeText(Application.Context, boton.getDato(), ToastLength.Short).Show();
            }
            //Si un boton posee un dato, y ese dato posee solo números, se trata de un PRODUCTO
            //Se usa la expresión regular declarada arriba y se compara con el dato de un botón
            else if (regex.Match(boton.getDato()).Success)
            {
                AccionBotonArticulo(boton);
            }
            boton.GetButtonLayout().SetBackgroundColor(new Android.Graphics.Color(Application.Context.GetColor(Resource.Color.colorPrimaryDark)));
        }

        private void BotonOnPressColor(Boton boton)
        {
            boton.GetButtonLayout().SetBackgroundColor(new Android.Graphics.Color(Application.Context.GetColor(Resource.Color.botoneraOnPressed)));
        }

        private void AccionBotonArticulo(Boton boton)
        {
            SolicitudAgregarArticulo agregarArticulo = new SolicitudAgregarArticulo(Solicitud.AgregarItem, boton.getDato());

            Reactor.Instancia.Procesar(agregarArticulo);
        }
    }
}
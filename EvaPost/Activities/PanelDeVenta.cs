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
using System.Threading.Tasks;
using Org.W3c.Dom;
using System.Xml;
using static Android.Provider.DocumentsContract;
using Org.Apache.Http.Protocol;
using System.Web;
using Android.Preferences;
using Android.Content.PM;
using EvaPost.Classes;
using EvaPost.Model;
using Redsis.EVA.Client.Core;
using Redsis.EVA.Client.Core.Solicitudes;

namespace EvaPost
{
    [Activity(Label = "PanelDePago", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Landscape)]
    public class PanelDeVenta : Activity
    {
        //Pocisiones para OnTouch y OnPress en la Pantalla para detectar los gestos
        float y1 = 0, y2 = 0;
        FrameLayout panel;
        //public List<EArticulo> articulosComprados = new List<EArticulo>();
        public ModelPanelVenta panelVenta { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.PanelDeVenta);

            panelVenta = new ModelPanelVenta(this);
            Entorno.Instancia.Vista.PanelVentas = panelVenta;

            SolicitudIniciarSesion solicitud2 = new SolicitudIniciarSesion(Redsis.EVA.Client.Core.Enums.Solicitud.IniciarSesion, "1010", "1010");

            //SolicitudPanelVenta solicitudPanel = new SolicitudPanelVenta(Redsis.EVA.Client.Core.Enums.Paneles.PanelVenta);

            ISharedPreferences preferences = PreferenceManager.GetDefaultSharedPreferences(this);
            String orientation = preferences.GetString("Orientation", "");

            if (orientation.Equals("1"))
                SetContentView(Resource.Layout.PanelDeVenta);
            else
                SetContentView(Resource.Layout.PanelDeVenta2);

            FragmentoBotoneraPrincipal fragmentoBotoneraPrincipal = new FragmentoBotoneraPrincipal("principal");

            FragmentoConfiguration fragmentoConfiguration = new FragmentoConfiguration();
            fragmentoConfiguration.AddFragment(Resource.Id.fragment_container, fragmentoBotoneraPrincipal, "BotoneraPrincipal", FragmentManager);
            fragmentoConfiguration.AddFragment(Resource.Id.numberPadFragment, new FragmentoNumberPad(), "NumberPad", FragmentManager);
            fragmentoConfiguration.AddFragment(Resource.Id.operatorView, new FragmentoVistaOperador() , "VistaOperador", FragmentManager);
            
            panel = FindViewById<FrameLayout>(Resource.Id.panel);
        }

        public override Boolean DispatchTouchEvent(MotionEvent e)
        {
            setGesture(e);
            return base.DispatchTouchEvent(e);
        }

        public void setGesture(MotionEvent e)
        {
            FragmentoConfiguration fragmentoConfiguration = new FragmentoConfiguration();
            bool tirillaDePagoShowing = FragmentIsShowing("TIRILLA_DE_PAGO"); 
            int MIN_DISTANCE = 500;
            switch (e.Action)
            {
                case MotionEventActions.Down:
                    y1 = e.GetY();
                    break;
                case MotionEventActions.Up:
                    y2 = e.GetY();
                    float deltaY = y2 - y1;
                    if (Math.Abs(deltaY) > MIN_DISTANCE)
                    {
                        if (y2 > y1 && !tirillaDePagoShowing)
                        {
                            FragmentoTirillaDePago fragmentoTirillaDePago = new FragmentoTirillaDePago();
                            fragmentoConfiguration.replaceFragments(fragmentoTirillaDePago, Resource.Id.panel, "TIRILLA_DE_PAGO", FragmentManager);
                        }
                        else if (y1 > y2 && tirillaDePagoShowing)
                        {
                            FragmentoTirillaDePago frag = (FragmentoTirillaDePago)FragmentManager.FindFragmentByTag("TIRILLA_DE_PAGO");
                            fragmentoConfiguration.removeFragment(frag, FragmentManager);
                        }
                    }
                    break;
            }
        }
        
        public Boolean FragmentIsShowing(string fragmentTag)
        {
            FragmentoConfiguration fragmentoConfiguration = new FragmentoConfiguration();
            return fragmentoConfiguration.fragmentIsShowing(fragmentTag, FragmentManager);
        }

        public void updateArticleCodeText(String value)
        {
            FragmentoVistaOperador frag = (FragmentoVistaOperador)FragmentManager.FindFragmentByTag("VistaOperador");
            frag.updateArticleCodeText(value);
            //Toast.MakeText(this, value, ToastLength.Long).Show();
        }

        public void deleteArticleCodeText()
        {
            FragmentoVistaOperador frag = (FragmentoVistaOperador)FragmentManager.FindFragmentByTag("VistaOperador");
            frag.deleteArticleCodeText();
        }

        public void AddArticleButton() {
            //articulosComprados.Add(articulo);
            //FragmentoVistaOperador frag = (FragmentoVistaOperador)FragmentManager.FindFragmentByTag("VistaOperador");
            //frag.AddArticle(articulo);

            FragmentoTirillaDePago fragmentoTirilla = (FragmentoTirillaDePago)FragmentManager.FindFragmentByTag("TIRILLA_DE_PAGO");

            if (FragmentIsShowing("TIRILLA_DE_PAGO")) { }
                //fragmentoTirilla.AddProductToTirilla();
        }
    }
}
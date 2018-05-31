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
using EvaPost.Resources;

namespace EvaPost
{
    public class FragmentoTirillaDePago : Fragment
    {
        //List<EArticulo> listaProductos = new List<EArticulo>();

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);         
            
            // Create your fragment here
        }

        Button backToPanel;
        ListView productos;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View rootView = inflater.Inflate(Resource.Layout.FragmentoTirillaDePago, container, false);
            backToPanel = rootView.FindViewById<Button>(Resource.Id.backToPanel);
            backToPanel.Click += BackToPanel_Click;

            productos = rootView.FindViewById<ListView>(Resource.Id.listaArticulos);
            //AddProductToTirilla();

            return rootView;
        }

        /*public void AddProductToTirilla()
        {
            listaProductos = ((PanelDeVenta)this.Activity).articulosComprados;

            var adapter = new TirillaCustomAdapter(((PanelDeVenta)this.Activity), listaProductos);
            productos.Adapter = adapter;
        }
        */

        private void BackToPanel_Click(object sender, EventArgs e)
        {
            FragmentoConfiguration fragmentoConfiguration =  new FragmentoConfiguration();
            fragmentoConfiguration.removeFragment(this, FragmentManager);
        }
    }
}
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
using static Android.Views.View;
using EvaPost.Classes;

namespace EvaPost
{
    public class FragmentoVistaOperador : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        TextView articleCode, nombreArticulo, precioArticulo;
        LinearLayout showTirillaDePago;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View rootView = inflater.Inflate(Resource.Layout.FragmentoVistaOperador, container, false);

            articleCode = rootView.FindViewById<TextView>(Resource.Id.articleCode);
            nombreArticulo = rootView.FindViewById<TextView>(Resource.Id.nombreArticulo);
            precioArticulo = rootView.FindViewById<TextView>(Resource.Id.precio_articulo);

            showTirillaDePago = rootView.FindViewById<LinearLayout>(Resource.Id.buttonShowTirillaDePago);
            showTirillaDePago.Click += ShowTirillaDePago_Click;

            return rootView;
        }

        private void ShowTirillaDePago_Click(object sender, EventArgs e)
        {
            FragmentoConfiguration fragmentoConfiguration = new FragmentoConfiguration();

            if (!fragmentoConfiguration.fragmentIsShowing("TIRILLA_DE_PAGO", FragmentManager))
            {
                FragmentoTirillaDePago tirillaDePago = new FragmentoTirillaDePago();
                fragmentoConfiguration.replaceFragments(tirillaDePago, Resource.Id.panel, "TIRILLA_DE_PAGO", FragmentManager);
            }
        }

        //:::Métodos para cambiar texto de Artículos ::://

        //public void AddArticle(EArticulo articulo)
        //{
        //    //articleCode.Text = articulo.cod_imp;
        //    nombreArticulo.Text = articulo.descrip1;
        //    precioArticulo.Text = "$" + articulo.pre_venta1;
        //}

        public void updateArticleCodeText(String newText)
        {
            if (articleCode.Text.Length < 20)
                articleCode.Text += newText;
            else
                Toast.MakeText(Application.Context, "No se pueden colocar más números", ToastLength.Short).Show();
        }

        public void deleteArticleCodeText()
        {
            int articleCodeLength = articleCode.Text.Length;
            if (articleCodeLength > 0)
            {
                String newText = articleCode.Text.Substring(0, articleCodeLength - 1);
                articleCode.Text = newText;
            }
        }
    }
}
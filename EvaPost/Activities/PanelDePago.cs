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
using Android.Preferences;
using EvaPost.Classes;
using EvaPost.Fragments;

namespace EvaPost.Activities
{
    [Activity(Label = "PanelDePago")]
    public class PanelDePago : Activity
    {
        FrameLayout panel;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.PanelDeVenta);

            ISharedPreferences preferences = PreferenceManager.GetDefaultSharedPreferences(this);
            String orientation = preferences.GetString("Orientation", "");

            if (orientation.Equals("1"))
                SetContentView(Resource.Layout.PanelDeVenta);
            else
                SetContentView(Resource.Layout.PanelDeVenta2);

            FragmentoBotoneraPrincipal fragmentoBotoneraPrincipal = new FragmentoBotoneraPrincipal("tecladoPagos");
            FragmentoConfiguration fragmentos = new FragmentoConfiguration();
            fragmentos.AddFragment(Resource.Id.fragment_container, fragmentoBotoneraPrincipal, "BotoneraPrincipal", FragmentManager);
            fragmentos.AddFragment(Resource.Id.panel, new FragmentoPanelDePago(), "VistaOperador", FragmentManager);

            panel = FindViewById<FrameLayout>(Resource.Id.panel);
        }
    }
}
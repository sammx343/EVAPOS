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

namespace EvaPost
{
    [Activity(Label = "PantallaConfiguracion")]
    public class PantallaConfiguracion : Activity
    {
        EditText rows, columns;
        Button butoneraSize, configurationLayout1, configurationLayout2;
        TextView configuration;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.PantallaConfiguracion);

            rows = FindViewById<EditText>(Resource.Id.rows);
            columns = FindViewById<EditText>(Resource.Id.columns);
            butoneraSize = FindViewById<Button>(Resource.Id.changeButoneraSize);
            configurationLayout1 = FindViewById<Button>(Resource.Id.configurationLayout1);
            configurationLayout2 = FindViewById<Button>(Resource.Id.configurationLayout2);
            configuration = FindViewById<TextView>(Resource.Id.configuration);
            
            butoneraSize.Click += delegate
            {
                changeButtonsPrincipalRowColumn();
            };

            configurationLayout1.Click += delegate
            {
                changeScreenConfiguration(configurationLayout1.Tag.ToString());
            };

            configurationLayout2.Click += delegate
            {
                changeScreenConfiguration(configurationLayout2.Tag.ToString());
            };

            setTextConfigurationDefault();
        }

        public void changeScreenConfiguration(String tag)
        {//Botón que cambia la configuración de orientación de pantalla
            String screenConfigurationType = tag;
            Toast.MakeText(this, "Configuración de pantalla cambiada a " + screenConfigurationType, ToastLength.Long).Show();
            configuration.Text = configuration.Tag + tag;

            ISharedPreferences preferences = PreferenceManager.GetDefaultSharedPreferences(this);
            ISharedPreferencesEditor editor = preferences.Edit();
            editor.PutString("Orientation", screenConfigurationType);
            editor.Apply();
        }

        public void setTextConfigurationDefault()
        {
            ISharedPreferences preferences = PreferenceManager.GetDefaultSharedPreferences(this);
            String orientation = preferences.GetString("Orientation", "");// SharedPreferences para la orientación del dispositivo

            configuration.Text = configuration.Tag + orientation;

            String rows, columns;
            if (preferences.GetString("Rows", "").Equals(""))// SharedPreferences para definir las filas en la botonera
                rows = "8";
            else
                rows = preferences.GetString("Rows", "");

            if (preferences.GetString("Columns", "").Equals(""))// SharedPreferences para definir las columnas en la botonera
                columns = "8";
            else
                columns = preferences.GetString("Columns", "");

            this.rows.Text = rows;
            this.columns.Text = columns;
        }

        public void changeButtonsPrincipalRowColumn()
        {   //Botón que cambia la configuración de filas y columnas
            String rows = this.rows.Text;
            String columns = this.columns.Text;

            ISharedPreferences preferences = PreferenceManager.GetDefaultSharedPreferences(this);
            ISharedPreferencesEditor editor = preferences.Edit();
            editor.PutString("Rows", rows);
            editor.PutString("Columns", columns);
            editor.Apply();
            Toast.MakeText(this, "Configuración de botones cambiada a " + rows + "x" + columns, ToastLength.Long).Show();
        }
    }
}
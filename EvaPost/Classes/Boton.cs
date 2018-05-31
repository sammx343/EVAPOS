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

namespace EvaPost.Classes
{ 
    public class Boton : Java.Lang.Object, Java.IO.ISerializable
    {
        int order = 0;
        String label = string.Empty;
        String funcion = string.Empty;
        String imagen = string.Empty;
        String dato = string.Empty;
        String over = string.Empty;
        String enabled = string.Empty;
        String categorias = string.Empty;
        LinearLayout buttonLayout;
        
        public Boton(int order, String label, String funcion, String imagen, String dato, String over, String enabled, String categorias)
        {
            this.order = order;
            this.label = label;
            this.funcion = funcion;
            this.imagen = imagen;
            this.dato = dato;
            this.over = over;
            this.enabled = enabled;
            this.categorias = categorias;
        }

        public int getOrder()
        {
            return order;
        }

        public String getLabel()
        {
            return label;
        }

        public String getFuncion()
        {
            return funcion;
        }

        public String getImagen()
        {
            return imagen;
        }

        public String getDato()
        {
            return dato;
        }

        public String getOver()
        {
            return over;
        }

        public String getEnabled()
        {
            return enabled;
        }

        public String getCategorias() { return categorias; }

        public LinearLayout GetButtonLayout()
        {
            return buttonLayout;
        }

        public void SetButtonLayout(LinearLayout buttonLayout)
        {
            this.buttonLayout = buttonLayout;
        }
    }
}
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
using Java.Lang;

namespace EvaPost.Resources
{
    //public class ViewHolder : Java.Lang.Object
    //{
    //    public TextView cantArticulo { get; set; }

    //    public TextView nombreArticulo { get; set; }

    //    public TextView valorArticulo { get; set; }
    //}

    //public class TirillaCustomAdapter : BaseAdapter
    //{
    //    private Activity activity;
    //    //private List<EArticulo> articulos;

    //    public TirillaCustomAdapter(Activity activity, List<EArticulo> articulos)
    //    {
    //        this.activity = activity;
    //        this.articulos = articulos;
    //    }

    //    public override int Count {
    //        get
    //        {
    //           // return articulos.Count;
    //        }
    //    }

    //    public override Java.Lang.Object GetItem(int position)
    //    {
    //        return null;
    //    }

    //    public override long GetItemId(int position)
    //    {
    //        //return articulos[position].id;
    //    }

    //    public override View GetView(int position, View convertView, ViewGroup parent)
    //    {
    //        var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.ListaArticuloItem, parent, false);

    //        var cantArticulo = view.FindViewById<TextView>(Resource.Id.cantidadProducto);
    //        var nombreArticulo = view.FindViewById<TextView>(Resource.Id.nombreProducto);
    //        var precioArticulo = view.FindViewById<TextView>(Resource.Id.valorProducto);

    //        //cantArticulo.Text = 0 + "";
    //        //precioArticulo.Text = "$"+articulos[position].pre_venta1;
    //        //nombreArticulo.Text = articulos[position].descrip2;

    //        return view;
    //    }
    //}
}
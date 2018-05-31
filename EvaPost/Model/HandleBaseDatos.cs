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
using Redsis.EVA.Client.Core.Interfaces;

namespace EvaPost.Model
{
    public class HandleBaseDatos : IBaseDato
    {
        public string CadenaConexion
        {
            get;

            set;
        }
    }
}
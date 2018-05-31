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
using EvaPOS.Enums;
using Redsis.EVA.Client.Core.Interfaces;

namespace EvaPost.Model
{
    public class ModelEstadoActual : IEstadoActual
    {
        string estadoActual;
        public string EstadoActual
        {
            get
            {
                return estadoActual;
            }

            set
            {
                estadoActual = value;
            }
        }

        EstadosFSM estadoFSM;
        public EstadosFSM EstadoFSM
        {
            get
            {
                return estadoFSM;
            }

            set
            {
                estadoFSM = value;
            }
        }

        string estadoValido;
        public string EstadoValido
        {
            get
            {
                return estadoValido;
            }

            set
            {
                estadoValido = value;
            }
        }
    }
}
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
    public class ModelPanelOperador : Fragment, IPanelOperador
    {
        Context context;
        public ModelPanelOperador(Context context)
        {
            this.context = context;
        }

        string codigoTerminal;

        public string CodigoTerminal
        {
            get
            {
                return codigoTerminal;
            }

            set
            {
                codigoTerminal = value;

            }
        }

        string mensajeOperador;
        public string MensajeOperador
        {
            get
            {
                return mensajeOperador;
            }

            set
            {
                mensajeOperador = value;
                if (value.Contains("\n"))
                {
                    string[] splt = value.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    mensajeOperador = splt[0];
                }
                if (mensajeOperador.Length > 70)
                {
                    mensajeOperador = mensajeOperador.Substring(0, 67) + "...";
                }

                Console.WriteLine(mensajeOperador);
            }
        }

        string nombreUsuario;
        public string NombreUsuario
        {
            get
            {
                return nombreUsuario;
            }

            set
            {
                nombreUsuario = value;
            }
        }

        private string codigoCliente;
        public string CodigoCliente
        {
            get
            {
                return codigoCliente;
            }

            set
            {
                codigoCliente = value;
            }
        }
    }
}
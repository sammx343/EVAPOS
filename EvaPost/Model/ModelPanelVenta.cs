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
using System.Globalization;
using System.Threading.Tasks;
using Redsis.EVA.Client.Core.Enums;

namespace EvaPost.Model
{
    public class ModelPanelVenta : Fragment, Redsis.EVA.Client.Core.Interfaces.IPanelVentas
    {
        #region Propiedades
        Context context;

        public ModelPanelVenta(Context context)
        {
            this.context = context;
        }

        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        

        TaskCompletionSource<MessageResult> tcs = null;
        

        public List<IItemTirillaIU> Tirilla
        {
            get;
        }

        public IVisorCliente VisorCliente
        {
            get;
        }

        public IEstadoVenta VisorEstadoVenta
        {
            get;
        }

        string visorMensaje;
        public string VisorMensaje
        {
            get
            {
                return visorMensaje;
            }

            set
            {
                visorMensaje = value;
                ((MainActivity)context).ErrorUsuario(false);
            }
        }

        string visorOperador;
        public string VisorOperador
        {
            get
            {
                return visorOperador;
            }

            set
            {
                visorOperador = value;
                Console.WriteLine("");
                //((MainActivity)context).errorInicioSesion = false;
                ((MainActivity)context).ErrorUsuario(false);
            }
        }

        string visorEntrada;
        public string VisorEntrada
        {
            get
            {
                return visorEntrada;
            }

            set
            {
                Console.WriteLine("Compila usuario");
            }
        }

        public string NombrePanel
        {
            get;
            set;
        } = "PanelVenta";

        string visorFechaActual;
        public string VisorFechaActual
        {
            get { return visorFechaActual; }
            set
            {
                visorFechaActual = value;
            }
        }


        bool isFocus;
        public bool IsFocused
        {
            get { return isFocus; }
            set { isFocus = value;  }
        }

        public void SetTextBoxFocus()
        {
            IsFocused = true;
            log.Info("SetTextBoxFocus");
        }

        #endregion

        public void AgregarItemTirilla(IItemTirillaIU item)
        {
            
        }



        public void LimpiarVentaFinalizada()
        {
           
        }

        public void LimpiarOperacion()
        {
        }
        

        public void ConfirmarMensaje()
        {
        }

        public void CancelarMensaje()
        {
        }

        public bool CancelarTransaccion()
        {
            throw new NotImplementedException();
        }

        public Task<MessageResult> CancelarOperacion(string textoMensaje)
        {
            throw new NotImplementedException();
        }
    }
}
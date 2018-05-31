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
using Redsis.EVA.Client.Core.Enums;
using Redsis.EVA.Client.Core.Interfaces;

namespace EvaPost.Model
{
    public class ModelVista : Fragment, IVista
    {


        Context context;

        public ModelVista(Context context)
        {
            this.context = context;
        }

        #region Properties

        // Only test purposes
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public IPanelOperador PanelOperador
        {
            get;

            set;
        }

        public IPanelEspera PanelEspera
        {
            get;
            set;
        }

        public IPanelVentas PanelVentas
        {
            get;
            set;
        }

        public IPanelLogin PanelLogin
        {
            get;

            set;
        }

        public IPanelPago PanelPago
        {
            get;

            set;
        }

        string mensajeVista;

        public string MensajeVista
        {
            get
            {
                return mensajeVista;
            }

            set
            {
                mensajeVista = value;
            }
        }

        public IPanelDispositivo PanelDispositivo
        {
            get;

            set;
        }

        public IEstadoActual EstadoApp
        {
            get;

            set;
        }

        public IPanelActivo PanelActivo
        {
            get;

            set;
        }

        public IPanelTirilla PanelTirilla
        {
            get;
            set;
        }

        public IPanelPrestamos PanelPrestamos
        {
            get;

            set;
        }

        public IPanelVentaTouch PanelVentasTouch
        {
            get;

            set;
        }

        public IPanelRecogidas PanelRecogidas
        {
            get;

            set;
        }

        public IPantallaCliente PantallaCliente
        {
            get;

            set;
        }

        public IPanelRecogidas ModalRecogidas
        {
            get;

            set;
        }

        public IPanelVentaEspecial ModalVentaEspecial
        {
            get;

            set;
        }

        public IPanelAjuste ModalAjustes
        {
            get;
            set;
        }

        public IPanelPagoManual PanelPagoManual
        {
            get;

            set;
        }

        public IPanelCierreDatafono PanelCierreDatafono
        {
            get;

            set;
        }

        public IPanelCliente ModalClientes
        {
            get;

            set;
        }

        public IPanelArqueo PanelArqueo
        {
            get;

            set;
        }

        public IMensajeDispositivo<MessageResult> MensajeUsuario
        {
            get;

            set;
        }

        public IPanelModalPagoManual ModalPagoManual { get; set; }
        public IPanelIntervencion PanelIntervencion { get; set; }
        IMensajeDispositivo<MessageResult> IVista.MensajeUsuario { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void MostrarPanelInicioSesion()
        {
            throw new NotImplementedException();
        }

        public void MostrarPanelVenta()
        {
            context.StartActivity(typeof(Menu));
        }

        public void MostrarPanelPagos()
        {
            throw new NotImplementedException();
        }

        public void MostrarTirilla()
        {
        }

        public void MostrarPanelDispositivos()
        {
            throw new NotImplementedException();
        }

        public void MostrarPanelTerminalAsegurada()
        {
            throw new NotImplementedException();
        }

        public void MostrarPanelPrestamos()
        {
            throw new NotImplementedException();
        }

        public void MostrarPantallaCliente()
        {
            throw new NotImplementedException();
        }

        public void MostarPanelPagoManual()
        {
            throw new NotImplementedException();
        }

        public void MostrarModalPanelPagoManual()
        {
            throw new NotImplementedException();
        }

        public void MostrarPanelCierreDatafono()
        {
            throw new NotImplementedException();
        }

        public void MostrarModalCierreDatafono()
        {
            throw new NotImplementedException();
        }

        public void MostrarPanelRecogida(string codigo)
        {
            throw new NotImplementedException();
        }

        public void MostrarModalRecogida()
        {
            throw new NotImplementedException();
        }

        public void MostrarModalAjustes()
        {
            throw new NotImplementedException();
        }

        public void MostrarModalVentaEspecial()
        {
            throw new NotImplementedException();
        }

        public void MostrarModalArqueo()
        {
            throw new NotImplementedException();
        }

        public void MostrarDisplayCliente(DisplayCliente display)
        {
            throw new NotImplementedException();
        }

        public void MostrarModalClientes()
        {
            throw new NotImplementedException();
        }

        public void LimpiarPantallaCliente()
        {
            throw new NotImplementedException();
        }

        public void MostrarPanelIntervencion(string codigo)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region Constructor


        #endregion

        #region Metodos y funciones

        #endregion
    }
}
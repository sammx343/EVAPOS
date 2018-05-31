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
    class ConfiguracionTeclado
    {
        public static List<Teclado> teclados = null;
        readonly String[] identificadores =  { "principal", "funciones", "ajuste", "tecladoNoventa", "tecladoDescuentos",
                                               "tecladoPagos", "tecladoCat"};

        public List<Teclado> GetTeclados()
        {
            if (teclados == null || teclados.Count == 0)
            {
                teclados = CreateTeclados();
            }
            return teclados;
        }

        public List<Boton> GetBotones(List<Teclado> teclados, String id)
        {
            List<Boton> botones = null;
            foreach (Teclado teclado in teclados)
            {
                if (teclado.GetId().Equals(id))
                {
                    botones = teclado.GetBotones();
                }
            }
            return botones;
        }
        
        private List<Teclado> CreateTeclados()
        {
            List<Teclado> tecladoTemporal = new List<Teclado>();
            foreach (String id in identificadores)
            {
                tecladoTemporal.Add(new Teclado(id));
            }
            return tecladoTemporal;
        }
    }
}
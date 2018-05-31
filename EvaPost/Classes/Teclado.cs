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
using System.Xml;

namespace EvaPost.Classes
{
    public class Teclado
    {
        String id;
        List<Boton> botones;

        public Teclado(String id)
        {
            this.id = id;
            botones = GetParsedXML(id);
        }

        private List<Boton> GetParsedXML(String tecladoName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Application.Context.Assets.Open("teclado.xml"));
            XMLButtonParser buttonParser = new XMLButtonParser();

            return buttonParser.getXMLfromResource(doc, tecladoName);
        }

        public String GetId()
        {
            return id;
        }

        public List<Boton> GetBotones()
        {
            return botones;
        }
    }
}
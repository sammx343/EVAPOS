using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using EvaPost.Classes;

namespace EvaPost
{
    public class FragmentoNumberPad : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View rootView = inflater.Inflate(Resource.Layout.FragmentoNumberPad, container, false);

            Button but = rootView.FindViewById<Button>(Resource.Id.sell);

            int[] idButtons = { Resource.Id.number1, Resource.Id.number2, Resource.Id.number3, Resource.Id.escape,
                                Resource.Id.number4,Resource.Id.number5,Resource.Id.number6, Resource.Id.borrar,
                                Resource.Id.number7, Resource.Id.number8, Resource.Id.number9, Resource.Id.multiplicar,
                                Resource.Id.number0, Resource.Id.number00, Resource.Id.punto, Resource.Id.aceptar};

            List<Button> numberButtons = new List<Button>();
            FragmentoConfiguration fragmentoConfiguration = new FragmentoConfiguration();
            //Si la tirilla de pago NO se está mostrando, los botones no tienen funcionalidad así se corrige 
            //el bug que causa que los botones funcionen aunque exista un fragment encima de ellos
            for (int index = 0; index < idButtons.Length; index++)
                {
                    // Si el boton se encuentra en al posición 3,7,11 o 15, corresponde a una tecla de función
                    // por lo tanto se le asigna la función que corresponda.
                    // En cualquier otro caso, el botón corresponde a un número o signo, por lo que se agrega 
                    // la función que cambia el texto del artículo
                    switch (index)
                    {
                        case 3:
                            break;
                        case 7:
                            ImageButton buttonEsc = rootView.FindViewById<ImageButton>(idButtons[index]);
                            buttonEsc.Click += delegate
                            {
                                if (!fragmentoConfiguration.fragmentIsShowing("TIRILLA_DE_PAGO", FragmentManager))
                                {
                                    ((PanelDeVenta)Activity).deleteArticleCodeText();
                                }
                            };
                            break;
                        case 11:
                            break;
                        case 15:
                            break;
                        default:
                            Button button = rootView.FindViewById<Button>(idButtons[index]);
                            button.Click += delegate
                            {
                                if (!fragmentoConfiguration.fragmentIsShowing("TIRILLA_DE_PAGO", FragmentManager))
                                {
                                    ((PanelDeVenta)this.Activity).updateArticleCodeText(button.Text);
                                }
                            };
                            break;
                }
            }
            



            return rootView;
        }
    }
}
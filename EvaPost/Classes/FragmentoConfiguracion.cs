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
    class FragmentoConfiguration : Activity
    {
        public void AddFragment(int fragmentId, Fragment fragment, String tag, FragmentManager fragmentManager)
        {
            FragmentTransaction transaction = fragmentManager.BeginTransaction();
            transaction.Add(fragmentId, fragment, tag);
            //ft.SetTransition(FragmentTransaction.TransitFragmentFade);
            transaction.Commit();
        }

        public void replaceFragments(Fragment fragment, int idContainer, String fragmentTag, FragmentManager fragmentManager)
        {
            FragmentTransaction transaction = fragmentManager.BeginTransaction();
            transaction.SetCustomAnimations(Resource.Animator.slide_in_up, Resource.Animator.slide_in_down);
            transaction.Replace(idContainer, fragment, fragmentTag);
            transaction.AddToBackStack(null);
            transaction.Commit();
        }

        public void removeFragment(Fragment myFrag, FragmentManager fragmentManager)
        {
            FragmentTransaction transaction = fragmentManager.BeginTransaction();
            transaction.SetCustomAnimations(Resource.Animator.slide_from_out_bottom, Resource.Animator.slide_in_bottom);
            transaction.Remove(myFrag);
            transaction.Commit();
            fragmentManager.PopBackStack();
        }

        //Confirmar si un fragment se está mostrando
        public bool fragmentIsShowing(String fragmentTag, FragmentManager fragmentManager)
        {
            Fragment myFragment = fragmentManager.FindFragmentByTag(fragmentTag);
            return (myFragment != null && myFragment.IsVisible);
        }
    }
}
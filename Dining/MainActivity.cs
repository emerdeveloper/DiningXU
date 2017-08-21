using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;

namespace Dining
{
    [Activity(Label = "Dining", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            //LinearLayoutManager arranges your items in a single column or row
            var linearLayautManager = new LinearLayoutManager(this, //Context
                LinearLayoutManager.Vertical, //Orientation
                false);//Reverse (e.g. in a vertical list, it would layout items from bottom to top)
            //add LinearLayoutManager to recyclerView
            recyclerView.SetLayoutManager(linearLayautManager);

            var adapter = new RestaurantAdapter(SampleData.GetRestaurants());
            System.Diagnostics.Debug.WriteLine("cantidad de elementos" + SampleData.GetRestaurants().Count);
            adapter.ItemClick += OnItemClick;//Subscribe a handler to your adapter's ItemClick event
            recyclerView.SetAdapter(adapter);
        }

        private void OnItemClick(object sender, int e)
        {
            System.Diagnostics.Debug.WriteLine("Click"+ e);//print out the position of the click.
        }
    }
}


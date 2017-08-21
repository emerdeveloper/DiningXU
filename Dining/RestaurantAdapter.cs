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
using Android.Support.V7.Widget;

namespace Dining
{
    public class RestaurantAdapter : RecyclerView.Adapter
    {
        List<Restaurant> restaurants;
        public event EventHandler<int> ItemClick;//Evento

        public RestaurantAdapter(List<Restaurant> restaurants)
        {
            this.restaurants = restaurants;
        }
        //returns the number of items in your data set
        public override int ItemCount { get { return restaurants.Count; } }
        //Inflate a layout file and instantiate a view holder
        //inflates a layout and creates a view holder
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent,///The ViewGroup that will contain your inflated layout
            int viewType)
        {//first inflate your Restaurant.axml
            //inflation is the process of instantiating the contents of a layout file
            var layout = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Restaurant, parent, false);
            // create a view holder passing the inflated layout file to the view-holder constructor
            return new RestaurantViewHolder(layout, OnItemClick);//we match the Adapter with Holder
        }
        // load the new data into your views.
        //OnBindViewHolder copies the data into the UI
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder,//Destination
            int position)//Source
        {
            var vh = (RestaurantViewHolder)holder;
            //Use the view holder to load the new data at the given position into your views
            vh.Name.Text = restaurants[position].Name;
            vh.Rating.Rating = restaurants[position].Rating;
        }

        //report it to the client code
        void OnItemClick(int position)
        {
            /*if (ItemClick != null) {
                ItemClick(this, position);
            }*/
            ItemClick?.Invoke(this, position);
        }
    }
}
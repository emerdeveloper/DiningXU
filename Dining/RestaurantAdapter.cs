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

        public RestaurantAdapter(List<Restaurant> restaurants)
        {
            this.restaurants = restaurants;
        }
        //returns the number of items in your data set
        public override int ItemCount { get { return restaurants.Count; } }
        //Inflate a layout file and instantiate a view holder
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {//first inflate your Restaurant.axml
            var layout = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Restaurant, parent, false);
            // create a view holder passing the inflated layout file to the view-holder constructor
            return new RestaurantViewHolder(layout);
        }
        // load the new data into your views.
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var vh = (RestaurantViewHolder)holder;
            //Use the view holder to load the new data at the given position into your views
            vh.Name.Text = restaurants[position].Name;
            vh.Rating.Rating = restaurants[position].Rating;
        }
    }
}
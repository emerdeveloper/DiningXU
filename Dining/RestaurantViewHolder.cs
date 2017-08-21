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
    /**
     * RecyclerView handles scrolling and manages a pool of views
     * 
     * ViewHolder stores view references, detects item-click
     * 
     * 
     * The goal here is to code a view holder for your restaurant layout file. The restaurant layout contains one TextView and one RatingBar so your view holder will have one property for each of those two views.
     **/
    public class RestaurantViewHolder : RecyclerView.ViewHolder
    {
        public TextView Name { get; set; }
        public RatingBar Rating { get; set; }
        Action<int> listener;

        public RestaurantViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            this.listener = listener;
            itemView.Click += OnClickItem;
            Name = itemView.FindViewById<TextView>(Resource.Id.nameTextView);
            Rating = itemView.FindViewById<RatingBar>(Resource.Id.ratingBar);
        }

        //retrieve the AdapterPosition
        //detect the user's action
        private void OnClickItem(object sender, EventArgs e)
        {
            int position = base.AdapterPosition;

            //check for null before you invoke the listener; the solution won't do this to keep the code simple
            if (position == RecyclerView.NoPosition) { return; }

            listener(position);
        }
    }
}
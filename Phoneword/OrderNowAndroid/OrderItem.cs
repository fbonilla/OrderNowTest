using System;
using Android.Graphics.Drawables;

namespace OrderNowAndroid
{
	public class OrderItem: RestaurantItem
	{
		private readonly DateTime mTimeOrdered;

		public OrderItem (string name, float price, Drawable imgItem, DateTime timeOrdered) : base(name, price, imgItem)
		{
			mTimeOrdered = timeOrdered;
		}

		public DateTime TimeOrdered
		{
			get{ return mTimeOrdered;}
		}
	}
}


using System;
using Android.Graphics.Drawables;

namespace OrderNowAndroid
{
	public class RestaurantItem
	{
		private string mName;
		private float mPrice;
		private readonly Drawable mImgItem;

		public RestaurantItem(string name, float price, Drawable imgItem)
		{
			mName = name;
			mPrice = price;
			mImgItem = imgItem;
		}

		public string Name
		{
			get{ return mName; }
		}

		public float Price
		{
			get{ return mPrice; }
		}

		public Drawable ImgItem
		{
			get{ return mImgItem; }
		}
	}
}


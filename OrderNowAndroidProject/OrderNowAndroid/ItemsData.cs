using System;
using System.Collections.Generic;
using Android.Content.Res;

namespace OrderNowAndroid
{
	public class ItemsData
	{
		private static List<RestaurantItem> mDinnerItems;
		private static List<RestaurantItem> mDrinksItems;
		private static Android.Content.Res.Resources mResources;

		// disable constructor
		private ItemsData ()
		{
		}

		public static List<RestaurantItem> DinnerItems
		{
			get{ 
				if (mDinnerItems == null) {
					mDinnerItems = new List<RestaurantItem> ();
					retrieveDinnerItems ();
				}
				return mDinnerItems;
			}
		}

		public static List<RestaurantItem> DrinksItems
		{
			get{ 
				if (mDrinksItems == null) {
					mDrinksItems = new List<RestaurantItem> ();
					retrieveDrinksItems ();
				}
				return mDrinksItems;
			}
		}

		// temporary out of memory solution
		public static void emptyMenuLists()
		{
			if (mDinnerItems != null) {
				mDinnerItems.Clear ();
				mDinnerItems = null;
			}
			if (mDrinksItems != null) {
				mDrinksItems.Clear ();
				mDrinksItems = null;
			}
		}

		// // Will retrieve restaurant item on the database (MUST BE RETRIEVED ONLY ONCE)
		public static void retrieveDinnerItems()
		{	
			if (mDinnerItems != null) {
				mDinnerItems.Add (new RestaurantItem ("Calamari", 7.95f, mResources.GetDrawable(Resource.Drawable.calamari)));
				mDinnerItems.Add (new RestaurantItem ("Fries", 3.00f, mResources.GetDrawable(Resource.Drawable.fries)));
				mDinnerItems.Add (new RestaurantItem ("Chicken wings", 8.95f, mResources.GetDrawable(Resource.Drawable.chickenWings)));
				mDinnerItems.Add (new RestaurantItem ("Steak", 15.95f, mResources.GetDrawable(Resource.Drawable.steak)));
				mDinnerItems.Add (new RestaurantItem ("Sports Station Nachos", 10.95f, mResources.GetDrawable(Resource.Drawable.sdsNachos)));
				mDinnerItems.Add (new RestaurantItem ("Spaghetti Bolognese", 11.95f, mResources.GetDrawable(Resource.Drawable.spaghettiBolognese)));
				mDinnerItems.Add (new RestaurantItem ("Ceasar Salad", 6.95f, mResources.GetDrawable(Resource.Drawable.ceasarSalad)));
				mDinnerItems.Add (new RestaurantItem ("Pizza : Pepperoni", 12.95f, mResources.GetDrawable(Resource.Drawable.pepperoniPizza)));
			}
		}

		public static void retrieveDrinksItems()
		{	
			if (mDrinksItems != null) {
			
				mDrinksItems.Add (new RestaurantItem ("Pint of Alexander Keith", 7.50f, mResources.GetDrawable(Resource.Drawable.alexanderKeithPint)));
				mDrinksItems.Add (new RestaurantItem ("Pitcher (2L) of Budweiser", 14.50f, mResources.GetDrawable(Resource.Drawable.budweiser2Liters)));
				mDrinksItems.Add (new RestaurantItem ("Pitcher (4L) of Rickard's Red", 26.50f, mResources.GetDrawable(Resource.Drawable.RickardsRed4L)));
				mDrinksItems.Add (new RestaurantItem ("Slapshot (500mL)", 8.00f, mResources.GetDrawable(Resource.Drawable.slapshot500ml)));
				mDrinksItems.Add (new RestaurantItem ("Mojito (500mL)", 8.00f, mResources.GetDrawable (Resource.Drawable.mojito)));
				mDrinksItems.Add (new RestaurantItem ("Malibu red (500mL)", 8.00f, mResources.GetDrawable(Resource.Drawable.malibuRed)));

			}
		}

		public static Android.Content.Res.Resources Resources
		{
			set{ 
				mResources = value;
			}
		}

	}
}


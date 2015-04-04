using System;
using Android.Support.V7.Widget;
using Android.App;
using Android.Views;
using Android.OS;
using System.Collections.Generic;

namespace OrderNowAndroid
{
	public class MenuSectionFragment : Fragment
	{
		private readonly RecyclerView.LayoutManager mLayoutManager;
		private RecyclerView mRecyclerView;
		private readonly List<RestaurantItem> mItems;
		private RecyclerView.Adapter mMenuItemsAdapter;
		private readonly Activity mActivity; 
		private bool recyclerViewConfigured ;

		public MenuSectionFragment (Activity activity, List<RestaurantItem> menuItems)
		{
			mLayoutManager = new LinearLayoutManager (activity);
			mActivity = activity;
			mItems = menuItems;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);

			var view = inflater.Inflate(Resource.Layout.menu_section_items, container, false);

			//Recycler view
			mRecyclerView = view.FindViewById<RecyclerView> (Resource.Id.recyclerViewMenu);

			if (!recyclerViewConfigured) {
				mRecyclerView.SetLayoutManager (mLayoutManager);

				// Have an adapter for each meal section (breakfast, dinner, drink, specials & promotions)
				mMenuItemsAdapter = new MenuItemsAdaptor (mItems);

				// Give activity to adapter for confirm AlertDialog builder
				((MenuItemsAdaptor)mMenuItemsAdapter).mActivity = mActivity;

				mRecyclerView.SetAdapter (mMenuItemsAdapter);
				recyclerViewConfigured = true;
			}

			return view;
		}

	}
}


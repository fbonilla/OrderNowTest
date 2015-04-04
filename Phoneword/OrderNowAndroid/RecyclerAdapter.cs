using System;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Android.Content.Res;
using Android.Graphics.Drawables;

namespace OrderNowAndroid
{
	public class RecyclerAdapter : RecyclerView.Adapter
	{
		private readonly List<RestaurantItem> mItems;
		private RecyclerView mRecyclerView;

		public RecyclerAdapter (List<RestaurantItem> items, RecyclerView recyclerView)
		{
			mItems = items;
			mRecyclerView = recyclerView;
		}

		public class MyView : RecyclerView.ViewHolder
		{
			public View mMainView { get; set; }
			public TextView mName { get; set; }
			public TextView mPrice { get; set; }
			public ImageView mImgItem { get; set; }

			public MyView(View view) : base(view)
			{
				mMainView = view;
			}
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			View viewItemRow = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_card, parent, false); 
		
			TextView txtName = viewItemRow.FindViewById<TextView> (Resource.Id.txtName);
			TextView txtPrice = viewItemRow.FindViewById<TextView> (Resource.Id.txtPrice);
			ImageView imgItem = viewItemRow.FindViewById<ImageView> (Resource.Id.imgItem);

			MyView view = new MyView (viewItemRow) {mName = txtName , mPrice = txtPrice, mImgItem = imgItem};
			return view;
		}

		// Bind the data
		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			MyView myHolder = holder as MyView;
			RestaurantItem item = mItems [position];
			myHolder.mName.Text = item.Name;
			myHolder.mPrice.Text = "$" + item.Price;
			//Drawable d = Resources.GetDrawable (Resource.Drawable.calamari);

			myHolder.mImgItem.SetImageDrawable (item.ImgItem);
		}

		public override int ItemCount
		{
			get { return mItems.Count; }
		}
	}
}


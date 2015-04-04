using System;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Android.Content.Res;
using Android.Graphics.Drawables;

namespace OrderNowAndroid
{
	public class MenuSection : RecyclerView.Adapter
	{
		private readonly List<RestaurantItem> mItems;
		//private RecyclerView mRecyclerView;

		public MenuSection (List<RestaurantItem> items)
		{
			mItems = items;
			//mRecyclerView = recyclerView;
		}

		public class MyView : RecyclerView.ViewHolder
		{
			public View mMainView { get; set; }
			public TextView mName { get; set; }
			public TextView mPrice { get; set; }
			public ImageView mImgItem { get; set; }
			public ImageButton mImgBtnOrderNow { get; set;}


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
			ImageButton imgBtnOrderNow = viewItemRow.FindViewById<ImageButton> (Resource.Id.imgBtnOrderNow);

			MyView view = new MyView (viewItemRow) {mName = txtName , mPrice = txtPrice, mImgItem = imgItem, mImgBtnOrderNow = imgBtnOrderNow};
			return view;
		}

		// Bind the data
		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			MyView myHolder = holder as MyView;

			RestaurantItem item = mItems [position];

			myHolder.mImgItem.SetImageDrawable (item.ImgItem);
		
			myHolder.mName.Text = item.Name;
			myHolder.mPrice.Text = "$" + item.Price;

			myHolder.mImgBtnOrderNow.Click += delegate {
				OrderSection.GetInstance().Add(new OrderItem(item.Name, item.Price, item.ImgItem, DateTime.Now));
			};


		}

		public override int ItemCount
		{
			get { return mItems.Count; }
		}
	}
}


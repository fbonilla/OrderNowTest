using System;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Android.Content.Res;
using Android.Graphics.Drawables;

namespace OrderNowAndroid
{
	public class OrderSection : RecyclerView.Adapter
	{
		private readonly List<OrderItem> mOrderItems;
		private static OrderSection orderSection;

		private OrderSection ()
		{
			mOrderItems = new List<OrderItem>();
			//mRecyclerView = recyclerView;
		}
		//test commit
		public class MyView : RecyclerView.ViewHolder
		{
			public View mMainView { get; set; }
			public TextView mName { get; set; }
			public TextView mTime { get; set; }
			public ImageView mImgItem { get; set; }

			public MyView(View view) : base(view)
			{
				mMainView = view;
			}
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			View viewItemRow = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.order_card, parent, false); 

			TextView txtName = viewItemRow.FindViewById<TextView> (Resource.Id.txtName);
			TextView txtPrice = viewItemRow.FindViewById<TextView> (Resource.Id.txtTime);
			ImageView imgItem = viewItemRow.FindViewById<ImageView> (Resource.Id.imgItem);

			MyView view = new MyView (viewItemRow) {mName = txtName , mTime = txtPrice, mImgItem = imgItem};
			return view;
		}

		// Bind the data
		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			MyView myHolder = holder as MyView;

			OrderItem item = mOrderItems [position];

			myHolder.mImgItem.SetImageDrawable (item.ImgItem);

			myHolder.mName.Text = "1 x " + item.Name;
			myHolder.mTime.Text = "Ordered : \r\n" + item.TimeOrdered;

		}

		public override int ItemCount
		{
			get { return mOrderItems.Count; }
		}

		public void Add(OrderItem item)
		{
			mOrderItems.Add (item);
			NotifyDataSetChanged();
		}

		public static OrderSection GetInstance()
		{
			if(orderSection == null)
				orderSection = new OrderSection();

			return orderSection;
		}
	
	}
}


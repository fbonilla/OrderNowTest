using System;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.App;

namespace OrderNowAndroid
{
	public class MenuItemsAdaptor : RecyclerView.Adapter
	{
		private readonly List<RestaurantItem> mItems;
		public Activity mActivity { get; set; }

		//private RecyclerView mRecyclerView;

		public MenuItemsAdaptor (List<RestaurantItem> items)
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
			myHolder.mPrice.Text = "$" + String.Format("{0:0.00}", item.Price);

			myHolder.mImgBtnOrderNow.Click += delegate {

				FragmentTransaction transaction = mActivity.FragmentManager.BeginTransaction();
				Dialog_ordernow_confirm confirmDialog = new Dialog_ordernow_confirm(1, item.Name, item.Price);
				confirmDialog.Show(transaction, "confirm order fragment");

				// ExecutePendingTransaction will call OnCreateView from dialog (else View will be null)
				mActivity.FragmentManager.ExecutePendingTransactions();

				Button btnConfirm = confirmDialog.View.FindViewById<Button>(Resource.Id.btnConfirmOrderNow);
				btnConfirm.Click += delegate {
					OrderSection.GetInstance().Add(new OrderItem(item.Name, item.Price, item.ImgItem, DateTime.Now)); 
					confirmDialog.Dismiss();
				};

				confirmDialog.View.FindViewById<Button>(Resource.Id.btnCancelOrderNow).Click += delegate {
					confirmDialog.Dismiss();
				};
					
			};


		}

		public override int ItemCount
		{
			get { return mItems.Count; }
		}
	}
}


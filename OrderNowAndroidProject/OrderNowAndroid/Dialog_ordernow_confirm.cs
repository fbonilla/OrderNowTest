using System;
using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace OrderNowAndroid
{
	public class Dialog_ordernow_confirm : DialogFragment
	{
		private int mQuantity;
		private string mItemName;
		private float mPrice;

		public Dialog_ordernow_confirm (int quantity, string itemName, float price)
		{
			mQuantity = quantity;
			mItemName = itemName;
			mPrice = price;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);

			var view = inflater.Inflate (Resource.Layout.dialog_ordernow_confirm, container, false);

			Dialog.SetTitle ("Confirm");

			TextView txtItemDetails = view.FindViewById<TextView> (Resource.Id.txtOrderDetails);

			txtItemDetails.Text = mQuantity + " x " + mItemName;

			txtItemDetails.Text += "\nFor " + "$" + String.Format ("{0:0.00}", mPrice) + " ?";

			return view;
		}

		public override void OnActivityCreated(Bundle savedInstanceState)
		{
			base.OnActivityCreated (savedInstanceState);
			Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
		}

	}
}


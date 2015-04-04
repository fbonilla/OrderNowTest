using System;
using Android.App;
using Android.Views;
using Android.OS;

namespace OrderNowAndroid
{
	public class SignInFragment : Fragment
	{

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);

			var view = inflater.Inflate(Resource.Layout.sign_in, container, false);

			return view;
		}
	}
}



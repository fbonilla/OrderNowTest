using System;
using Android.App;
using Android.Views;
using Android.OS;

namespace OrderNowAndroid
{
	public class MenuFragment : Fragment
	{

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var view = inflater.Inflate(Resource.Layout.menu_sections, container, false);

			return view;
		}
	}
}


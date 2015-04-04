using System;
using Android.App;
using Android.Views;
using Android.OS;

namespace OrderNowAndroid
{
	public class ProfileSectionFragment : Fragment
	{

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);

			var view = inflater.Inflate(Resource.Layout.profile_section, container, false);

			return view;
		}
	}
}



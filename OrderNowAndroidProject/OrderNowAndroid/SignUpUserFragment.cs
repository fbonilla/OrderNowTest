﻿using System;
using Android.App;
using Android.Views;
using Android.OS;

namespace OrderNowAndroid
{
	public class SignUpUserFragment : Fragment
	{

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);

			var view = inflater.Inflate(Resource.Layout.sign_up_user, container, false);

			return view;
		}
	}
}



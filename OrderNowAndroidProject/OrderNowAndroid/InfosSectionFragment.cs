using System;
using Android.App;
using Android.Views;
using Android.OS;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace OrderNowAndroid
{
	public class InfosSectionFragment : Fragment,IOnMapReadyCallback
	{
		private GoogleMap mMap;


		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);

			var view = inflater.Inflate(Resource.Layout.infos_section, container, false);

			//Set up google maps coords in infos section
			SetUpMap ();

			return view;
		}

		private void SetUpMap()
		{
			if (mMap == null) 
			{
				FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
			}
		}



		//Launching of the actual map
		public void OnMapReady (GoogleMap googleMap)
		{
			// Clean memory to prevent crashing from out of memory
			System.GC.Collect ();

			mMap = googleMap;

			SetUpMapToStationsView ();

			mMap.CameraChange += delegate(object sender, GoogleMap.CameraChangeEventArgs e)
			{
				// Navigation cleaning to prevent out of memory
				System.GC.Collect();
			};
		}

		void SetUpMapToStationsView ()
		{
			
			mMap.MapType = GoogleMap.MapTypeNormal;
			//Instances of latitutes and longitudes
			LatLng downtownlatlng = new LatLng (45.505616, -73.569678);
			LatLng gayLatLng = new LatLng (45.516428, -73.558173);
			LatLng jewLatLng = new LatLng (45.493632, -73.581836);
			//Default position of the camera on the map, the chosen location is montreal downtown
			CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom (downtownlatlng, 12);
			mMap.MoveCamera (camera);
			//Creation of the marker from the first position
			MarkerOptions gayStationOptions = new MarkerOptions ();
			gayStationOptions.SetPosition (gayLatLng);
			//Creation of the marker frome the second position
			MarkerOptions jewStationOptions = new MarkerOptions ();
			jewStationOptions.SetPosition (jewLatLng);
			//Adding the markers on the map
			mMap.AddMarker (gayStationOptions);
			mMap.AddMarker (jewStationOptions);
		}

		public override void OnLowMemory ()
		{
			base.OnLowMemory ();

			mMap.Clear ();
			System.GC.Collect();

			//Set back the camera to all sports station view
			SetUpMapToStationsView ();
		}
	}

}
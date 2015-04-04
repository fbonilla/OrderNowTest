using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Content.PM;
using System;

namespace OrderNowAndroid
{
	[Activity ( MainLauncher = true, Theme="@style/SplashTheme",ScreenOrientation = ScreenOrientation.Portrait)]
	public class MainActivity : Activity
	{
		private FragmentTransaction mTransaction;
		private Fragment mFmgMenuSections;
		private Fragment mMenuSection;
		private Fragment mSignInSection;
		private Fragment mSignUpUser;
		private Fragment mSignUpCredit;
		private Fragment mProfileSection;
		private RecyclerView mRecyclerViewOrder;
		private RecyclerView.Adapter mOrderSection;
		private int mLayoutMenu;
		private int mLayoutSignIn;
		private int mLayoutProfile;
		private View mCurrentView;
		private bool signedIn;


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			this.SetTheme (Resource.Style.CustomActionBarTheme);
				
			//Don't display any default stuff 
			//ActionBar.SetDisplayShowHomeEnabled (false);
			//ActionBar.SetDisplayShowTitleEnabled (false);

			//Our custom action bar
			ActionBar.SetCustomView(Resource.Layout.action_bar);
			ActionBar.SetDisplayShowCustomEnabled (true);
			ActionBar.Hide ();

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			//Store layouts id (for fragment transaction)
			mLayoutMenu = Resource.Id.layoutMenu;
			mLayoutSignIn = Resource.Id.layoutSignIn;
			mLayoutProfile = Resource.Id.layoutProfileSection;

			//Give activity resource for Item data for retrieving hard-coded items
			ItemsData.Resources = this.Resources;

			// Launch sign in Fragment
			mTransaction = FragmentManager.BeginTransaction ();
			mSignInSection = new SignInFragment ();
			mTransaction.Add (mLayoutSignIn, mSignInSection);
			mTransaction.Commit ();

			// menu sections Fragment 
			mTransaction = this.FragmentManager.BeginTransaction ();
			mFmgMenuSections = new MenuSectionsFragment ();
			mTransaction.Add (mLayoutMenu, mFmgMenuSections);
			mTransaction.Commit ();

			// Order section Fragment 
			mOrderSection = OrderSection.GetInstance ();
			mRecyclerViewOrder = FindViewById<RecyclerView> (Resource.Id.recyclerViewOrderSection);
			mRecyclerViewOrder.SetLayoutManager(new LinearLayoutManager(this));
			mRecyclerViewOrder.SetAdapter (mOrderSection);

			// Profile section Fragment
			mTransaction = this.FragmentManager.BeginTransaction ();
			mProfileSection = new ProfileSectionFragment ();
			mTransaction.Add (mLayoutProfile, mProfileSection);
			mTransaction.Commit ();

		}
		protected override void OnStart ()
		{
			base.OnStart ();

			//Handle click events
			configureActionBarController ();
			configureMenuSectionsController ();
			configureSignInSectionController ();
			//configureProfileSectionController ();

		}
		public override void OnBackPressed()
		{
			if(signedIn)
			if (mCurrentView.Id != mLayoutMenu) {
				FindViewById<ImageButton> (Resource.Id.tabMenu).RequestFocus ();
				return;
			}

			base.OnBackPressed ();

		}

		public override void OnLowMemory() 
		{
			GC.Collect ();
		}

		private void configureActionBarController()
		{
			// Menu tab
			ImageButton menuTab = FindViewById<ImageButton> (Resource.Id.tabMenu);
			TextView menuTxt = FindViewById<TextView> (Resource.Id.txtMenu);
			menuTab.FocusChange += delegate {
				if(menuTab.HasFocus)
				{
					NavigateToTabMenu();
					menuTxt.SetTextColor(Resources.GetColor(Resource.Color.tab_selected));
				}
				else
				{
					menuTxt.SetTextColor(Resources.GetColor(Resource.Color.tab_not_selected));
				}
			};
			menuTxt.Click += delegate {
				if(!menuTab.HasFocus)
					menuTab.RequestFocus();
			};

			// Events tab
			ImageButton eventsTab = FindViewById<ImageButton> (Resource.Id.tabEvents);
			TextView eventsTxt = FindViewById<TextView> (Resource.Id.txtEvents);
			eventsTab.FocusChange += delegate {
				if(eventsTab.HasFocus)
				{
					//NavigateToTabEvents();
					eventsTxt.SetTextColor(Resources.GetColor(Resource.Color.tab_selected));
				}
				else
				{
					eventsTxt.SetTextColor(Resources.GetColor(Resource.Color.tab_not_selected));
				}
			};
			eventsTxt.Click += delegate {
				if(!eventsTab.HasFocus)
					eventsTab.RequestFocus();
			};

			// Order tab
			ImageButton orderTab = FindViewById<ImageButton> (Resource.Id.tabOrder);
			TextView orderTxt = FindViewById<TextView> (Resource.Id.txtOrder);
			orderTab.FocusChange += delegate {
				if(orderTab.HasFocus)
				{
					NavigateToTabOrder();
					orderTxt.SetTextColor(Resources.GetColor(Resource.Color.tab_selected));
				}
				else
				{
					orderTxt.SetTextColor(Resources.GetColor(Resource.Color.tab_not_selected));
				}
			};

			orderTxt.Click += delegate {
				if(!orderTab.HasFocus)
					orderTab.RequestFocus();
			};

			// Profile tab
			ImageButton profileTab = FindViewById<ImageButton> (Resource.Id.tabProfile);
			TextView profileTxt = FindViewById<TextView> (Resource.Id.txtProfile);
			profileTab.FocusChange += delegate {

				if(profileTab.HasFocus)
				{
					NavigateToTabProfile();
					profileTxt.SetTextColor(Resources.GetColor(Resource.Color.tab_selected));
				}
				else
				{
					profileTxt.SetTextColor(Resources.GetColor(Resource.Color.tab_not_selected));
				}
			};
			profileTxt.Click += delegate {
				if(!profileTab.HasFocus)
					profileTab.RequestFocus();
			};

			// Infos tab
			ImageButton infosTab = FindViewById<ImageButton> (Resource.Id.tabInfos);
			TextView infosTxt = FindViewById<TextView> (Resource.Id.txtInfos);
			infosTab.FocusChange += delegate {
				if(infosTab.HasFocus)
				{
					//NavigateToTabInfos();
					infosTxt.SetTextColor(Resources.GetColor(Resource.Color.tab_selected));
				}
				else
				{
					infosTxt.SetTextColor(Resources.GetColor(Resource.Color.tab_not_selected));
				}
			};
			infosTxt.Click += delegate {
				if(!infosTab.HasFocus)
					infosTab.RequestFocus();
			};
		}
	
		private void configureMenuSectionsController()
		{
			Button btnSectionDinner = mFmgMenuSections.View.FindViewById<Button> (Resource.Id.btnSectionDinner);
			btnSectionDinner.Click += delegate {
			
				mMenuSection = new MenuSectionFragment(this, ItemsData.DinnerItems);
				FragmentTransaction tx = this.FragmentManager.BeginTransaction ();
				//tx.SetCustomAnimations(Resource.Animation.slide_in, Resource.Animation.slide_out);
				tx.Add(mLayoutMenu, mMenuSection,null);
				tx.AddToBackStack(null);
				tx.Commit();

			};		

			Button btnSectionDrinks = mFmgMenuSections.View.FindViewById<Button> (Resource.Id.btnSectionDrinks);
			btnSectionDrinks.Click += delegate {

				mMenuSection = new MenuSectionFragment(this, ItemsData.DrinksItems);
				FragmentTransaction tx = this.FragmentManager.BeginTransaction ();
				//tx.SetCustomAnimations(Resource.Animation.slide_left, Resource.Animation.slide_right_exit);
				tx.Add(mLayoutMenu, mMenuSection,null);
				tx.AddToBackStack(null);
				tx.Commit();

			};		


		}

		private void startApp ()
		{
			ActionBar.Show ();
			//ActionBar.CustomView = ViewStates.Visible;
			NavigateToTabMenu ();
			signedIn = true;
		}

		private void configureSignInSectionController()
		{
			Button btnSignIn = mSignInSection.View.FindViewById<Button> (Resource.Id.btnSignIn);

			btnSignIn.Click += delegate {
				startApp ();
			};

			TextView txtSignUp = mSignInSection.View.FindViewById<TextView> (Resource.Id.txtSignUp);

			txtSignUp.Click += delegate {
				mSignUpUser = new SignUpUserFragment();
				FragmentTransaction tx = this.FragmentManager.BeginTransaction ();
				tx.Add(mLayoutSignIn, mSignUpUser,null);
				tx.AddToBackStack(null);
				tx.Commit();

				FragmentManager.ExecutePendingTransactions();
				configureSignUpUserController();

			};
		}

		private void configureSignUpUserController()
		{
			Button btnNext = mSignUpUser.View.FindViewById<Button> (Resource.Id.btnNextSignUp);

			btnNext.Click += delegate {
				mSignUpCredit = new SignUpCreditFragment();
				FragmentTransaction tx = this.FragmentManager.BeginTransaction ();
				tx.Add(mLayoutSignIn, mSignUpCredit,null);
				tx.AddToBackStack(null);
				tx.Commit();

				FragmentManager.ExecutePendingTransactions();
				configureSignUpCreditController();

			};

		}

		private void configureSignUpCreditController()
		{
			Button btnSignUp = mSignUpCredit.View.FindViewById<Button> (Resource.Id.btnSignUp);

			btnSignUp.Click += delegate {
				//OnBackPressed();
				//OnBackPressed();
				/*while(mCurrentView != mSignInSection.View.Id)
				{
					OnBackPressed();
					mCurrentView = FindViewById<FrameLayout>(Resource.Id.layoutSignIn).view
				}*/
				startApp ();
			};

		}



		public void NavigateToTabMenu()
		{

			ViewFlipper flippy = FindViewById<ViewFlipper> (Resource.Id.viewFlipper);
			while(flippy.CurrentView.Id != mLayoutMenu)
				flippy.ShowNext ();
			mCurrentView = flippy.CurrentView;
		}

		public void NavigateToTabOrder()
		{	
		
			ViewFlipper flippy = FindViewById<ViewFlipper> (Resource.Id.viewFlipper);
			while(flippy.CurrentView.Id != FindViewById<LinearLayout>(Resource.Id.layoutOrderSection).Id)
				flippy.ShowNext ();
			mCurrentView = flippy.CurrentView;

		}

		public void NavigateToTabProfile()
		{
			ViewFlipper flippy = FindViewById<ViewFlipper> (Resource.Id.viewFlipper);
			while(flippy.CurrentView.Id != FindViewById<FrameLayout>(Resource.Id.layoutProfileSection).Id)
				flippy.ShowNext ();
			mCurrentView = flippy.CurrentView;
		}
	}
		
}



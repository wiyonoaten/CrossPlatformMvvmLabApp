using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using CoreLib;
using SharedPresentationLib;
using GalaSoft.MvvmLight.Helpers;
using PresentationLib;
using UIComponentsLib.Views;
using UIComponentsLib.Constants;

namespace PresentationLib.Views
{
	[Activity(Label = "Main", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : BaseActivity
	{
		protected override object CreateViewModel()
		{
			return new MainViewModel();
		}

		protected override int GetLayoutResourceId()
		{
			return Resource.Layout.Main;
		}

#if _USE_MVVMLIGHT_BINDING
		private MainViewModel _ViewModel;
		private MainViewModel ViewModel
		{
			get 
			{
				return _ViewModel ?? (_ViewModel = new MainViewModel());
			}
		}

		private Button _GoButton;
		private Button GoButton
		{
			get
			{
				return _GoButton ?? (_GoButton = FindViewById<Button>(Resource.Id.myButton));
			}
		}

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Set up view model
			//this.ViewModel.AddBinding(() => this.ViewModel.Title, () => this.GoButton.Text);
			//this.ViewModel.AddBinding<string>("Title", this.GoButton, "Text");
			this.ViewModel.AddBinding<string>(
				ReflectionUtils.GetPropertyName(() => this.ViewModel.Title), 
				this.GoButton, 
				ReflectionUtils.GetPropertyName(() => this.GoButton.Text));
			this.GoButton.AddCommand(ButtonEvents.Click, this.ViewModel.GoCommand);
		}
#endif
	}
}

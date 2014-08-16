using System;
using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Android.Views;

namespace UIComponentsLib.Views
{
	public abstract class BaseActivity : Activity
	{
		private MvxAndroidBindingContext m_bindingContext;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			m_bindingContext = new MvxAndroidBindingContext(
				this, 
				new LayoutInflaterProvider(LayoutInflater), 
				CreateViewModel());

			var view = m_bindingContext.BindingInflate(GetLayoutResourceId(), null);
			SetContentView(view);
		}

		protected override void OnDestroy()
		{
			m_bindingContext.ClearAllBindings();
			base.OnDestroy();
		}

		protected abstract object CreateViewModel();
		protected abstract int GetLayoutResourceId();
	}

	public class LayoutInflaterProvider : IMvxLayoutInflater
	{
		public LayoutInflaterProvider(LayoutInflater layoutInflater)
		{
			LayoutInflater = layoutInflater;
		}

		public LayoutInflater LayoutInflater { get; private set; }
	}
}

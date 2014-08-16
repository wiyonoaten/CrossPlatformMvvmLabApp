using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace UIComponentsLib.Views
{
	public abstract class BaseUIViewController : UIViewController, IMvxBindable
	{
		protected BaseUIViewController(IntPtr handle)
			: base(handle)
		{
			this.CreateBindingContext();
		}

		protected BaseUIViewController(string nibName, NSBundle bundle)
			: base(nibName, bundle)
		{
			this.CreateBindingContext();
		}

		#region Implementation of IMvxBindable

		public IMvxBindingContext BindingContext { get; set; }

		public object DataContext
		{
			get { return BindingContext.DataContext; }
			set { BindingContext.DataContext = value; }
		}

		#endregion

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				BindingContext.ClearAllBindings();
			}

			base.Dispose(disposing);
		}
	}
}

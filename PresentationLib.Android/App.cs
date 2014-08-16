using System;
using System.Reflection;
using Android.App;
using Android.Content;
using Android.Runtime;
using Cirrious.CrossCore.Droid;
using UIComponentsLib;

namespace PresentationLib
{
#if DEBUG
	[Application(Debuggable=true)]
#else
	[Application(Debuggable=false)]
#endif
	public class App : Application
	{
		public App(IntPtr handle, JniHandleOwnership ownerShip) 
			: base(handle, ownerShip)
		{
		}

		public override void OnCreate()
		{
			base.OnCreate();

			MvxSetup.Instance.EnsureInit(new AndroidGlobals(this));
		}
	}

	public class AndroidGlobals : IMvxAndroidGlobals
	{
		private readonly Context _applicationContext;

		public AndroidGlobals(Context applicationContext)
		{
			_applicationContext = applicationContext;
		}

		public virtual string ExecutableNamespace
		{
			get { return GetType().Namespace; }
		}

		public virtual Assembly ExecutableAssembly
		{
			get { return GetType().Assembly; }
		}

		public Context ApplicationContext
		{
			get { return _applicationContext; }
		}
	}
}

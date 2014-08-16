using System;
using System.Reflection;
using Android.Content;
using Android.Views;
using Android.Util;
using Cirrious.CrossCore.IoC;
using Cirrious.CrossCore.Platform;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Droid;
using Cirrious.MvvmCross.Binding.Droid;
using Cirrious.MvvmCross.Binding.Droid.Binders.ViewTypeResolvers;

namespace UIComponentsLib
{
	// Reference: https://github.com/MvvmCross/MvvmCross-Tutorials/tree/master/CrossLight
	public class MvxSetup
	{
		public static readonly MvxSetup Instance = new MvxSetup();

		public void EnsureInit(IMvxAndroidGlobals androidGlobals)
		{
			if (MvxSimpleIoCContainer.Instance != null)
			{
				return;
			}

			MvxSimpleIoCContainer.Initialize();

			Mvx.RegisterSingleton<IMvxTrace>(new MvxDebugTrace());
			MvxTrace.Initialize();

			Mvx.RegisterSingleton<IMvxAndroidGlobals>(androidGlobals);

			new MvxAndroidBindingBuilder().DoRegistration();

			var viewCache = Mvx.Resolve<IMvxTypeCache<View>>();
			viewCache.AddAssembly(typeof(View).Assembly);

			var namespaces = Mvx.Resolve<IMvxNamespaceListViewTypeResolver>();
			namespaces.Add("Android.Views");
			namespaces.Add("Android.Widget");
			namespaces.Add("Android.Webkit");
		}
	}

	public class MvxDebugTrace : IMvxTrace
	{
		public void Trace(MvxTraceLevel level, string tag, Func<string> message)
		{
			WriteToLog(level, tag, message());
		}

		public void Trace(MvxTraceLevel level, string tag, string message)
		{
			WriteToLog(level, tag, message);
		}

		public void Trace(MvxTraceLevel level, string tag, string message, params object[] args)
		{
			try
			{
				WriteToLog(level, tag, string.Format(message, args));
			}
			catch (FormatException)
			{
				Trace(MvxTraceLevel.Error, tag, "Exception during trace of {0} {1} {2}", level, message);
			}
		}

		private void WriteToLog(MvxTraceLevel level, string tag, string message)
		{
			if (level == MvxTraceLevel.Diagnostic)
			{
				Log.Debug(tag, message);
			}
			else if (level == MvxTraceLevel.Warning)
			{
				Log.Warn(tag, message);
			}
			else
			{
				Log.Error(tag, message);
			}
		}
	}
}

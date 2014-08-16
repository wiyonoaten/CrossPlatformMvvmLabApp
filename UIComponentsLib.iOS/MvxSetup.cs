using System;
using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.Binding.Touch;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using System.Diagnostics;

namespace UIComponentsLib
{
	// Reference: http://slodge.blogspot.co.uk/2013/09/n39-crosslight-on-xamariniosmonotouch.html
	public class MvxSetup
	{
		public static readonly MvxSetup Instance = new MvxSetup();

		public void EnsureInit()
		{
			if (MvxSimpleIoCContainer.Instance != null)
			{
				return;
			}

			MvxSimpleIoCContainer.Initialize();

			Mvx.RegisterSingleton<IMvxTrace>(new MvxDebugTrace());
			MvxTrace.Initialize();

			new MvxTouchBindingBuilder().DoRegistration();
		}
	}

	public class MvxDebugTrace : IMvxTrace
	{
		public void Trace(MvxTraceLevel level, string tag, Func<string> message)
		{
			WriteLine(level, tag + ":" + level + ":" + message());
		}

		public void Trace(MvxTraceLevel level, string tag, string message)
		{
			WriteLine(level, tag + ":" + level + ":" + message);
		}

		public void Trace(MvxTraceLevel level, string tag, string message, params object[] args)
		{
			try
			{
				WriteLine(level, string.Format(tag + ":" + level + ":" + message, args));
			}
			catch (FormatException)
			{
				Trace(MvxTraceLevel.Error, tag, "Exception during trace of {0} {1} {2}", level, message);
			}
		}

		private void WriteLine(MvxTraceLevel level, string message)
		{
			if (level == MvxTraceLevel.Diagnostic)
			{
				Debug.WriteLine(message);
			}
			else
			{
				Console.WriteLine(message);
			}
		}
	}
}

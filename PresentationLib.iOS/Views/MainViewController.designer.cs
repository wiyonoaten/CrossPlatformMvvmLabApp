// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace PresentationLib.Views
{
	[Register ("MainViewController")]
	partial class MainViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton MyButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton NextButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (MyButton != null) {
				MyButton.Dispose ();
				MyButton = null;
			}
			if (NextButton != null) {
				NextButton.Dispose ();
				NextButton = null;
			}
		}
	}
}

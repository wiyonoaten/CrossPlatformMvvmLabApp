using System;
using Xamarin.Forms;
using SharedPresentationLib;

namespace PresentationLib
{
	public class App
	{
		public static Page GetMainPage()
		{	
			return new MainPage()
			{ 
				BindingContext = new MainViewModel(),
			};
		}
	}
}

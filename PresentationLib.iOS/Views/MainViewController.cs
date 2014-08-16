using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using UIComponentsLib.Views;
using SharedPresentationLib;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace PresentationLib.Views
{
	partial class MainViewController : BaseUIViewController
	{
		public MainViewController (IntPtr handle) : base (handle)
		{
			DataContext = new MainViewModel();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Set up view model
			//this.CreateBinding(this.MyButton).To((MainViewModel vm) => vm.GoCommand).Apply(); 
			var bindingSet = this.CreateBindingSet<MainViewController, MainViewModel>();
			bindingSet.Bind(this.MyButton).To(vm => vm.GoCommand);
			//bindingSet.Bind(this.MyButton.TitleLabel).For(lbl => lbl.Text).To(vm => vm.Title);
			bindingSet.Bind(this.MyButton).For("Title").To(vm => vm.Title); // using "custom binding" technique
			bindingSet.Apply();
		}
	}
}

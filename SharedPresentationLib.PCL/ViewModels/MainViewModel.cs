using System;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace SharedPresentationLib
{
	public class MainViewModel : ViewModelBase
	{
		private int m_count = 0;

		#region Constructors

		public MainViewModel()
		{
			updateTitle();
		}

		#endregion

		#region Title

		public const string TitlePropertyName = "Title";

		private string _Title = string.Empty;
		public string Title
		{
			get
			{
				return _Title;
			}

			set
			{
				Set(() => this.Title, ref _Title, value);
			}
		}

		#endregion

		#region GoCommand

		private RelayCommand _GoCommand;
		public RelayCommand GoCommand 
		{ 
			get
			{
				return _GoCommand ?? (_GoCommand = new RelayCommand(() => ExecuteGo(), () => CanExecuteGo()));
			}
		}

		#endregion

		#region Command Handlers

		private void ExecuteGo()
		{
			if (++m_count == 10)
			{
				this.GoCommand.RaiseCanExecuteChanged();
			}
			updateTitle();
		}

		private bool CanExecuteGo()
		{
			return (m_count < 10);
		}

		#endregion

		#region Helpers

		private void updateTitle()
		{
			Title = string.Format("{0} clicks!", m_count);
		}

		#endregion
	}
}


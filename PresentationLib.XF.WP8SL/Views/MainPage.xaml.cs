using Microsoft.Phone.Controls;
using Xamarin.Forms;

namespace PresentationLib.Views
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();

            this.ContentPanel.Children.Add(App.GetMainPage().ConvertPageToUIElement(this));
        }
    }
}

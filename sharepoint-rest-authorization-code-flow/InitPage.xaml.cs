using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Karamem0.Samples
{

    public sealed partial class InitPage : Page
    {

        public InitPage()
        {
            this.InitializeComponent();
        }

        private void OnAuthTextBoxClick(object sender, RoutedEventArgs e)
        {
            var rootFrame = Window.Current.Content as Frame;
            if (rootFrame != null)
            {
                rootFrame.Navigate(typeof(AuthPage), this.SiteUrlTextBox.Text);
            }
        }

    }

}

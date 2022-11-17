//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Karamem0.SampleApplication
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

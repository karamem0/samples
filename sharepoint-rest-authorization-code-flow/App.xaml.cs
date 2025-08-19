//
// Copyright (c) 2011-2024 karamem0
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
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Karamem0.SampleApplication
{

    public sealed partial class App : Application
    {

        public App()
        {
            this.InitializeComponent();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            var rootFrame = new Frame();
            rootFrame.Navigate(typeof(InitPage), e.Arguments);
            Window.Current.Content = rootFrame;
            Window.Current.Activate();
        }

    }

}

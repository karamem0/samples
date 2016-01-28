using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Karamem0.Samples
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            this.InitializeComponent();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            var handle = new WindowInteropHelper(this).Handle;
            if (handle != IntPtr.Zero)
            {
                var style = Win32.GetWindowLong(handle, (int)Win32.GetWindowLongIndex.GWL_STYLE);
                style |= (int)Win32.WindowStyles.WS_CAPTION;
                Win32.SetWindowLong(handle, (int)Win32.GetWindowLongIndex.GWL_STYLE, style);
                HwndSource.FromHwnd(handle).AddHook(this.WindowProc);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            var handle = new WindowInteropHelper(this).Handle;
            if (handle != IntPtr.Zero)
            {
                HwndSource.FromHwnd(handle).RemoveHook(this.WindowProc);
            }
            base.OnClosing(e);
        }

        private IntPtr WindowProc(IntPtr handle, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == (int)Win32.WindowMessages.WM_NCHITTEST)
            {
                var result = this.OnNcHitTest(handle, wParam, lParam);
                if (result != null)
                {
                    handled = true;
                    return result.Value;
                }
            }
            if (msg == (int)Win32.WindowMessages.WM_SIZE)
            {
                if ((Win32.ResizeMode)wParam == Win32.ResizeMode.SIZE_MAXIMIZED)
                {
                    this.LayoutRoot.Margin = new Thickness(8);
                }
                else
                {
                    this.LayoutRoot.Margin = new Thickness(0);
                }
            }
            return IntPtr.Zero;
        }

        private IntPtr? OnNcHitTest(IntPtr handle, IntPtr wParam, IntPtr lParam)
        {
            var screenPoint = new Point((int)lParam & 0xFFFF, ((int)lParam >> 16) & 0xFFFF);
            var clientPoint = this.PointFromScreen(screenPoint);
            var borderHitTest = this.GetBorderHitTest(clientPoint);
            if (borderHitTest != null)
            {
                return (IntPtr)borderHitTest;
            }
            var chromeHitTest = this.GetChromeHitTest(clientPoint);
            if (chromeHitTest != null)
            {
                return (IntPtr)chromeHitTest;
            }
            return null;
        }

        private Win32.HitTestResult? GetBorderHitTest(Point point)
        {
            if (this.WindowState != WindowState.Normal)
            {
                return null;
            }
            var top = (point.Y <= 5);
            var bottom = (point.Y >= this.Height - 5);
            var left = (point.X <= 5);
            var right = (point.X >= this.Width - 5);
            if (top == true)
            {
                if (left == true)
                {
                    return Win32.HitTestResult.HTTOPLEFT;
                }
                if (right == true)
                {
                    return Win32.HitTestResult.HTTOPRIGHT;
                }
                return Win32.HitTestResult.HTTOP;
            }
            if (bottom == true)
            {
                if (left == true)
                {
                    return Win32.HitTestResult.HTBOTTOMLEFT;
                }
                if (right == true)
                {
                    return Win32.HitTestResult.HTBOTTOMRIGHT;
                }
                return Win32.HitTestResult.HTBOTTOM;
            }
            if (left == true)
            {
                return Win32.HitTestResult.HTLEFT;
            }
            if (right == true)
            {
                return Win32.HitTestResult.HTRIGHT;
            }
            return null;
        }

        private Win32.HitTestResult? GetChromeHitTest(Point point)
        {
            var result = VisualTreeHelper.HitTest(this.Chrome, point);
            if (result != null)
            {
                var button = result.VisualHit.FindVisualAncestor<Button>();
                if (button == null)
                {
                    return Win32.HitTestResult.HTCAPTION;
                }
            }
            return null;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }

        private void RestoreButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Normal;
        }

    }

}

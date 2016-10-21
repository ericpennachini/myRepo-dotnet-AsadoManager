using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AsadoManager.UWPApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ResultPage : Page
    {
        public ResultPage()
        {
            this.InitializeComponent();
            if (Application.Current.RequestedTheme.Equals(ApplicationTheme.Light))
            {
                stackPanel.Background = new SolidColorBrush(Windows.UI.Colors.LightGray);
            }
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<User> list = (List<User>) e.Parameter;
            List<User> result = new List<User>();
            result = Calculator.Calculate2(list);
            foreach (var user in result)
            {
                TextBlock t = new TextBlock();
                t.Text = user.Name + " tiene que " + (user.Quantity < 0 ? "recibir $" + (-user.Quantity) : "aportar $" + user.Quantity);
                stackPanel.Children.Add(t);
            }
        }
    }
}

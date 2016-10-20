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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AsadoManager.UWPApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            if (Application.Current.RequestedTheme.Equals(ApplicationTheme.Light))
            {
                listView.Background = new SolidColorBrush(Windows.UI.Colors.LightGray);
            }
        }

        private void buttonAddUserToList_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text == "" || textBoxQuantity.Text == "")
            {
                msgFlyoutAddUser.Text = "Campos vacíos!";
                alertAddUser.ShowAt((FrameworkElement)sender);
                textBoxName.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                textBoxName.Background = new SolidColorBrush(Windows.UI.Colors.DarkRed);
                textBoxQuantity.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                textBoxQuantity.Background = new SolidColorBrush(Windows.UI.Colors.DarkRed);
            }
            else
            {
                int res = 0;
                Int32.TryParse(textBoxQuantity.Text, out res);
                if (res != 0)
                {
                    msgFlyoutAddUser.Text = "OK!";
                    listView.Items.Add($"{textBoxName.Text}   ${textBoxQuantity.Text}");
                    // Agregar elementos a una lista (ver si hace falta)
                    textBoxName.Text = "";
                    textBoxQuantity.Text = ""; 
                }
                else
                {
                    msgFlyoutAddUser.Text = "El monto debe ser un número!";
                    textBoxQuantity.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                    textBoxQuantity.Background = new SolidColorBrush(Windows.UI.Colors.DarkRed);
                    //ContentDialog errorDialog = new ContentDialog
                    //{
                    //    Title = "Error",
                    //    Content = "El monto debe ser un número!",
                    //    PrimaryButtonText = "Reintentar"
                    //};
                    //errorDialog.ShowAsync();
                }
            }
        }

        private void ResetElementsColors()
        {
            textBoxName.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Gray);
            textBoxName.Background = new SolidColorBrush();
            textBoxQuantity.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Gray);
            textBoxQuantity.Background = new SolidColorBrush();
        }

        private void textBoxName_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            ResetElementsColors();
        }

        private void textBoxQuantity_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            ResetElementsColors();
        }

    }
}

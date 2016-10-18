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
            
            if (this.RequestedTheme.Equals(ElementTheme.Dark) && base.RequestedTheme.Equals(ElementTheme.Dark)) 
            {
                // setear el fondo en gris oscuro
            }
            if (this.RequestedTheme.Equals(ElementTheme.Light) && base.RequestedTheme.Equals(ElementTheme.Light))
            {
                // setear el fondo en gris claso
            }
        }

        private void buttonAddUserToList_Click(object sender, RoutedEventArgs e)
        {
            listView.Items.Add($"{textBoxName.Text} -> ${textBoxQuantity.Text}");
            textBoxName.Text = "";
            textBoxQuantity.Text = "";
        }
    }
}

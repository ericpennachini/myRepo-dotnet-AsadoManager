﻿using System;
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
        private List<User> _users;

        public MainPage()
        {
            _users = new List<User>();
            this.InitializeComponent();
            if (Application.Current.RequestedTheme.Equals(ApplicationTheme.Light))
            {
                listView.Background = new SolidColorBrush(Windows.UI.Colors.LightGray);
                //textBoxName.BorderBrush = new SolidColorBrush(Windows.UI.Colors.DarkRed);
                //textBoxName.Background = new SolidColorBrush(Windows.UI.Colors.Red);
                //textBoxQuantity.BorderBrush = new SolidColorBrush(Windows.UI.Colors.DarkRed);
                //textBoxQuantity.Background = new SolidColorBrush(Windows.UI.Colors.Red);
            }
        }

        private void buttonAddUserToList_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text == "" || textBoxQuantity.Text == "")
            {
                msgFlyoutAddUser.Text = "Campos vacíos";
                alertAddUser.ShowAt((FrameworkElement)sender);
                textBoxName.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                textBoxName.Background = new SolidColorBrush(Windows.UI.Colors.DarkRed);
                textBoxName.PlaceholderText = "";
                textBoxQuantity.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                textBoxQuantity.Background = new SolidColorBrush(Windows.UI.Colors.DarkRed);
                textBoxQuantity.PlaceholderText = "";
            }
            else
            {
                decimal res = 0;
                decimal.TryParse(textBoxQuantity.Text, out res);
                if (res >= 0)
                {
                    listView.Visibility = Visibility.Visible;
                    msgFlyoutAddUser.Text = "OK";
                    listView.Items.Add($"{textBoxName.Text}   ${res.ToString()}");
                    _users.Add(new User
                    {
                        Name = textBoxName.Text,
                        Quantity = res
                    });
                    textBoxName.Text = "";
                    textBoxQuantity.Text = ""; 
                }
                else
                {
                    msgFlyoutAddUser.Text = "El monto debe ser un número";
                    textBoxQuantity.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                    textBoxQuantity.Background = new SolidColorBrush(Windows.UI.Colors.DarkRed);
                }
            }
            textBoxName.Focus(FocusState.Keyboard);
        }

        private void ResetElementsColors()
        {
            textBoxName.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Gray);
            textBoxName.Background = new SolidColorBrush();
            textBoxName.PlaceholderText = "Nombre...";
            textBoxQuantity.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Gray);
            textBoxQuantity.Background = new SolidColorBrush();
            textBoxQuantity.PlaceholderText = "Monto...";
        }

        private void textBoxName_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            ResetElementsColors();
        }

        private void textBoxQuantity_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            ResetElementsColors();
        }

        private void appBarButtonClearList_Click(object sender, RoutedEventArgs e)
        {
            listView.Items.Clear();
            _users.Clear();
            textBoxName.Focus(FocusState.Pointer);
        }

        private void appButtonAbout_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog aboutDialog = new ContentDialog()
            {
                Title = "Acerca de esta aplicación",
                Content = "AsadoManager. Proyecto personal ;-)",
                PrimaryButtonText = "OK"
            };
            aboutDialog.ShowAsync();
        }

        private void appBarButtonCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (listView.Items.Count == 0 || _users.Count == 0)
            {
                //ContentDialog errorDialog = new ContentDialog()
                //{
                //    Title = "Error",
                //    Content = "Lista vacía",
                //    PrimaryButtonText = "Reintentar"
                //};
                //await errorDialog.ShowAsync();
                //appBar
                msgFlyoutCalculate.Text = "Lista vacía";
                //flyoutButtonCalculate.Placement = FlyoutPlacementMode.Top;
            }
            else
            {
                this.Frame.Navigate(typeof(ResultPage), _users);
            }
        }
    }
}

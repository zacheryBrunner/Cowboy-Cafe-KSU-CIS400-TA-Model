/*
 * Author: Zachery Brunner
 * Class: PecosPulledPork.xaml.cs
 * Purpose: Allows customization options for the pecos pulled pork entree
 */
using System;

using System.Windows;
using System.Windows.Controls;

using CowboyCafe.Data;
using CowboyCafe.Data.Entrees;

namespace PointOfSale.CustomizationScreens
{
    /// <summary>
    /// Interaction logic for PecosPulledPorkCustomization.xaml
    /// </summary>
    public partial class PecosPulledPorkCustomization : UserControl
    {
        
        /// <summary>
        /// This variable is used so I can notify the properties have changed
        /// </summary>
        private Order linkToOrder;

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="dc">Datacontext: This is the overall order so I can trigger the special properties for the order</param>
        public PecosPulledPorkCustomization(object dc)
        {
            linkToOrder = (Order)dc;
            InitializeComponent();
        }

        /// <summary>
        /// Filters which control was pressed and changes the holding state of the respective item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PecosPulledPork ppp = (PecosPulledPork)DataContext;
            switch (((Button)sender).Name)
            {
                case "PickleButton":
                    if (ppp.Pickle)
                        PickleInformation.Text = "Holding Pickle";
                    else
                        PickleInformation.Text = "Not Holding Pickle";
                    ppp.Pickle = !ppp.Pickle;
                    break;
                case "BreadButton":
                    if (ppp.Bread)
                        BreadInformation.Text = "Holding Bread";
                    else
                        BreadInformation.Text = "Not Holding Bread";
                    ppp.Bread = !ppp.Bread;
                    break;
                default:
                    throw new NotImplementedException("Unknown Angry Chicken Toggle Button Pressed");
            }
            linkToOrder.InvokePropertyChanged();
        }
    }
}
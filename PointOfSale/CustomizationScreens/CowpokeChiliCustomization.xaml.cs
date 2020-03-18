/*
* Author: Zachery Brunner
* Class: CowpokeChiliCustomization.xaml.cs
* Purpose: Customization screen for the cowpokechili
*/
using System;
using System.Windows;
using System.Windows.Controls;
using CowboyCafe.Data;
using CowboyCafe.Data.Entrees;

namespace PointOfSale.CustomizationScreens
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class CowpokeChiliCustomization : UserControl
    {
        /// <summary>
        /// This variable is used so I can notify the properties have changed
        /// </summary>
        private Order linkToOrder;

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="dc">Datacontext: This is the overall order so I can trigger the special properties for the order</param>
        public CowpokeChiliCustomization(object dc)
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
            CowpokeChili cc = (CowpokeChili)DataContext;
            switch(((Button)sender).Name)
            {
                case "CheeseButton":
                    if (cc.Cheese)
                        CheeseInformation.Text = "Holding Cheese";
                    else
                        CheeseInformation.Text = "Not Holding Cheese";
                    cc.Cheese = !cc.Cheese;
                    break;
                case "SourCreamButton":
                    if (cc.SourCream)
                        SourCreamInformation.Text = "Holding Sour Cream";
                    else
                        SourCreamInformation.Text = "Not Holding\nSour Cream";
                    cc.SourCream = !cc.SourCream;
                    break;
                case "GreenOnionsButton":
                    if (cc.GreenOnions)
                        GreenOnionsInformation.Text = "Holding Green Onions";
                    else
                        GreenOnionsInformation.Text = "Not Holding\nGreen Onions";
                    cc.GreenOnions = !cc.GreenOnions;
                    break;
                case "TortillaStripsButton":
                    if (cc.TortillaStrips)
                        TortillaStripsInformation.Text = "Holding Tortilla Strips";
                    else
                        TortillaStripsInformation.Text = "Not Holding\nTortilla Strips";
                    cc.TortillaStrips = !cc.TortillaStrips;
                    break;
                default:
                    throw new NotImplementedException("Unknown Cowpoke Chili Toggle Button Pressed");
            }
            linkToOrder.InvokePropertyChanged();
        }
    }
}
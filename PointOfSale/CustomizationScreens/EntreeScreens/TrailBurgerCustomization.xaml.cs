/*
 * Author: Zachery Brunner
 * Class: TrailBurgerCustomization.xaml.cs
 * Purpose: Allows customization for the dakota double burger
 */
using System;

using System.Windows;
using System.Windows.Controls;

using CowboyCafe.Data;
using CowboyCafe.Data.Entrees;

namespace PointOfSale.CustomizationScreens
{
    /// <summary>
    /// Interaction logic for TrailBurgerCustomization.xaml
    /// </summary>
    public partial class TrailBurgerCustomization : UserControl
    {
        /// <summary>
        /// This variable is used so I can notify the properties have changed
        /// </summary>
        private Order linkToOrder;

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="dc">Datacontext: This is the overall order so I can trigger the special properties for the order</param>
        public TrailBurgerCustomization(object dc)
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
            TrailBurger tb = (TrailBurger)DataContext;
            switch (((Button)sender).Name)
            {
                case "BunButton":
                    if (tb.Bun)
                        BunInformation.Text = "Holding Bun";
                    else
                        BunInformation.Text = "Not Holding Bun";
                    tb.Bun = !tb.Bun;
                    break;
                case "KetchupButton":
                    if (tb.Ketchup)
                        KetchupInformation.Text = "Holding Ketchup";
                    else
                        KetchupInformation.Text = "Not Holding Ketchup";
                    tb.Ketchup = !tb.Ketchup;
                    break;
                case "MustardButton":
                    if (tb.Mustard)
                        MustardInformation.Text = "Holding Mustard";
                    else
                        MustardInformation.Text = "Not Holding Mustard";
                    tb.Mustard = !tb.Mustard;
                    break;
                case "CheeseButton":
                    if (tb.Cheese)
                        CheeseInformation.Text = "Holding Cheese";
                    else
                        CheeseInformation.Text = "Not Holding Cheese";
                    tb.Cheese = !tb.Cheese;
                    break;
                case "PickleButton":
                    if (tb.Pickle)
                        PickleInformation.Text = "Holding Tomato";
                    else
                        PickleInformation.Text = "Not Holding Tomato";
                    tb.Pickle = !tb.Pickle;
                    break;
                default:
                    throw new NotImplementedException("Unknown Dakota Double Toggle Button Pressed");
            }
            linkToOrder.InvokePropertyChanged();
        }
    }
}
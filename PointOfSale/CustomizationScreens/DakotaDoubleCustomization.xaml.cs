/*
 * Author: Zachery Brunner
 * Class: DakotaDoubleCustomization.xaml.cs
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
    /// Interaction logic for DakotaDoubleCustomization.xaml
    /// </summary>
    public partial class DakotaDoubleCustomization : UserControl
    {
        /// <summary>
        /// This variable is used so I can notify the properties have changed
        /// </summary>
        private Order linkToOrder;

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="dc">Datacontext: This is the overall order so I can trigger the special properties for the order</param>
        public DakotaDoubleCustomization(object dc)
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
            DakotaDoubleBurger ddb = (DakotaDoubleBurger)DataContext;
            switch (((Button)sender).Name)
            {
                case "BunButton":
                    if (ddb.Bun)
                        BunInformation.Text = "Holding Bun";
                    else
                        BunInformation.Text = "Not Holding Bun";
                    ddb.Bun = !ddb.Bun;
                    break;
                case "KetchupButton":
                    if (ddb.Ketchup)
                        KetchupInformation.Text = "Holding Ketchup";
                    else
                        KetchupInformation.Text = "Not Holding Ketchup";
                    ddb.Ketchup = !ddb.Ketchup;
                    break;
                case "MustardButton":
                    if (ddb.Mustard)
                        MustardInformation.Text = "Holding Mustard";
                    else
                        MustardInformation.Text = "Not Holding Mustard";
                    ddb.Mustard = !ddb.Mustard;
                    break;
                case "CheeseButton":
                    if (ddb.Cheese)
                        CheeseInformation.Text = "Holding Cheese";
                    else
                        CheeseInformation.Text = "Not Holding Cheese";
                    ddb.Cheese = !ddb.Cheese;
                    break;
                case "TomatoButton":
                    if (ddb.Tomato)
                        TomatoInformation.Text = "Holding Tomato";
                    else
                        TomatoInformation.Text = "Not Holding Tomato";
                    ddb.Tomato = !ddb.Tomato;
                    break;
                case "LettuceButton":
                    if (ddb.Lettuce)
                        LettuceInformation.Text = "Holding Lettuce";
                    else
                        LettuceInformation.Text = "Not Holding Lettuce";
                    ddb.Lettuce = !ddb.Lettuce;
                    break;
                case "MayoButton":
                    if (ddb.Mayo)
                        MayoInformation.Text = "Holding Mayo";
                    else
                        MayoInformation.Text = "Not Holding Mayo";
                    ddb.Mayo = !ddb.Mayo;
                    break;
                case "PickleButton":
                    if (ddb.Pickle)
                        PickleInformation.Text = "Holding Pickle";
                    else
                        PickleInformation.Text = "Not Holding Pickle";
                    ddb.Pickle = !ddb.Pickle;
                    break;
                default:
                    throw new NotImplementedException("Unknown Dakota Double Toggle Button Pressed");
            }
            linkToOrder.InvokePropertyChanged();
        }
    }
}
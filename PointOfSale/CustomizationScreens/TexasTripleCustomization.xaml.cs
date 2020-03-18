/*
 * Author: Zachery Brunner
 * Class: TexasTripleCustomization.xaml.cs
 * Purpose: Allows custoimzation for the texas triple burger
 */
using System;

using System.Windows;
using System.Windows.Controls;

using CowboyCafe.Data;
using CowboyCafe.Data.Entrees;

namespace PointOfSale.CustomizationScreens
{
    /// <summary>
    /// Interaction logic for TexasTripleCustomization.xaml
    /// </summary>
    public partial class TexasTripleCustomization : UserControl
    {
        /// <summary>
        /// This variable is used so I can notify the properties have changed
        /// </summary>
        private Order linkToOrder;

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="dc">Datacontext: This is the overall order so I can trigger the special properties for the order</param>

        public TexasTripleCustomization(object dc)
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
            TexasTripleBurger ttb = (TexasTripleBurger)DataContext;
            switch (((Button)sender).Name)
            {
                case "BunButton":
                    if (ttb.Bun)
                        BunInformation.Text = "Holding Bun";
                    else
                        BunInformation.Text = "Not Holding Bun";
                    ttb.Bun = !ttb.Bun;
                    break;
                case "KetchupButton":
                    if (ttb.Ketchup)
                        KetchupInformation.Text = "Holding Ketchup";
                    else
                        KetchupInformation.Text = "Not Holding Ketchup";
                    ttb.Ketchup = !ttb.Ketchup;
                    break;
                case "MustardButton":
                    if (ttb.Mustard)
                        MustardInformation.Text = "Holding Mustard";
                    else
                        MustardInformation.Text = "Not Holding Mustard";
                    ttb.Mustard = !ttb.Mustard;
                    break;
                case "CheeseButton":
                    if (ttb.Cheese)
                        CheeseInformation.Text = "Holding Cheese";
                    else
                        CheeseInformation.Text = "Not Holding Cheese";
                    ttb.Cheese = !ttb.Cheese;
                    break;
                case "TomatoButton":
                    if (ttb.Tomato)
                        TomatoInformation.Text = "Holding Tomato";
                    else
                        TomatoInformation.Text = "Not Holding Tomato";
                    ttb.Tomato = !ttb.Tomato;
                    break;
                case "LettuceButton":
                    if (ttb.Lettuce)
                        LettuceInformation.Text = "Holding Lettuce";
                    else
                        LettuceInformation.Text = "Not Holding Lettuce";
                    ttb.Lettuce = !ttb.Lettuce;
                    break;
                case "MayoButton":
                    if (ttb.Mayo)
                        MayoInformation.Text = "Holding Mayo";
                    else
                        MayoInformation.Text = "Not Holding Mayo";
                    ttb.Mayo = !ttb.Mayo;
                    break;
                case "EggButton":
                    if (ttb.Egg)
                        EggInformation.Text = "Holding Egg";
                    else
                        EggInformation.Text = "Not Holding Egg";
                    ttb.Egg = !ttb.Egg;
                    break;
                case "BaconButton":
                    if (ttb.Bacon)
                        BaconInformation.Text = "Holding Bacon";
                    else
                        BaconInformation.Text = "Not Holding Bacon";
                    ttb.Bacon = !ttb.Bacon;
                    break;
                case "PickleButton":
                    if (ttb.Pickle)
                        PickleInformation.Text = "Holding Pickle";
                    else
                        PickleInformation.Text = "Not Holding Pickle";
                    ttb.Pickle = !ttb.Pickle;
                    break;
                default:
                    throw new NotImplementedException("Unknown Texas Triple Toggle Button Pressed");
            }
            linkToOrder.InvokePropertyChanged();
        }
    }
}
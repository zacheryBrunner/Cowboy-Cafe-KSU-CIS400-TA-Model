/*
 * Author: Zachery Brunner
 * Class: FlavorChangingScreen.xaml.cs
 * Purpose: Allows customization for the Jerked Soda drink
 */
using System;

using System.Windows;
using System.Windows.Controls;

using CowboyCafe.Data.Drinks;
using SodaFlavor = CowboyCafe.Data.Enums.SodaFlavor;

namespace PointOfSale.CustomizationScreens
{
    /// <summary>
    /// Interaction logic for FlavorChangingScreen.xaml
    /// </summary>
    public partial class FlavorChangingScreen : UserControl
    {
        /// <summary>
        /// Public constructor
        /// </summary>
        public FlavorChangingScreen()
        {
            InitializeComponent();
        }

        private void FlavorRadioButton_Click(object sender, RoutedEventArgs e)
        {
            SodaFlavor s;

            switch (((RadioButton)sender).Name)
            {
                /* Cream Soda */
                case "FlavorRadioButtonCS":
                    s = SodaFlavor.CreamSoda;
                break;

                /* Orange Soda */
                case "FlavorRadioButtonOS":
                    s = SodaFlavor.OrangeSoda;
                break;

                /* Sarsparilla */
                case "FlavorRadioButtonS":
                    s = SodaFlavor.Sarsparilla;
                break;

                /* Birch Beer */
                case "FlavorRadioButtonBB":
                    s = SodaFlavor.BirchBeer;
                break;

                /* Root beer */
                case "FlavorRadioButtonRB":
                    s = SodaFlavor.RootBeer;
                break;
                
                default:
                    throw new NotImplementedException("Should never be reached");
            }

            /* Cast the datacontext to what it is and then
             *  set the size of that object equal to the value button that was pressed
             */
            if (DataContext is JerkedSoda)
            {
                JerkedSoda j = (JerkedSoda)DataContext;
                j.Flavor = s;
            }
            else
                throw new NotImplementedException("Only Jerked soda should be the datacontext");
        }
    }
}
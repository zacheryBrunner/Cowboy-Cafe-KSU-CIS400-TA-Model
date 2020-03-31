/*
 * Author: Zachery Brunner
 * Class: JerkedSodaCustomization.xaml.cs
 * Purpose: Allows customization for the cowboy coffee
 */
using System;
using System.Windows;
using System.Windows.Controls;

using CowboyCafe.Data;
using CowboyCafe.Data.Drinks;
using Size = CowboyCafe.Data.Enums.Size;
using Flavor = CowboyCafe.Data.Enums.SodaFlavor;

using PointOfSale.ExtensionMethods;

namespace PointOfSale.CustomizationScreens
{
    /// <summary>
    /// Interaction logic for JerkedSodaCustomization.xaml
    /// </summary>
    public partial class JerkedSodaCustomization : UserControl
    {
        /// <summary>
        /// Public constructor
        /// </summary>
        public JerkedSodaCustomization()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Filters which control was pressed and changes the holding state of the respective item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            JerkedSoda js = (JerkedSoda)DataContext;
            var orderControl = this.FindAncestor<OrderControl>();

            switch (((Button)sender).Name)
            {
                //Drink Customization Cases
                //Ice
                case "IceButton":
                    if (js.Ice)
                        IceInformation.Text = "No Ice";
                    else
                        IceInformation.Text = "With Ice";
                    js.Ice = !js.Ice;
                break;


                //Flavor Cases
                //Orange Soda
                case "OrangeSodaButton":
                    js.Flavor = Flavor.OrangeSoda; break;

                //Cream Soda
                case "CreamSodaButton":
                    js.Flavor = Flavor.CreamSoda; break;

                //Sarsparilla 
                case "SarsparillaButton":
                    js.Flavor = Flavor.Sarsparilla; break;

                //Birch Beer
                case "BirchBeerButton":
                    js.Flavor = Flavor.BirchBeer; break;

                //Root Beer
                case "RootBeerButton":
                    js.Flavor = Flavor.RootBeer;break;


                //Size Cases
                //Small
                case "SmallButton":
                    ((Order)orderControl.DataContext).subtotalHelperFunction(js, Size.Small); break;

                //Medium
                case "MediumButton":
                    ((Order)orderControl.DataContext).subtotalHelperFunction(js, Size.Medium); break;

                //Large
                case "LargeButton":
                    ((Order)orderControl.DataContext).subtotalHelperFunction(js, Size.Large); break;


                //Should never be reached unless we add more buttons and don't add the switch statements ;P
                default:
                    throw new NotImplementedException("Unknown Jerked Soda Toggle Button Pressed");
            }
            ((Order)orderControl.DataContext).InvokePropertyChanged();
        }
    }
}
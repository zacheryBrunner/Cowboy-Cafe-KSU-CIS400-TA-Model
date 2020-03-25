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

namespace PointOfSale.CustomizationScreens
{
    /// <summary>
    /// Interaction logic for JerkedSodaCustomization.xaml
    /// </summary>
    public partial class JerkedSodaCustomization : UserControl
    {
        /// <summary>
        /// This variable is used so I can notify the properties have changed
        /// </summary>
        private Order linkToOrder;

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="dc">Datacontext: This is the overall order so I can trigger the special properties for the order</param>

        public JerkedSodaCustomization(object dc)
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
            JerkedSoda js = (JerkedSoda)DataContext;
            switch (((Button)sender).Name)
            {
                //Drink Customization Cases
                case "IceButton":
                    if (js.Ice)
                        IceInformation.Text = "No Ice";
                    else
                        IceInformation.Text = "With Ice";
                    js.Ice = !js.Ice;
                    break;

                //Flavor Cases
                case "OrangeSodaButton":
                    js.Flavor = Flavor.OrangeSoda;
                    break;
                case "CreamSodaButton":
                    js.Flavor = Flavor.CreamSoda;
                    break;
                case "SarsparillaButton":
                    js.Flavor = Flavor.Sarsparilla;
                    break;
                case "BirchBeerButton":
                    js.Flavor = Flavor.BirchBeer;
                    break;
                case "RootBeerButton":
                    js.Flavor = Flavor.RootBeer;
                    break;

                //Size Cases
                case "SmallButton":
                    linkToOrder.subtotalHelperFunction(js, Size.Small);
                    break;
                case "MediumButton":
                    linkToOrder.subtotalHelperFunction(js, Size.Medium); 
                    break;
                case "LargeButton":
                    linkToOrder.subtotalHelperFunction(js, Size.Large);
                    break;
                default:
                    throw new NotImplementedException("Unknown Jerked Soda Toggle Button Pressed");
            }
            linkToOrder.InvokePropertyChanged();
        }
    }
}
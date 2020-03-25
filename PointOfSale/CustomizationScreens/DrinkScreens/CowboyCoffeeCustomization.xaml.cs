/*
 * Author: Zachery Brunner
 * Class: CowboyCoffeeCustomization.xaml.cs
 * Purpose: Allows customization for the cowboy coffee
 */
using System;

using System.Windows;
using System.Windows.Controls;

using CowboyCafe.Data;
using CowboyCafe.Data.Drinks;
using Size = CowboyCafe.Data.Enums.Size;

namespace PointOfSale.CustomizationScreens
{
    /// <summary>
    /// Interaction logic for CowboyCoffeeCustomization.xaml
    /// </summary>
    public partial class CowboyCoffeeCustomization : UserControl
    {
        /// <summary>
        /// This variable is used so I can notify the properties have changed
        /// </summary>
        private Order linkToOrder;

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="dc">Datacontext: This is the overall order so I can trigger the special properties for the order</param>
        public CowboyCoffeeCustomization(object dc)
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
            CowboyCoffee cc = (CowboyCoffee)DataContext;
            switch (((Button)sender).Name)
            {
                //Drink Customization Cases
                case "IceButton":
                    if (cc.Ice)
                        IceInformation.Text = "No Ice";
                    else
                        IceInformation.Text = "With Ice";
                    cc.Ice = !cc.Ice;
                    break;
                case "DecafButton":
                    if (cc.Decaf)
                        DecafInformation.Text = "Not Decaf";
                    else
                        DecafInformation.Text = "Decaf";
                    cc.Decaf = !cc.Decaf;
                    break;
                case "CreamButton":
                    if (cc.RoomForCream)
                        CreamInformation.Text = "No Cream";
                    else
                        CreamInformation.Text = "With Cream";
                    cc.RoomForCream = !cc.RoomForCream;
                    break;

                //Size Cases
                case "SmallButton":
                    linkToOrder.subtotalHelperFunction(cc, Size.Small); break;
                case "MediumButton":
                    linkToOrder.subtotalHelperFunction(cc, Size.Medium); break;
                case "LargeButton":
                    linkToOrder.subtotalHelperFunction(cc, Size.Large); break;
                default:
                    throw new NotImplementedException("Unknown Cowboy Coffee Toggle Button Pressed");
            }
            linkToOrder.InvokePropertyChanged();
        }
    }
}
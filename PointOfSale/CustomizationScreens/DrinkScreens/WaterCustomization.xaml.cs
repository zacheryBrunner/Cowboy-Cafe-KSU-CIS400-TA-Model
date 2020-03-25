/*
 * Author: Zachery Brunner
 * Class: WaterCustomization.xaml.cs
 * Purpose: Allows customization for water
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
    /// Interaction logic for WaterCustomization.xaml
    /// </summary>
    public partial class WaterCustomization : UserControl
    {
        /// <summary>
        /// This variable is used so I can notify the properties have changed
        /// </summary>
        private Order linkToOrder;

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="dc">Datacontext: This is the overall order so I can trigger the special properties for the order</param>
        public WaterCustomization(object dc)
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
            Water w = (Water)DataContext;
            switch (((Button)sender).Name)
            {
                //Drink Customization Cases
                case "IceButton":
                    if (w.Ice)
                        IceInformation.Text = "No Ice";
                    else
                        IceInformation.Text = "With Ice";
                    w.Ice = !w.Ice;
                    break;
                case "LemonButton":
                    if (w.Lemon)
                        LemonInformation.Text = "No Lemon";
                    else
                        LemonInformation.Text = "Lemon";
                    w.Lemon = !w.Lemon;
                    break;

                //Size Cases
                case "SmallButton":
                    linkToOrder.subtotalHelperFunction(w, Size.Small);
                    break;
                case "MediumButton":
                    linkToOrder.subtotalHelperFunction(w, Size.Medium); 
                    break;
                case "LargeButton":
                    linkToOrder.subtotalHelperFunction(w, Size.Large); 
                    break;
                default:
                    throw new NotImplementedException("Unknown Water Toggle Button Pressed");
            }
            linkToOrder.InvokePropertyChanged();
        }
    }
}
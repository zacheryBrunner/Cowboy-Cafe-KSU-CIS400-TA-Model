/*
 * Author: Zachery Brunner
 * Class: AngryChickenCustomization.xaml.cs
 * Purpose: Allows customization options for the angry chicken entree
 */
using System;
using System.Windows;
using System.Windows.Controls;

using CowboyCafe.Data;
using CowboyCafe.Data.Entrees;

namespace PointOfSale.CustomizationScreens
{
    /// <summary>
    /// Interaction logic for AngryChickenCustomization.xaml
    /// </summary>
    public partial class AngryChickenCustomization : UserControl
    {
        /// <summary>
        /// This variable is used so I can notify the properties have changed
        /// </summary>
        private Order linkToOrder;

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="dc">Datacontext: This is the overall order so I can trigger the special properties for the order</param>
        public AngryChickenCustomization(object dc)
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
            AngryChicken ac = (AngryChicken)DataContext;
            switch(((Button)sender).Name)
            {
                case "PickleButton":
                    if (ac.Pickle)
                        PickleInformation.Text = "Holding Pickle";
                    else
                        PickleInformation.Text = "Not Holding Pickle";
                    ac.Pickle = !ac.Pickle;
                    break;
                case "BreadButton":
                    if (ac.Bread)
                        BreadInformation.Text = "Holding Bread";
                    else
                        BreadInformation.Text = "Not Holding Bread";
                    ac.Bread = !ac.Bread;
                    break;
                default:
                    throw new NotImplementedException("Unknown Angry Chicken Toggle Button Pressed");
            }
            linkToOrder.InvokePropertyChanged();
        }
    }
}
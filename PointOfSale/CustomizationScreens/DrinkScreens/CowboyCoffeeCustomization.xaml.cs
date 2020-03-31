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

using PointOfSale.ExtensionMethods;

namespace PointOfSale.CustomizationScreens
{
    /// <summary>
    /// Interaction logic for CowboyCoffeeCustomization.xaml
    /// </summary>
    public partial class CowboyCoffeeCustomization : UserControl
    {
        /// <summary>
        /// Public constructor
        /// </summary>
        public CowboyCoffeeCustomization()
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
            CowboyCoffee cc = (CowboyCoffee)DataContext;
            var orderControl = this.FindAncestor<OrderControl>();

            switch (((Button)sender).Name)
            {
                //Option Cases
                //Ice
                case "IceButton":
                    if (cc.Ice)
                        IceInformation.Text = "No Ice";
                    else
                        IceInformation.Text = "With Ice";
                    cc.Ice = !cc.Ice;
                break;
                
                //Decaf
                case "DecafButton":
                    if (cc.Decaf)
                        DecafInformation.Text = "Not Decaf";
                    else
                        DecafInformation.Text = "Decaf";
                    cc.Decaf = !cc.Decaf;
                break;
                
                //Cream
                case "CreamButton":
                    if (cc.RoomForCream)
                        CreamInformation.Text = "No Cream";
                    else
                        CreamInformation.Text = "With Cream";
                    cc.RoomForCream = !cc.RoomForCream;
                break;


                //Size Cases
                //Small
                case "SmallButton":
                    ((Order)orderControl.DataContext).subtotalHelperFunction(cc, Size.Small); break;

                //Medium
                case "MediumButton":
                    ((Order)orderControl.DataContext).subtotalHelperFunction(cc, Size.Medium); break;

                //Large
                case "LargeButton":
                    ((Order)orderControl.DataContext).subtotalHelperFunction(cc, Size.Large); break;
                
                //This should never be reached unless we add more buttons and forget to add the case statements ;P
                default:
                    throw new NotImplementedException("Unknown Cowboy Coffee Toggle Button Pressed");
            }
            ((Order)orderControl.DataContext).InvokePropertyChanged();
        }
    }
}
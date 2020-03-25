/*
 * Author: Zachery Brunner
 * Class: TexasTeaCustomization.xaml.cs
 * Purpose: Allows customization for the texas tea
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
    /// Interaction logic for TexasTeaCustomization.xaml
    /// </summary>
    public partial class TexasTeaCustomization : UserControl
    {
        /// <summary>
        /// This variable is used so I can notify the properties have changed
        /// </summary>
        private Order linkToOrder;

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="dc">Datacontext: This is the overall order so I can trigger the special properties for the order</param>
        public TexasTeaCustomization(object dc)
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
            TexasTea tt = (TexasTea)DataContext;
            switch (((Button)sender).Name)
            {
                //Drink Customization Cases
                case "IceButton":
                    if (tt.Ice)
                        IceInformation.Text = "No Ice";
                    else
                        IceInformation.Text = "With Ice";
                    tt.Ice = !tt.Ice;
                    break;
                case "SweetButton":
                    if (tt.Sweet)
                        SweetInformation.Text = "Not Sweet";
                    else
                        SweetInformation.Text = "Sweet";
                    tt.Sweet = !tt.Sweet;
                    break;
                case "LemonButton":
                    if (tt.Lemon)
                        LemonInformation.Text = "No Lemon";
                    else
                        LemonInformation.Text = "With Lemon";
                    tt.Lemon = !tt.Lemon;
                    break;

                //Size Cases
                case "SmallButton":
                    tt.Size = Size.Small;
                    linkToOrder.subtotalHelperFunction(tt, Size.Small);
                    break;
                case "MediumButton":
                    linkToOrder.subtotalHelperFunction(tt, Size.Medium); 
                    break;
                case "LargeButton":
                    linkToOrder.subtotalHelperFunction(tt, Size.Large); 
                    break;
                default:
                    throw new NotImplementedException("Unknown Texas Tea Toggle Button Pressed");
            }
            linkToOrder.InvokePropertyChanged();
        }
    }
}
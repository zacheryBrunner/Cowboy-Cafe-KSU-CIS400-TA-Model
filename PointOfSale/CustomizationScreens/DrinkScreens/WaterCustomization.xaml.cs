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

using PointOfSale.ExtensionMethods;

namespace PointOfSale.CustomizationScreens
{
    /// <summary>
    /// Interaction logic for WaterCustomization.xaml
    /// </summary>
    public partial class WaterCustomization : UserControl
    {
        /// <summary>
        /// Public constructor
        /// </summary>
        public WaterCustomization()
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
            Water w = (Water)DataContext;
            var orderControl = this.FindAncestor<OrderControl>();

            switch (((Button)sender).Name)
            {
                //Drink Customization Cases
                //Ice
                case "IceButton":
                    if (w.Ice)
                        IceInformation.Text = "No Ice";
                    else
                        IceInformation.Text = "With Ice";
                    w.Ice = !w.Ice;
                break;
                
                //Lemon
                case "LemonButton":
                    if (w.Lemon)
                        LemonInformation.Text = "No Lemon";
                    else
                        LemonInformation.Text = "Lemon";
                    w.Lemon = !w.Lemon;
                break;


                //Size Cases
                //Small
                case "SmallButton":
                    ((Order)orderControl.DataContext).subtotalHelperFunction(w, Size.Small); break;

                //Medium
                case "MediumButton":
                    ((Order)orderControl.DataContext).subtotalHelperFunction(w, Size.Medium); break;
                
                //Large
                case "LargeButton":
                    ((Order)orderControl.DataContext).subtotalHelperFunction(w, Size.Large); break;
                
                //This case should never be reached unless we add more buttons and forget to add the switch cases ;P
                default:
                    throw new NotImplementedException("Unknown Water Toggle Button Pressed");
            }
            ((Order)orderControl.DataContext).InvokePropertyChanged();
        }
    }
}
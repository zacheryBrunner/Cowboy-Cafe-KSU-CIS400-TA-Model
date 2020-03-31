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

using PointOfSale.ExtensionMethods;

namespace PointOfSale.CustomizationScreens
{
    /// <summary>
    /// Interaction logic for TexasTeaCustomization.xaml
    /// </summary>
    public partial class TexasTeaCustomization : UserControl
    {
        /// <summary>
        /// Public constructor
        /// </summary>
        public TexasTeaCustomization()
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
            TexasTea tt = (TexasTea)DataContext;
            var orderControl = this.FindAncestor<OrderControl>();

            switch (((Button)sender).Name)
            {
                //Drink Customization Cases
                //Ice
                case "IceButton":
                    if (tt.Ice)
                        IceInformation.Text = "No Ice";
                    else
                        IceInformation.Text = "With Ice";
                    tt.Ice = !tt.Ice;
                break;
                
                //Sweet
                case "SweetButton":
                    if (tt.Sweet)
                        SweetInformation.Text = "Not Sweet";
                    else
                        SweetInformation.Text = "Sweet";
                    tt.Sweet = !tt.Sweet;
                break;
                
                //Lemon
                case "LemonButton":
                    if (tt.Lemon)
                        LemonInformation.Text = "No Lemon";
                    else
                        LemonInformation.Text = "With Lemon";
                    tt.Lemon = !tt.Lemon;
                break;


                //Size Cases
                //Small
                case "SmallButton":
                    ((Order)orderControl.DataContext).subtotalHelperFunction(tt, Size.Small); break;

                //Medium
                case "MediumButton":
                    ((Order)orderControl.DataContext).subtotalHelperFunction(tt, Size.Medium); break;
                
                //Large
                case "LargeButton":
                    ((Order)orderControl.DataContext).subtotalHelperFunction(tt, Size.Large); break;
                

                //This should never be reached unless we add more buttons and forget to add the case statements ;P
                default:
                    throw new NotImplementedException("Unknown Texas Tea Toggle Button Pressed");
            }
            ((Order)orderControl.DataContext).InvokePropertyChanged();
        }
    }
}
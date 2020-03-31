/*
 * Author: Zachery Brunner
 * Class: SizeChangingCustomization.xaml.cs
 * Purpose: Allows customization for any side's size
 */
using System;

using System.Windows;
using System.Windows.Controls;

using CowboyCafe.Data.Sides;
using CowboyCafe.Data.Drinks;
using Size = CowboyCafe.Data.Enums.Size;

namespace PointOfSale.CustomizationScreens
{
    /// <summary>
    /// Interaction logic for SizeChangingCustomization.xaml
    /// </summary>
    public partial class SizeChangingCustomization : UserControl
    {
        public SizeChangingCustomization()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Responsible for changing the size of the datacontext or menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SizeRadioButton_Click(object sender, RoutedEventArgs e)
        {
            Size s;

            switch (((RadioButton)sender).Name)
            {
                /* Small */
                case "SizeRadioButtonSmall":
                    s = Size.Small;
                    break;

                /* Medium */
                case "SizeRadioButtonMedium":
                    s = Size.Medium;
                    break;

                /* Large */
                case "SizeRadioButtonLarge":
                    s = Size.Large;
                    break;

                default:
                    throw new NotImplementedException("Should never be reached");
            }

            /* Cast the datacontext to what it is and then
             *  set the size of that object equal to the value button that was pressed
             */
            if (DataContext is Drink)
            {
                Drink d = (Drink)DataContext;
                d.Size = s;
            }
            else if (DataContext is Side)
            {
                Side si = (Side)DataContext;
                si.Size = s;
            }
            else
                throw new NotImplementedException("This should never be reached");
        }
    }
}
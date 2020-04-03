/*
 * Author: Zachery Brunner
 * Class: OrderControl.xaml.cs
 * Purpose: Backend logic for the OrderControl.xaml class
 */
using System;
using System.Windows;
using System.Windows.Controls;

using CowboyCafe.Data;
using CowboyCafe.Data.Entrees;
using CowboyCafe.Data.Drinks;
using CowboyCafe.Data.Sides;

using Size = CowboyCafe.Data.Enums.Size;
using SodaFlavor = CowboyCafe.Data.Enums.SodaFlavor;

using PointOfSale.CustomizationScreens;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderControl.xaml
    /// </summary>
    public partial class OrderControl : UserControl
    {
        public OrderControl()
        {
            var o = new Order(1);
            DataContext = o;
            InitializeComponent();
        }

        /// <summary>
        /// Handler that takes care of completing an order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            Order o = (Order)DataContext;
            DataContext = new Order(o.OrderNumber + 1);
        }

        /// <summary>
        /// Handler that takes care of canceling an order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelOrderButton_Click(object sender, RoutedEventArgs e)
        {
            Order o = (Order)DataContext;
            DataContext = new Order(o.OrderNumber + 1);
        }

        /// <summary>
        /// I do not know what this is suppose to do yet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemSelectionButton_Click(object sender, RoutedEventArgs e)
        {
            Container.Child = new MenuItemSelectionControl();
        }

        /// <summary>
        /// Swaps the screen
        /// </summary>
        /// <param name="element">The element that the screen is swapping to</param>
        public void SwapScreen(FrameworkElement element)
        {
            element = SwapScreenHelper(element);
            Container.Child = element;
        }

        /// <summary>
        /// This is a substitution to binding the enums, This should probably be split into 2 methods. Im just lazy and this works
        /// </summary>
        /// <param name="element"></param>
        /// <returns>Updated Framework element</returns>
        private FrameworkElement SwapScreenHelper(FrameworkElement element)
        {
            /* Entrees dont have any size or flavors */
            if (element.DataContext is Entree)
                return element;

            /* Drinks have a size we must set that radio button */
            else if (element.DataContext is Drink)
            {
                /* Cast the datacontext of the element to a drink */
                Drink d = (Drink)element.DataContext;

                /* Jerked soda has a flavor so we need to see if the datacontext is a jerked soda */
                if (d is JerkedSoda)
                {
                    switch (((JerkedSoda)element.DataContext).Flavor)
                    {
                        case SodaFlavor.OrangeSoda:
                            
                            /*
                             * Step 1: Cast the element to a JerkedSodaCustomization FrameworkElement
                             * Step 2: Get the FlavorBorder's child
                             * Step 3: Cast the child to a FlavorChangingScreen
                             * Step 4: Set the specific radio button per the case to true
                             * Step 5: Break
                             */
                            ((FlavorChangingScreen)((JerkedSodaCustomization)element).FlavorBorder.Child).FlavorRadioButtonOS.IsChecked = true; break;

                        case SodaFlavor.CreamSoda:
                            ((FlavorChangingScreen)((JerkedSodaCustomization)element).FlavorBorder.Child).FlavorRadioButtonCS.IsChecked = true; break;

                        case SodaFlavor.Sarsparilla:
                            ((FlavorChangingScreen)((JerkedSodaCustomization)element).FlavorBorder.Child).FlavorRadioButtonS.IsChecked = true; break;

                        case SodaFlavor.BirchBeer:
                            ((FlavorChangingScreen)((JerkedSodaCustomization)element).FlavorBorder.Child).FlavorRadioButtonBB.IsChecked = true; break;

                        case SodaFlavor.RootBeer:
                            ((FlavorChangingScreen)((JerkedSodaCustomization)element).FlavorBorder.Child).FlavorRadioButtonRB.IsChecked = true; break;

                        default:
                            throw new NotImplementedException("Should never be reached");
                    }
                }

                Size s = d.Size;
                /* I encourage you to set a breakpoint here at line 128.
                 * 
                 * Look at what the GetType() statement returns by hovering over in debug mode
                 * and hitting the down arrow 
                 * 
                 * The .Name property is the name of the class from which the object originates! Isnt that cool!
                 */
                switch (((element.DataContext).GetType()).Name)
                {
                    /* This is where the comments stop, everything from here on out is just repetition with different variable
                     *  I would still encourage you continue reading to fully understand what I have done :)
                     */
                    case "CowboyCoffee":
                        switch (s)
                        {
                            case Size.Small:
                                ((SizeChangingCustomization)((CowboyCoffeeCustomization)element).SizeBorder.Child).SizeRadioButtonSmall.IsChecked = true; break;
                            case Size.Medium:
                                ((SizeChangingCustomization)((CowboyCoffeeCustomization)element).SizeBorder.Child).SizeRadioButtonMedium.IsChecked = true; break;
                            case Size.Large:
                                ((SizeChangingCustomization)((CowboyCoffeeCustomization)element).SizeBorder.Child).SizeRadioButtonLarge.IsChecked = true; break;
                            default:
                                throw new NotImplementedException("Should never be reached");
                        }
                        break;

                    case "JerkedSoda":
                        switch (s)
                        {
                            case Size.Small:
                                ((SizeChangingCustomization)((JerkedSodaCustomization)element).SizeBorder.Child).SizeRadioButtonSmall.IsChecked = true; break;
                            case Size.Medium:
                                ((SizeChangingCustomization)((JerkedSodaCustomization)element).SizeBorder.Child).SizeRadioButtonMedium.IsChecked = true; break;
                            case Size.Large:
                                ((SizeChangingCustomization)((JerkedSodaCustomization)element).SizeBorder.Child).SizeRadioButtonLarge.IsChecked = true; break;
                            default:
                                throw new NotImplementedException("Should never be reached");
                        }
                        break;

                    case "TexasTea":
                        switch (s)
                        {
                            case Size.Small:
                                ((SizeChangingCustomization)((TexasTeaCustomization)element).SizeBorder.Child).SizeRadioButtonSmall.IsChecked = true; break;
                            case Size.Medium:
                                ((SizeChangingCustomization)((TexasTeaCustomization)element).SizeBorder.Child).SizeRadioButtonMedium.IsChecked = true; break;
                            case Size.Large:
                                ((SizeChangingCustomization)((TexasTeaCustomization)element).SizeBorder.Child).SizeRadioButtonLarge.IsChecked = true; break;
                            default:
                                throw new NotImplementedException("Should never be reached");
                        }
                        break;

                    case "Water":
                        switch (s)
                        {
                            case Size.Small:
                                ((SizeChangingCustomization)((WaterCustomization)element).SizeBorder.Child).SizeRadioButtonSmall.IsChecked = true; break;
                            case Size.Medium:
                                ((SizeChangingCustomization)((WaterCustomization)element).SizeBorder.Child).SizeRadioButtonMedium.IsChecked = true; break;
                            case Size.Large:
                                ((SizeChangingCustomization)((WaterCustomization)element).SizeBorder.Child).SizeRadioButtonLarge.IsChecked = true; break;
                            default:
                                throw new NotImplementedException("Should never be reached");
                        }
                        break;

                    default:
                        throw new NotImplementedException("Should never be reached");
                }
            }

            else if (element.DataContext is Side)
            {
                Size s = ((Side)element.DataContext).Size;
                switch (s)
                {
                    case Size.Small: ((SizeChangingCustomization)element).SizeRadioButtonSmall.IsChecked = true; break;

                    case Size.Medium: ((SizeChangingCustomization)element).SizeRadioButtonMedium.IsChecked = true; break;

                    case Size.Large: ((SizeChangingCustomization)element).SizeRadioButtonLarge.IsChecked = true; break;

                    default: throw new NotImplementedException("Should never be reached");
                }
            }

            else
                throw new NotImplementedException("Should never be reached");

            return element;
        }
    }
}
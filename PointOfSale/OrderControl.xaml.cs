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
using PointOfSale.ExtensionMethods;

using CashRegister;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderControl.xaml
    /// </summary>
    public partial class OrderControl : UserControl
    {
        CashDrawer cd;

        public OrderControl()
        {
            InitializeComponent();

            var o = new Order(1);
            DataContext = o;
            cd = new CashDrawer();
        }

        /// <summary>
        /// Handler that takes care of completing an order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            /* Get the current order's items */
            Order o = (Order)DataContext;
            IOrderItem[] io = (IOrderItem[])o.Items;
            
            /* Check to make sure there is a transaction available */
            if (io.Length != 0)
            {
                MainWindow mw = this.FindAncestor<MainWindow>();
                mw.Container.Child = new TransactionControl(cd, this);


                /* Make new order */
                DataContext = new Order(o.OrderNumber + 1);
            }
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
        /// Gets the information required to change the sizes
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
                    /*
                     * Step 1: Cast the element to a JerkedSodaCustomization FrameworkElement
                     * Step 2: Get the FlavorBorder's child
                     * Step 3: Cast the child to a FlavorChangingScreen
                     * Step 4: Set the specific radio button per the case to true
                     * Step 5: Break
                     */
                    FlavorChangingScreen fcs = (FlavorChangingScreen)(((JerkedSodaCustomization)element).FlavorBorder.Child);

                    switch (((JerkedSoda)element.DataContext).Flavor)
                    {
                        case SodaFlavor.OrangeSoda:
                            fcs.FlavorRadioButtonOS.IsChecked = true; break;

                        case SodaFlavor.CreamSoda:
                            fcs.FlavorRadioButtonCS.IsChecked = true; break;

                        case SodaFlavor.Sarsparilla:
                            fcs.FlavorRadioButtonS.IsChecked = true; break;

                        case SodaFlavor.BirchBeer:
                            fcs.FlavorRadioButtonBB.IsChecked = true; break;

                        case SodaFlavor.RootBeer:
                            fcs.FlavorRadioButtonRB.IsChecked = true; break;

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
                        setSize(((SizeChangingCustomization)((CowboyCoffeeCustomization)element).SizeBorder.Child), s); break;

                    case "JerkedSoda":
                        setSize(((SizeChangingCustomization)((JerkedSodaCustomization)element).SizeBorder.Child), s); break;

                    case "TexasTea":
                        setSize(((SizeChangingCustomization)((TexasTeaCustomization)element).SizeBorder.Child), s); break;

                    case "Water":
                        setSize(((SizeChangingCustomization)((WaterCustomization)element).SizeBorder.Child), s); break;

                    default:
                        throw new NotImplementedException("Should never be reached");
                }
            }

            else if (element.DataContext is Side)
                setSize((SizeChangingCustomization)element, ((Side)element.DataContext).Size);

            else
                throw new NotImplementedException("Should never be reached");

            return element;
        }

        /// <summary>
        /// Does the actual setting of the sizes
        /// </summary>
        /// <param name="scc">The size screen associated with the order item</param>
        /// <param name="s">The size it needs to be set to</param>
        private void setSize(SizeChangingCustomization scc, Size s)
        {
            switch (s)
            {
                case Size.Small: scc.SizeRadioButtonSmall.IsChecked = true; break;

                case Size.Medium: scc.SizeRadioButtonMedium.IsChecked = true; break;

                case Size.Large: scc.SizeRadioButtonLarge.IsChecked = true; break;

                default: throw new NotImplementedException("Should never be reached");
            }
        }
    }
}
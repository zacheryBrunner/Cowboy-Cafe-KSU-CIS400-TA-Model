/*
 * Author: Zachery Brunner
 * Class: OrderControl.xaml.cs
 * Purpose: Backend logic for the user controls
 */
using System;

using System.Windows;
using System.Windows.Controls;

using CowboyCafe.Data;
using CowboyCafe.Data.Entrees;
using CowboyCafe.Data.Sides;
using CowboyCafe.Data.Drinks;

using PointOfSale.ExtensionMethods;
using PointOfSale.CustomizationScreens;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderControl.xaml
    /// </summary>
    public partial class MenuItemSelectionControl : UserControl
    {
        public MenuItemSelectionControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method adds entrees to the list by converting the
        /// sender object to a button and filtering on the name of the button
        /// that was pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addEntreeToList(object sender, RoutedEventArgs e)
        {
            //Ensure the DataContext is an Order and not NULL
            if (DataContext is Order data)
            {
                if (sender is Button)
                {
                    IOrderItem item;
                    FrameworkElement screen = null;
                    var orderControl = this.FindAncestor<OrderControl>();

                    //Cast sender to button
                    Button b = (Button)sender;

                    //Filter which button was pressed based on name
                    switch (b.Name)
                    {
                        case "AngryChickenButton":
                            item = new AngryChicken();
                            screen = new AngryChickenCustomization(DataContext);
                            break;
                        case "CowpokeChiliButton":
                            item = new CowpokeChili();
                            screen = new CowpokeChiliCustomization(DataContext);
                            break;
                        case "DakotaDoubleButton":
                            item = new DakotaDoubleBurger();
                            screen = new DakotaDoubleCustomization(DataContext);
                            break;
                        case "PecosPulledPorkButton":
                            item = new PecosPulledPork();
                            screen = new PecosPulledPorkCustomization(DataContext);
                            break;
                        case "RustlersRibsButton":
                            item = new RustlersRibs();
                            screen = new RustlersRibsCustomization();
                            break;
                        case "TexasTripleButton":
                            item = new TexasTripleBurger();
                            screen = new TexasTripleCustomization(DataContext);
                            break;
                        case "TrailBurgerButton":
                            item = new TrailBurger();
                            screen = new TrailBurgerCustomization(DataContext);
                            break;
                        default:
                            throw new NotImplementedException("Unknown entree button clicked");
                    }
                    if(screen != null) screen.DataContext = item;
                    data.Add(item);
                    orderControl?.SwapScreen(screen);
                }
            }
        }

        /// <summary>
        /// This method adds sides to the list by converting the
        /// sender object to a button and filtering on the name of the button
        /// that was pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addSideToList(object sender, RoutedEventArgs e)
        {
            //Ensure the DataContext is an Order and not NULL
            if (DataContext is Order data)
            {
                if (sender is Button)
                {
                    IOrderItem item;
                    FrameworkElement screen = null;
                    var orderControl = this.FindAncestor<OrderControl>();

                    //Cast sender to button
                    Button b = (Button)sender;

                    //Filter which button was pressed based on name
                    switch (b.Name)
                    {
                        case "BakedBeansButton":
                            item = new BakedBeans();
                            break;
                        case "ChiliCheeseFriesButton":
                            item = new ChiliCheeseFries();
                            break;
                        case "CornDodgersButton":
                            item = new CornDodgers();
                            break;
                        case "PanDeCampoButton":
                            item = new PanDeCampo();
                            break;
                        default:
                            throw new NotImplementedException("Unknown side button clicked");
                    }
                    screen = new SideSizeCustomization(DataContext);
                    screen.DataContext = item;
                    data.Add(item);
                    orderControl?.SwapScreen(screen);
                }
            }
        }

        /// <summary>
        /// This method adds drinks to the list by converting the
        /// sender object to a button and filtering on the name of the button
        /// that was pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addDrinkToList(object sender, RoutedEventArgs e)
        {
            //Ensure the DataContext is an Order and not NULL
            if (DataContext is Order data)
            {
                if (sender is Button)
                {
                    IOrderItem item;
                    FrameworkElement screen = null;
                    var orderControl = this.FindAncestor<OrderControl>();

                    //Cast sender to button
                    Button b = (Button)sender;

                    //Filter which button was pressed based on name
                    switch (b.Name)
                    {
                        case "CowboyCoffeeButton":
                            item = new CowboyCoffee();
                            screen = new CowboyCoffeeCustomization(DataContext);
                            break;
                        case "JerkedSodaButton":
                            item = new JerkedSoda();
                            screen = new JerkedSodaCustomization(DataContext);
                            break;
                        case "TexasTeaButton":
                            item = new TexasTea();
                            screen = new TexasTeaCustomization(DataContext);
                            break;
                        case "WaterButton":
                            item = new Water();
                            screen = new WaterCustomization(DataContext);
                            break;
                        default:
                            throw new NotImplementedException("Unknown drink button clicked");
                    }
                    if (screen != null) screen.DataContext = item;
                    data.Add(item);
                    orderControl?.SwapScreen(screen);
                }
            }
        }
    }
}
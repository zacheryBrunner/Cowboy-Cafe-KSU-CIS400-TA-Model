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
        /// <summary>
        /// Constructor
        /// </summary>
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
                //Ensure the sender is on of buttons
                if (sender is Button)
                {
                    IOrderItem item;
                    FrameworkElement screen;
                    var orderControl = this.FindAncestor<OrderControl>();

                    //Filter which button was pressed based on name
                    switch (((Button)sender).Name)
                    {
                        //Angry Chicken
                        case "AngryChickenButton":
                            item = new AngryChicken();
                            screen = new AngryChickenCustomization();
                        break;
                        
                        //Cowpoke Chili
                        case "CowpokeChiliButton":
                            item = new CowpokeChili();
                            screen = new CowpokeChiliCustomization();
                        break;
                        
                        //Dakota Double
                        case "DakotaDoubleButton":
                            item = new DakotaDoubleBurger();
                            screen = new DakotaDoubleCustomization();
                        break;

                        //Pecos Pulled Pork
                        case "PecosPulledPorkButton":
                            item = new PecosPulledPork();
                            screen = new PecosPulledPorkCustomization();
                        break;
                        
                        //Rustlers Ribs
                        case "RustlersRibsButton":
                            item = new RustlersRibs();
                            screen = new RustlersRibsCustomization();
                        break;

                        //Texas Triple
                        case "TexasTripleButton":
                            item = new TexasTripleBurger();
                            screen = new TexasTripleCustomization();
                        break;
                        
                        //Trail Burger
                        case "TrailBurgerButton":
                            item = new TrailBurger();
                            screen = new TrailBurgerCustomization();
                        break;
                        
                        //Default case, should never be reached. Unless we expland our entree menu and forget to add the case statement ;P
                        default:
                            throw new NotImplementedException("Unknown entree button clicked");
                    }
                    //Set the datacontext of the screen to the item and set the items screen property equal to the screen
                    screen.DataContext = item;
                    item.Screen = screen;
                    
                    //Add the item to the order and swap the screen
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
                //Ensure the sender is on of buttons
                if (sender is Button)
                {
                    IOrderItem item;
                    FrameworkElement screen = new SideSizeCustomization();
                    var orderControl = this.FindAncestor<OrderControl>();

                    //Filter which button was pressed based on name
                    switch (((Button)sender).Name)
                    {
                        //Baked Beans
                        case "BakedBeansButton":
                            item = new BakedBeans();
                        break;
                        
                        //Chili Cheese Fries
                        case "ChiliCheeseFriesButton":
                            item = new ChiliCheeseFries();
                            break;
                        
                        //Corn Dodgers
                        case "CornDodgersButton":
                            item = new CornDodgers();
                        break;
                        
                        //Pan De Campo
                        case "PanDeCampoButton":
                            item = new PanDeCampo();
                        break;
                        
                        //This should never be reached unless we add more sides and forget to add the case statements ;P
                        default:
                            throw new NotImplementedException("Unknown side button clicked");
                    }
                    //Set the datacontext of the screen to the item and set the items screen property equal to the screen
                    screen.DataContext = item;
                    item.Screen = screen;

                    //Add the item to the order and swap the screen
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
                //Ensure the sender is on of buttons
                if (sender is Button)
                {
                    IOrderItem item;
                    FrameworkElement screen;
                    var orderControl = this.FindAncestor<OrderControl>();

                    //Filter which button was pressed based on name
                    switch (((Button)sender).Name)
                    {
                        //Cowboy Coffee
                        case "CowboyCoffeeButton":
                            item = new CowboyCoffee();
                            screen = new CowboyCoffeeCustomization();
                        break;
                        
                        //Jerked Soda
                        case "JerkedSodaButton":
                            item = new JerkedSoda();
                            screen = new JerkedSodaCustomization();
                        break;
                        
                        //Texas Tea
                        case "TexasTeaButton":
                            item = new TexasTea();
                            screen = new TexasTeaCustomization();
                        break;
                        
                        //Water
                        case "WaterButton":
                            item = new Water();
                            screen = new WaterCustomization();
                        break;

                        //This should never be reached unless we add more sides and forget to add the case statements ;P
                        default:
                            throw new NotImplementedException("Unknown drink button clicked");
                    }
                    //Set the datacontext of the screen to the item and set the items screen property equal to the screen
                    screen.DataContext = item;
                    item.Screen = screen;

                    //Add the item to the order and swap the screen
                    data.Add(item);
                    orderControl?.SwapScreen(screen);
                }
            }
        }
    }
}
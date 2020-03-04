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
                //Cast sender to button
                Button b = (Button)sender;

                //Filter which button was pressed based on name
                switch (b.Name)
                {
                    case "AngryChickenButton":
                        data.Add(new AngryChicken());
                        break;
                    case "CowpokeChiliButton":
                        data.Add(new CowpokeChili());
                        break;
                    case "DakotaDoubleButton":
                        data.Add(new DakotaDoubleBurger());
                        break;
                    case "PecosPulledPorkButton":
                        data.Add(new PecosPulledPork());
                        break;
                    case "RustlersRibsButton":
                        data.Add(new RustlersRibs());
                        break;
                    case "TexasTripleButton":
                        data.Add(new TexasTripleBurger());
                        break;
                    case "TrailBurgerButton":
                        data.Add(new TrailBurger());
                        break;
                    default:
                        throw new NotImplementedException("Unknown entree button clicked");
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
                //Cast sender to button
                Button b = (Button)sender;

                //Filter which button was pressed based on name
                switch (b.Name)
                {
                    case "BakedBeansButton":
                        data.Add(new BakedBeans());
                        break;
                    case "ChiliCheeseFriesButton":
                        data.Add(new ChiliCheeseFries());
                        break;
                    case "CornDodgersButton":
                        data.Add(new CornDodgers());
                        break;
                    case "PanDeCampoButton":
                        data.Add(new PanDeCampo());
                        break;
                    default:
                        throw new NotImplementedException("Unknown side button clicked");
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
                //Cast sender to button
                Button b = (Button)sender;

                //Filter which button was pressed based on name
                switch (b.Name)
                {
                    case "CowboyCoffeeButton":
                        data.Add(new CowboyCoffee());
                        break;
                    case "JerkedSodaButton":
                        data.Add(new JerkedSoda());
                        break;
                    case "TexasTeaButton":
                        data.Add(new TexasTea());
                        break;
                    case "WaterButton":
                        data.Add(new Water());
                        break;
                    default:
                        throw new NotImplementedException("Unknown drink button clicked");
                }
            }
        }
    }
}
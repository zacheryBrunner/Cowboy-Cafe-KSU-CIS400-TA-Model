/*
 * Author: Zachery Brunner
 * Class: OrderControl.xaml.cs
 * Purpose: Backend logic for the user controls
 */
using System;

using System.Windows;
using System.Windows.Controls;

using CowboyCafe.Data.Entrees;
using CowboyCafe.Data.Sides;
using CowboyCafe.Data.Drinks;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderControl.xaml
    /// </summary>
    public partial class OrderControl : UserControl
    {
        public OrderControl()
        {
            InitializeComponent();
            Reciept.Items.Add("Welcome to Cowboy Cafe!");
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
            //Cast sender to button
            Button b = (Button)sender;

            //Filter which button was pressed based on name
            switch(b.Name)
            {
                case "AngryChickenButton":
                    Reciept.Items.Add(new AngryChicken().ToString());
                    break;
                case "CowpokeChiliButton":
                    Reciept.Items.Add(new CowpokeChili().ToString());
                    break;
                case "DakotaDoubleButton":
                    Reciept.Items.Add(new DakotaDoubleBurger().ToString());
                    break;
                case "PecosPulledPorkButton":
                    Reciept.Items.Add(new PecosPulledPork().ToString());
                    break;
                case "RustlersRibsButton":
                    Reciept.Items.Add(new RustlersRibs().ToString());
                    break;
                case "TexasTripleButton":
                    Reciept.Items.Add(new TexasTripleBurger().ToString());
                    break;
                case "TrailBurgerButton":
                    Reciept.Items.Add(new TrailBurger().ToString());
                    break;
                default:
                    throw new NotImplementedException("Unknown entree button clicked");
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
            Button b = (Button)sender;

            switch(b.Name)
            {
                case "BakedBeansButton":
                    Reciept.Items.Add(new BakedBeans().ToString());
                    break;
                case "ChiliCheeseFriesButton":
                    Reciept.Items.Add(new ChiliCheeseFries().ToString());
                    break;
                case "CornDodgersButton":
                    Reciept.Items.Add(new CornDodgers().ToString());
                    break;
                case "PanDeCampoButton":
                    Reciept.Items.Add(new PanDeCampo().ToString());
                    break;
                default:
                    throw new NotImplementedException("Unknown side button clicked");
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
            Button b = (Button)sender;

            switch (b.Name)
            {
                case "CowboyCoffeeButton":
                    Reciept.Items.Add(new CowboyCoffee().ToString());
                    break;
                case "JerkedSodaButton":
                    Reciept.Items.Add(new JerkedSoda().ToString());
                    break;
                case "TexasTeaButton":
                    Reciept.Items.Add(new TexasTea().ToString());
                    break;
                case "WaterButton":
                    Reciept.Items.Add(new Water().ToString());
                    break;
                default:
                    throw new NotImplementedException("Unknown drink button clicked");
            }
        }
    }
}
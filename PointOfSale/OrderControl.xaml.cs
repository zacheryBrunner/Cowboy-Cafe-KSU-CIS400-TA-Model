/*
 * Author: Zachery Brunner
 * Class: OrderControl.xaml.cs
 * Purpose: Backend logic for the OrderControl.xaml class
 */
using System.Windows;
using System.Windows.Controls;
using CowboyCafe.Data;

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

        public void SwapScreen(FrameworkElement element)
        {
            Container.Child = element;
        }
    }
}
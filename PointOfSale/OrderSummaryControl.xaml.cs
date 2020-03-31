using CowboyCafe.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using PointOfSale.ExtensionMethods;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for OrderSummaryControl.xaml
    /// </summary>
    public partial class OrderSummaryControl : UserControl
    {


        public OrderSummaryControl()
        {
            InitializeComponent();
        }

        private void DeleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            Order o = (Order)DataContext;
            IOrderItem i = (IOrderItem)((Button)sender).DataContext;
            o.Remove(i);
        }

        private void OrderListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FrameworkElement elem;
            IOrderItem i = (IOrderItem)((ListBox)sender).SelectedItem;
            var orderControl = this.FindAncestor<OrderControl>();

            //Weird base case here where if you delete the last item while the customization screen is still up it crashes and dies
            if (i != null)
                elem = (FrameworkElement)i.screen;
            else
                elem = new MenuItemSelectionControl();

            orderControl?.SwapScreen(elem);
        }
    }
}
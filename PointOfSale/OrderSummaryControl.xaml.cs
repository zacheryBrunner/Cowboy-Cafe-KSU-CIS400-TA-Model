
using System.Windows;
using System.Windows.Controls;

using CowboyCafe.Data;
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
                elem = (FrameworkElement)i.Screen;
            else
                elem = new MenuItemSelectionControl();

            orderControl?.SwapScreen(elem);
        }
    }
}
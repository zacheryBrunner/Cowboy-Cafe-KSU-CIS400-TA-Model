/*
 * Author: Zachery Brunner
 * Class: SideSizeCustomization.xaml.cs
 * Purpose: Allows customization for any side's size
 */
using System;

using System.Windows;
using System.Windows.Controls;

using CowboyCafe.Data;
using CowboyCafe.Data.Sides;
using Size = CowboyCafe.Data.Enums.Size;

namespace PointOfSale.CustomizationScreens
{
    /// <summary>
    /// Interaction logic for SideSizeCustomization.xaml
    /// </summary>
    public partial class SideSizeCustomization : UserControl
    {
        /// <summary>
        /// This variable is used so I can notify the properties have changed
        /// </summary>
        private Order linkToOrder;

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="dc">Datacontext: This is the overall order so I can trigger the special properties for the order</param>
        public SideSizeCustomization(object dc)
        {
            linkToOrder = (Order)dc;
            InitializeComponent();
        }

        /// <summary>
        /// Filters which control was pressed and changes the holding state of the respective item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Side s;
            Size size;
            if(DataContext is ChiliCheeseFries)
                s = (ChiliCheeseFries)DataContext;
            else if(DataContext is CornDodgers)
                s = (CornDodgers)DataContext;
            else if(DataContext is PanDeCampo)
                s = (PanDeCampo)DataContext;
            else 
                s = (BakedBeans)DataContext;
      

            switch(((Button)sender).Name)
            {
                //Size Cases
                case "SmallButton":
                    size = Size.Small;
                    break;
                case "MediumButton":
                    size = Size.Medium;
                    break;
                case "LargeButton":
                    size = Size.Large;
                    break;
                default:
                    throw new NotImplementedException("Unknown Size Button Pressed");
            }
            linkToOrder.subtotalHelperFunction(s, size);
            linkToOrder.InvokePropertyChanged();
        }
    }
}
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

using PointOfSale.ExtensionMethods;

namespace PointOfSale.CustomizationScreens
{
    /// <summary>
    /// Interaction logic for SideSizeCustomization.xaml
    /// </summary>
    public partial class SideSizeCustomization : UserControl
    {
        /// <summary>
        /// Public constructor
        /// </summary>
        public SideSizeCustomization()
        {
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
            var orderControl = this.FindAncestor<OrderControl>();

            //Chili Cheese Fries
            if (DataContext is ChiliCheeseFries)
                s = (ChiliCheeseFries)DataContext;

            //Corn Dodgers
            else if (DataContext is CornDodgers)
                s = (CornDodgers)DataContext;

            //Pan De Campo
            else if (DataContext is PanDeCampo)
                s = (PanDeCampo)DataContext;

            //Baked beans
            else if (DataContext is BakedBeans)
                s = (BakedBeans)DataContext;

            //We don't know what it is.... Lets do nothing 
            else
                return;
      

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
            ((Order)orderControl.DataContext).subtotalHelperFunction(s, size);
            ((Order)orderControl.DataContext).InvokePropertyChanged();
        }
    }
}
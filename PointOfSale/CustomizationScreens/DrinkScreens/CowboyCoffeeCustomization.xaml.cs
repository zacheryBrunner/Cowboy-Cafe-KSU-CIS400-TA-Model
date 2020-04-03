/*
 * Author: Zachery Brunner
 * Class: CowboyCoffeeCustomization.xaml.cs
 * Purpose: Allows customization for the cowboy coffee drink
 */
using System.Windows.Controls;

using CowboyCafe.Data.Drinks;
using Size = CowboyCafe.Data.Enums.Size;

namespace PointOfSale.CustomizationScreens
{
    /// <summary>
    /// Interaction logic for CowboyCoffeeCustomization.xaml
    /// </summary>
    public partial class CowboyCoffeeCustomization : UserControl
    {        
        /// <summary>
        /// Public constructor
        /// </summary>
        public CowboyCoffeeCustomization()
        {
            InitializeComponent();
        }
    }
}
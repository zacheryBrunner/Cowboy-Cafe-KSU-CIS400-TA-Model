/* 
 * Author: Zachery Brunner
 * Class: RustlersRibs.cs
 * Purpose: Model for the Rustlers Ribs menu item
 *      Includes: Interactive logic for XAML pages using the INotifyPropertyChanged
 */
using System.Collections.Generic;
using System.ComponentModel;

namespace CowboyCafe.Data.Entrees
{
    public class RustlersRibs : Entree, INotifyPropertyChanged
    {
        /// <summary>
        /// This event will be invoked when a property is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Rustlers Ribs Price
        /// </summary>
        public override double Price { get { return EntreeInformation.RUSTLERS_RIBS_PRICE; } }

        /// <summary>
        /// Rustlers Ribs Calorie Count
        /// </summary>
        public override uint Calories { get { return EntreeInformation.RUSTLERS_RIBS_CALORIES; } }

        /// <summary>
        /// The special instructions for preparing the Rustler's Ribs 
        /// </summary>
        public override List<string> SpecialInstructions { get { return new List<string>(); } }

        /// <summary>
        /// Overrides the ToString method
        /// </summary>
        /// <returns>String representation of the class</returns>
        public override string ToString()
        {
            return "Rustler's Ribs";
        }
    }
}
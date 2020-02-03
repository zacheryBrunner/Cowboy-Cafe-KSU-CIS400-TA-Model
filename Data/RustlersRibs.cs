/* 
 * Author: Zachery Brunner
 * Class: RustlersRibs.cs
 * Purpose: Information about the menu item Rustlers Ribs
 */
using System.Collections.Generic;

namespace CowboyCafe.Data
{
    public class RustlersRibs : Entree
    {
        /// <summary>
        /// Rustlers Ribs Price
        /// </summary>
        public override double Price { get { return 7.50; } }

        /// <summary>
        /// Rustlers Ribs Calorie Count
        /// </summary>
        public override uint Calories { get { return 894; } }

        /// <summary>
        /// Preparation instructions for Rustler's Ribs 
        /// </summary>
        public override List<string> SpecialInstructions { get { return new List<string>(); } }
    }
}

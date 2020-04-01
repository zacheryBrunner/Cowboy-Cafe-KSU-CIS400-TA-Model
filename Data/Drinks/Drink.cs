 /*
 * Author: Zachery Brunner
 * Class: Drink.cs
 * Purpose: A base class representing a drink
 */
using System.Collections.Generic;
using CowboyCafe.Data.Enums;

namespace CowboyCafe.Data.Drinks
{
    public abstract class Drink : IOrderItem
    {
        /// <summary>
        /// Allows the reciept to bind to the ToString method
        /// </summary>
        public virtual string Name => ToString();
       
        /// <summary>
        /// The is the screen associated with the IOrderItem
        /// </summary>
        public virtual object Screen { get; set; }

        /// <summary>
        /// Size associated with the item
        /// </summary>
        public abstract Size Size { get; set; }

        /// <summary>
        /// Gets the price of the drink
        /// </summary>
        public abstract double Price { get; }

        /// <summary>
        /// Gets the calories of the drink
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// Used to represent whether ice should be included in the drink
        /// </summary>
        public abstract bool Ice { get; set; }

        /// <summary>
        /// Gets the ingredients of the drink
        /// </summary>
        public abstract List<string> SpecialInstructions { get; }
    }
}
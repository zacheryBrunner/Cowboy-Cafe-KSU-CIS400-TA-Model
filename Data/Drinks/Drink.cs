/*
 * Author: Zachery Brunner
 * Class: Drink.cs
 * Purpose: Base class for drinks served by the cowboy-cafe
 */
using System.Collections.Generic;
using CowboyCafe.Data.Enums;

namespace CowboyCafe.Data.Drinks
{
    public abstract class Drink : IOrderItem
    {
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

        /// <summary>
        /// Gets,sets the size of the drink, default is small
        /// </summary>  
        public virtual Size Size { get; set; } = Size.Small;
    }
}
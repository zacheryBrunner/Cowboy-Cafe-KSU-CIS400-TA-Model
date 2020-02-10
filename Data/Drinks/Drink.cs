/*
 * Author: Zachery Brunner
 * Class: Drink.cs
 * Purpose: Base class for drinks served by the cowboy-cafe
 */
using System.Collections.Generic;
using CowboyCafe.Data.Enums;

namespace CowboyCafe.Data.Drinks
{
    public abstract class Drink
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
        /// Gets the ingredients of the drink
        /// </summary>
        public abstract List<string> Ingredients { get; }

        /// <summary>
        /// Gets the size of the drink, default is small
        /// </summary>
        public virtual Size Size { get; set; } = Size.Small;

        /// <summary>
        /// Used to represent whether ice should be included in the drink
        /// </summary>
        public bool Ice = true;
    }
}
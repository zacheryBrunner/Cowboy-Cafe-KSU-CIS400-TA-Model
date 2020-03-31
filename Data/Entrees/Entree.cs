/*
 * Author: Zachery Brunner
 * Class: Entree.cs
 * Purpose: A base class representing an entree
 */
using System.Collections.Generic;

namespace CowboyCafe.Data.Entrees
{
    public abstract class Entree : IOrderItem
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
        /// Gets the price of the side
        /// </summary>
        public abstract double Price { get; }

        /// <summary>
        /// Gets the calories of the entree
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// Gets the special instructions for the entree
        /// </summary>
        public abstract List<string> SpecialInstructions { get; }
    }
}

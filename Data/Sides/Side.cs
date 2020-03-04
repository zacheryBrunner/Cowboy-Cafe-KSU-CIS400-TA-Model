/*
 * Author: Zachery Brunner
 * Class: Side.cs
 * Purpose: Base class for sides served by the cowboy-cafe
 */
using CowboyCafe.Data.Enums;
using System.Collections.Generic;

namespace CowboyCafe.Data.Sides
{
    /// <summary>
    /// A base class representing a side
    /// </summary>
    public abstract class Side : IOrderItem
    {
        /// <summary>
        /// Gets the size of the side
        /// </summary>
        public virtual Size Size { get; set; }

        /// <summary>
        /// Gets the price of the side
        /// </summary>
        public abstract double Price { get; }

        /// <summary>
        /// Gets the calories of the entree
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// Special instructions for sides should we ever need to add some
        /// </summary>
        public List<string> SpecialInstructions { get { return new List<string>(); } }
    }
}
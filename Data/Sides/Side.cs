/*
 * Author: Zachery Brunner
 * Class: Side.cs
 * Purpose: Base class for sides served by the cowboy-cafe
 */
using CowboyCafe.Data.Enums;

namespace CowboyCafe.Data.Sides
{
    /// <summary>
    /// A base class representing a side
    /// </summary>
    public abstract class Side
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
    }
}
/*
 * Author: Zachery Brunner
 * Class: Side.cs
 * Purpose: A base class representing an side
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
        /// Allows the reciept to bind to the ToString method
        /// </summary>
        public virtual string Name => ToString();
        
        /// <summary>
        /// The is the screen associated with the IOrderItem
        /// </summary>
        public virtual object Screen { get; set; }
        
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
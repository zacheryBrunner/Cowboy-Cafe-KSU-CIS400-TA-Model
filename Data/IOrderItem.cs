/* Author: Zachery Brunner
 * Class: IOrderItem.cs
 * Purpose: This interface is used to standardize the items that will be ordered
 */
using System.Collections.Generic;

namespace CowboyCafe.Data
{
    /// <summary>
    /// Interface for all items on the cowboy cafe menu
    /// </summary>
    public interface IOrderItem
    {
        /// <summary>
        /// Allows the reciept to bind to the ToString method
        /// </summary>
        public virtual string Name => ToString();

        /// <summary>
        /// The is the screen associated with the IOrderItem
        /// </summary>
        public object Screen { get; set; }

        /// <summary>
        /// Gets the price of the item
        /// </summary>
        public double Price { get; }

        /// <summary>
        /// Gets the calories of the entree
        /// </summary>
        public uint Calories { get; }

        /// <summary>
        /// Gets the list of special instructions for the current item
        /// </summary>
        public List<string> SpecialInstructions { get; }
    }
}
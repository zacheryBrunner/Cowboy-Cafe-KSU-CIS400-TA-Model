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
        /// Gets the price of the item
        /// </summary>
        public double Price { get; }


        /// <summary>
        /// Gets the list of special instructions for the current item
        /// </summary>
        List<string> SpecialInstructions { get; }
    }
}
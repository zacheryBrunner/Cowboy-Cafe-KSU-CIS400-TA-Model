/*
 * Author: Zachery Brunner
 * Class: Water.cs
 * Purpose: A drink option offered by the cowboy cafe
 */
using System.Collections.Generic;

namespace CowboyCafe.Data.Drinks
{
    public class Water : Drink
    {
        /// <summary>
        /// Should the drink be served with Lemon?
        /// </summary>
        public bool Lemon { get; set; } = false;

        /// <summary>
        /// Used to represent if the drink should be served with ice
        /// </summary>
        public override bool Ice { get; set; } = true;

        /// <summary>
        /// The price of the drink
        /// </summary>
        public override double Price { get { return DrinkInformation.WATER_PRICE; } }

        /// <summary>
        /// The number of calories the drink has
        /// </summary>
        public override uint Calories { get { return DrinkInformation.WATER_CALORIES; } }

        /// <summary>
        /// Creates a list of special instructions for the water
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (Lemon) instructions.Add("Add Lemon");
                if (!Ice) instructions.Add("Hold Ice");
                return instructions;
            }
        }

        /// <summary>
        /// Overrides the toString method
        /// </summary>
        /// <returns>String representation of the class with the size</returns>
        public override string ToString()
        {
            return Size.ToString() + " Water";
        }
    }
}
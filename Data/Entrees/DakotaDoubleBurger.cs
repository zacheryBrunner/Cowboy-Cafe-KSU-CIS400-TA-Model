/*
 * Author: Zachery Brunner
 * File: DakotaDoubleBurger.cs
 * Purpose: Information about the menu item Dakota Double Burger
 */
using System.Collections.Generic;

namespace CowboyCafe.Data.Entrees
{
    public class DakotaDoubleBurger : Entree
    {
        /// <summary>
        /// Dakota Double Burger Price
        /// </summary>
        public override double Price { get { return EntreeInformation.DAKOTA_DOUBLE_PRICE; } }

        /// <summary>
        /// Dakota Double Burger Calorie Count
        /// </summary>
        public override uint Calories { get { return EntreeInformation.DAKOTA_DOUBLE_CALORIES; } }

        /// <summary>
        /// Serve bread with Dakota Double Burger?
        /// </summary>
        public bool Bun { get; set; } = true;

        /// <summary>
        /// Serve ketchup with Dakota Double Burger?
        /// </summary>
        public bool Ketchup { get; set; } = true;

        /// <summary>
        /// Serve mustard with Dakota Double Burger?
        /// </summary>
        public bool Mustard { get; set; } = true;

        /// <summary>
        /// Serve pickle with Dakota Double Burger?
        /// </summary>
        public bool Pickle { get; set; } = true;

        /// <summary>
        /// Serve cheese with Dakota Double Burger?
        /// </summary>
        public bool Cheese { get; set; } = true;
        /// <summary>
        /// Serve tomato with Dakota Double Burger?
        /// </summary>
        public bool Tomato { get; set; } = true;

        /// <summary>
        /// Serve pickle with Dakota Double Burger?
        /// </summary>
        public bool Lettuce { get; set; } = true;

        /// <summary>
        /// Serve pickle with Dakota Double Burger?
        /// </summary>
        public bool Mayo { get; set; } = true;

        /// <summary>
        /// Preparation instructions for Dakota Double Burger
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (!Bun) instructions.Add("hold bun");
                if (!Ketchup) instructions.Add("hold ketchup");
                if (!Mustard) instructions.Add("hold mustard");
                if (!Pickle) instructions.Add("hold pickle");
                if (!Cheese) instructions.Add("hold cheese");
                if (!Tomato) instructions.Add("hold tomato");
                if (!Lettuce) instructions.Add("hold lettuce");
                if (!Mayo) instructions.Add("hold mayo");
                return instructions;
            }
        }

        /// <summary>
        /// Overrides the toString method
        /// </summary>
        /// <returns>String representation of the class</returns>

        public override string ToString()
        {
            return "Dakota Double Burger";
        }
    }
}
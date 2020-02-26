/* 
 * Author: Zachery Brunner
 * Class: TexasTripleBurger.cs
 * Purpose: Information about the menu item Texas Triple Burger
 */
using System.Collections.Generic;

namespace CowboyCafe.Data.Entrees
{
    public class TexasTripleBurger : Entree
    {
        /// <summary>
        /// Texas Triple Burger Price
        /// </summary>
        public override double Price { get { return EntreeInformation.TEXAS_TRIPLE_PRICE; } }

        /// <summary>
        /// Texas Triple Burger Calorie Count
        /// </summary>
        public override uint Calories { get { return EntreeInformation.TEXAS_TRIPLE_CALORIES; } }

        /// <summary>
        /// Serve bread with Texas Triple Burger?
        /// </summary>
        public bool Bun { get; set; } = true;

        /// <summary>
        /// Serve ketchup with Texas Triple Burger?
        /// </summary>
        public bool Ketchup { get; set; } = true;

        /// <summary>
        /// Serve mustard with Texas Triple Burger?
        /// </summary>
        public bool Mustard { get; set; } = true;

        /// <summary>
        /// Serve pickle with Texas Triple Burger?
        /// </summary>
        public bool Pickle { get; set; } = true;

        /// <summary>
        /// Serve cheese with Texas Triple Burger?
        /// </summary>
        public bool Cheese { get; set; } = true;
        /// <summary>
        /// Serve tomato with Texas Triple Burger?
        /// </summary>
        public bool Tomato { get; set; } = true;

        /// <summary>
        /// Serve pickle with Texas Triple Burger?
        /// </summary>
        public bool Lettuce { get; set; } = true;

        /// <summary>
        /// Serve pickle with Texas Triple Burger?
        /// </summary>
        public bool Mayo { get; set; } = true;

        /// <summary>
        /// Serve bacon with Texas Triple Burger?
        /// </summary>
        public bool Bacon { get; set; } = true;
        
        /// <summary>
        /// Serve egg with Texas Triple Burger?
        /// </summary>
        public bool Egg { get; set; } = true;
        
        /// <summary>
        /// Preparation instructions for Texas Triple Burger
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
                if (!Bacon) instructions.Add("hold bacon");
                if (!Egg) instructions.Add("hold egg");
                return instructions;
            }
        }

        /// <summary>
        /// Overrides the toString method
        /// </summary>
        /// <returns>String representation of the class</returns>
        public override string ToString()
        {
            return "Texas Triple Burger";
        }
    }
}
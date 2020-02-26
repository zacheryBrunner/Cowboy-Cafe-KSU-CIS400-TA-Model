/* 
 * Author: Zachery Brunner
 * Class: Trailburger.cs
 * Purpose: Information about the menu item Trailburger
 */
using System.Collections.Generic;

namespace CowboyCafe.Data.Entrees
{
    public class TrailBurger : Entree
    {
        /// <summary>
        /// Trailburger Price
        /// </summary>
        public override double Price { get { return EntreeInformation.TRAIL_BURGER_PRICE; } }

        /// <summary>
        /// Trailburger Calorie Count
        /// </summary>
        public override uint Calories { get { return EntreeInformation.TRAIL_BURGER_CALORIES; } }

        /// <summary>
        /// Serve bread with Trailburger?
        /// </summary>
        public bool Bun { get; set; } = true;

        /// <summary>
        /// Serve ketchup with Trailburger?
        /// </summary>
        public bool Ketchup { get; set; } = true;

        /// <summary>
        /// Serve mustard with Trailburger?
        /// </summary>
        public bool Mustard { get; set; } = true;

        /// <summary>
        /// Serve pickle with Trailburger?
        /// </summary>
        public bool Pickle { get; set; } = true;

        /// <summary>
        /// Serve cheese with Trailburger?
        /// </summary>
        public bool Cheese { get; set; } = true;
        
        /// <summary>
        /// Preparation instructions for Trailburger
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
                return instructions;
            }
        }

        /// <summary>
        /// Overrides the toString method
        /// </summary>
        /// <returns>String representation of the class</returns>
        public override string ToString()
        {
            return "Trail Burger";
        }
    }
}
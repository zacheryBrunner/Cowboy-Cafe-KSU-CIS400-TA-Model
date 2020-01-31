/* 
 * Author: Zachery Brunner
 * Class: Trailburger.cs
 * Purpose: Information about the menu item Trailburger
 */
using System.Collections.Generic;

namespace CowboyCafe.Data
{
    public class TrailBurger
    {
        /// <summary>
        /// Trailburger Price
        /// </summary>
        public double Price { get { return 4.50; } }

        /// <summary>
        /// Trailburger Calorie Count
        /// </summary>
        public uint Calories { get { return 288; } }

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
        public List<string> SpecialInstructions
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
    }
}
/* 
 * Author: Zachery Brunner
 * Class: PecosPulledPork.cs
 * Purpose: Information about the menu item Pecos Pulled Pork
 */
using System.Collections.Generic;

namespace CowboyCafe.Data
{
    public class PecosPulledPork
    {
        /// <summary>
        /// Pecos Pulled Pork Price
        /// </summary>
        public double Price { get { return 5.88; } }

        /// <summary>
        /// Pecos Pulled Pork Calorie Count
        /// </summary>
        public uint Calories { get { return 528; } }

        /// <summary>
        /// Serve bread with Pecos Pulled Pork?
        /// </summary>
        public bool Bread { get; set; } = true;

        /// <summary>
        /// Serve pickle with Pecos Pulled Pork?
        /// </summary>
        public bool Pickle { get; set; } = true;

        /// <summary>
        /// Preparation instructions for Pecos Pulled Pork
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (!Pickle) instructions.Add("hold pickle");
                if (!Bread) instructions.Add("hold bread");
                return instructions;
            }
        }
    }
}
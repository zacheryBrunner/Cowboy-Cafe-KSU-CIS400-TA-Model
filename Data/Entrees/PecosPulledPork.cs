/* 
 * Author: Zachery Brunner
 * Class: PecosPulledPork.cs
 * Purpose: Information about the menu item Pecos Pulled Pork
 */
using System.Collections.Generic;

namespace CowboyCafe.Data.Entrees
{
    public class PecosPulledPork : Entree
    {
        /// <summary>
        /// Pecos Pulled Pork Price
        /// </summary>
        public override double Price { get { return EntreeInformation.PECOS_PULLED_PORK_PRICE; } }

        /// <summary>
        /// Pecos Pulled Pork Calorie Count
        /// </summary>
        public override uint Calories { get { return EntreeInformation.PECOS_PULLED_PORK_CALORIES; } }

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
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (!Pickle) instructions.Add("hold pickle");
                if (!Bread) instructions.Add("hold bread");
                return instructions;
            }
        }

        /// <summary>
        /// Overrides the toString method
        /// </summary>
        /// <returns>String representation of the class</returns>
        public override string ToString()
        {
            return "Pecos Pulled Pork";
        }
    }
}
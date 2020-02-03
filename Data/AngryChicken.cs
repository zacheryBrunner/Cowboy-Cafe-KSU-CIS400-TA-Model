/* 
 * Author: Zachery Brunner
 * Class: AngryChicken.cs
 * Purpose: Information about the menu item Angry Chicken
 */
 using System.Collections.Generic;

namespace CowboyCafe.Data
{
    public class AngryChicken : Entree
    {
        /// <summary>
        /// Angry Chicken Price
        /// </summary>
        public override double Price { get { return 5.99; } }

        /// <summary>
        /// Angry Chicken Calorie Count
        /// </summary>
        public override uint Calories { get { return 190; } }

        /// <summary>
        /// Serve bread with Angry Chicken?
        /// </summary>
        public bool Bread { get; set; } = true;

        /// <summary>
        /// Serve pickle with Angry Chicken?
        /// </summary>
        public bool Pickle { get; set; } = true;

        /// <summary>
        /// Preparation instructions for Angry Chicken


        /// <summary>
        /// The special instructions for preparing the angry chicken
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
    }
}

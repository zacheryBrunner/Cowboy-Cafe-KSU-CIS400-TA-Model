/*
 * Author: Nathan Bean
 * Editor: Zachery Brunner
 * File: CowpokeChili.cs
 * Purpose: Information about the menu item CowpokeChili
 */
using System.Collections.Generic;

namespace CowboyCafe.Data.Entrees
{
    public class CowpokeChili : Entree
    {
        /// <summary>
        /// CowpokeChili Price
        /// </summary>
        public override double Price { get { return EntreeInformation.COWPOKE_CHILI_PRICE; } }

        /// <summary>
        /// CowpokeChili Calorie Count
        /// </summary>
        public override uint Calories { get { return EntreeInformation.COWPOKE_CHILI_CALORIES; } }

        /// <summary>
        /// Serve cheese with CowpokeChili?
        /// </summary>
        public bool Cheese { get; set; } = true;

        /// <summary>
        /// Serve sourCream with CowpokeChili?
        /// </summary>
        public bool SourCream { get; set; } = true;

        /// <summary>
        /// Serve greenOnions with CowpokeChili?
        /// </summary>
        public bool GreenOnions { get; set; } = true;

        /// <summary>
        /// Serve tortillaStrips with CowpokeChili?
        /// </summary>
        public bool TortillaStrips { get; set; } = true;

        /// <summary>
        /// Perparation instructions for CowpokeChili
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (!Cheese) instructions.Add("hold cheese");
                if (!SourCream) instructions.Add("hold sour cream");
                if (!GreenOnions) instructions.Add("hold green onions");
                if (!TortillaStrips) instructions.Add("hold tortilla strips");
                return instructions;
            }
        }

        /// <summary>
        /// Overrides the toString method
        /// </summary>
        /// <returns>String representation of the class</returns>
        public override string ToString()
        {
            return "Cowpoke Chili";
        }
    }
}
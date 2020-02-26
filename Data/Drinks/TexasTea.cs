/*
 * Author: Zachery Brunner
 * Class: TexasTea.cs
 * Purpose: A drink option offered by the cowboy cafe
 */
using System;
using System.Collections.Generic;
using CowboyCafe.Data.Enums;

namespace CowboyCafe.Data.Drinks
{
    public class TexasTea : Drink
    {
        /// <summary>
        /// Should Ice be included in the Texas Tea
        /// </summary>
        public override bool Ice { get; set; } = true;

        /// <summary>
        /// Should the Texas Tea be sweet
        /// </summary>
        public bool Sweet { get; set; } = true;

        /// <summary>
        /// Should the Texas Tea come with a lemon
        /// </summary>
        public bool Lemon { get; set; } = false;

        /// <summary>
        /// Price property for Texas Tea
        /// </summary>
        public override double Price
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return DrinkInformation.SMALL_TEXAS_TEA_PRICE;
                    case Size.Medium:
                        return DrinkInformation.MEDIUM_TEXAS_TEA_PRICE;
                    case Size.Large:
                        return DrinkInformation.LARGE_TEXAS_TEA_PRICE;
                    default:
                        throw new NotImplementedException("Unknown size");
                }
            }
        }

        /// <summary>
        /// Calories property for Texas Tea
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint calories;
                switch (Size)
                {
                    case Size.Small:
                        calories = DrinkInformation.SMALL_TEXAS_TEA_CALORIES;
                        break;
                    case Size.Medium:
                        calories = DrinkInformation.MEDIUM_TEXAS_TEA_CALORIES;
                        break;
                    case Size.Large:
                        calories = DrinkInformation.LARGE_TEXAS_TEA_CALORIES;
                        break;
                    default:
                        throw new NotImplementedException("Unknown size");
                }
                if (Sweet)
                    return calories;
                else
                    return calories / 2;
            }
        }

        /// <summary>
        /// Creates a list of special instructions for the texas tea
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (!Ice) instructions.Add("Hold Ice");
                if (Lemon) instructions.Add("Add Lemon");
                return instructions;
            }
        }

        public override string ToString()
        {
            if (Sweet) return Size.ToString() + " Texas Sweet Tea";
            else return Size.ToString() + " Texas Plain Tea";
        }
    }
}
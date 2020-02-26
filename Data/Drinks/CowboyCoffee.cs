/*
 * Author: Zachery Brunner
 * Class: CowboyCoffee.cs
 * Purpose: Represents a drink option that the cowboy cafe offers
 */
using System;
using System.Collections.Generic;
using CowboyCafe.Data.Enums;

namespace CowboyCafe.Data.Drinks
{
    public class CowboyCoffee : Drink
    {
        /// <summary>
        /// Special property for the cowboy coffee to see if space needs to be left
        /// </summary>
        public bool RoomForCream { get; set; } = false;
        
        /// <summary>
        /// Special property for the cowboy coffee to see if the drink should be decaf
        /// </summary>
        public bool Decaf { get; set; } = false;

        /// <summary>
        /// Used to represent if the drink should be served with ice
        /// </summary>
        public override bool Ice { get; set; } = false;

        /// <summary>
        /// Gets the price of the cowboy coffee using the size
        /// </summary>
        public override double Price
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return DrinkInformation.SMALL_COWBOY_COFFEE_PRICE;
                    case Size.Medium:
                        return DrinkInformation.MEDIUM_COWBOY_COFFEE_PRICE;
                    case Size.Large:
                        return DrinkInformation.LARGE_COWBOY_COFFEE_PRICE;
                    default:
                        throw new NotImplementedException("Unknown size");
                }
            }
        }

        /// <summary>
        /// Gets the calories of the cowboy coffee using the size
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return DrinkInformation.SMALL_COWBOY_COFFEE_CALORIES;
                    case Size.Medium:
                        return DrinkInformation.MEDIUM_COWBOY_COFFEE_CALORIES;
                    case Size.Large:
                        return DrinkInformation.LARGE_COWBOY_COFFEE_CALORIES;
                    default:
                        throw new NotImplementedException("Unknown size");
                }
            }
        }

        /// <summary>
        /// Creates a list of special instructions for the cowboy coffee
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (Ice) instructions.Add("Add Ice");
                if (RoomForCream) instructions.Add("Room for Cream");
                return instructions;
            }
        }

        /// <summary>
        /// Overrides the toString method
        /// </summary>
        /// <returns>String representation of the class with the size</returns>
        public override string ToString()
        {
            if (Decaf) return Size.ToString() + " Decaf Cowboy Coffee";
            else return Size.ToString() + " Cowboy Coffee";
        }
    }
}
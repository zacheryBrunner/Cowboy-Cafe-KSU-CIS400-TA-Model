/*
 * Author: Zachery Brunner
 * Class: JerkedSoda.cs
 * Purpose: Represents a drink option that the cowboy cafe has
 */
using System;
using System.Collections.Generic;
using CowboyCafe.Data.Enums;

namespace CowboyCafe.Data.Drinks
{
    public class JerkedSoda : Drink
    {
        /// <summary>
        /// Flavor enum used to determine the flavor the drink should be
        /// </summary>
        public SodaFlavor Flavor { get; set; } = SodaFlavor.CreamSoda;

        /// <summary>
        /// Used to represent if the drink should be served with ice
        /// </summary>
        public override bool Ice { get; set; } = true;

        /// <summary>
        /// Returns the price of the size of the jerked soda
        /// </summary>
        public override double Price 
        { 
            get
            {
                switch(Size)
                {
                    case Size.Small:
                        return DrinkInformation.SMALL_JERKED_SODA_PRICE;
                    case Size.Medium:
                        return DrinkInformation.MEDIUM_JERKED_SODA_PRICE;
                    case Size.Large:
                        return DrinkInformation.LARGE_JERKED_SODA_PRICE;
                    default:
                        throw new NotImplementedException("Unknown size");
                }
            }
        }

        /// <summary>
        /// Returns the calories for the size of the drink
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch(Size)
                {
                    case Size.Small:
                        return DrinkInformation.SMALL_JERKED_SODA_CALORIES;
                    case Size.Medium:
                        return DrinkInformation.MEDIUM_JERKED_SODA_CALORIES;
                    case Size.Large:
                        return DrinkInformation.LARGE_JERKED_SODA_CALORIES;
                    default:
                        throw new NotImplementedException("Unknown size");
                }
            }
        }

        /// <summary>
        /// Creates a list of special instructions for the Jerked soda
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                if (!Ice) return new List<string>() { "Hold Ice" };
                else return new List<string>();
            }
        }

        /// <summary>
        /// Overrides the toString method
        /// </summary>
        /// <returns>String representation of the class with the size and flavor</returns>
        public override string ToString()
        {
            string flavor;
            switch(Flavor)
            {
                case SodaFlavor.BirchBeer:
                    flavor = "Birch Beer";
                    break;
                case SodaFlavor.CreamSoda:
                    flavor = "Cream Soda";
                    break;
                case SodaFlavor.OrangeSoda:
                    flavor = "Orange Soda";
                    break;
                case SodaFlavor.RootBeer:
                    flavor = "Root Beer";
                    break;
                case SodaFlavor.Sarsparilla:
                    flavor = "Sarsparilla";
                    break;
                default:
                    throw new NotImplementedException("Unknown flavor");
            }
            return Size.ToString() + " " + flavor + " Jerked Soda";
        }
    }
}
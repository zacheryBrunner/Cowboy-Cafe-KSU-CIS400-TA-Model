/*
 * Author: Zachery Brunner
 * Class: ChiliCheeseFries.cs
 * Purpose: A blueprint of the side ChiliCheeseFries side for the cowboy diner
 */
using System;
using CowboyCafe.Data.Enums;

namespace CowboyCafe.Data.Sides
{
    public class ChiliCheeseFries : Side
    {
        /// <summary>
        /// Returns the price for the ChiliCheeseFries side depending on the size of the entree
        /// </summary>
        public override double Price
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return SideInformation.SMALL_CHILI_CHEESE_FRIES_PRICE;
                    case Size.Medium:
                        return SideInformation.MEDIUM_CHILI_CHEESE_FRIES_PRICE;
                    case Size.Large:
                        return SideInformation.LARGE_CHILI_CHEESE_FRIES_PRICE;
                    default:
                        throw new NotImplementedException("Unknown size");
                }
            }
        }

        /// <summary>
        /// Returns the calories for the ChiliCheeseFries side depending on the size of the entree
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch(Size)
                {
                    case Size.Small:
                        return SideInformation.SMALL_CHILI_CHEESE_FRIES_CALORIES;
                    case Size.Medium:
                        return SideInformation.MEDIUM_CHILI_CHEESE_FRIES_CALORIES;
                    case Size.Large:
                        return SideInformation.LARGE_CHILI_CHEESE_FRIES_CALORIES;
                    default:
                        throw new NotImplementedException("Unknown size");

                }
            }
        }

        /// <summary>
        /// Overrides the toString method
        /// </summary>
        /// <returns>String representation of the class with the size</returns>
        public override string ToString()
        {
            return Size.ToString() + " Chili Cheese Fries";
        }
    }
}
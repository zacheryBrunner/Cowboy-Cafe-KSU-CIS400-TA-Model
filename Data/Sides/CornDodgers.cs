/*
 * Author: Zachery Brunner
 * Class: CornDodgers.cs
 * Purpose: A blueprint of the side CornDodgers side for the cowboy diner
 */
using System;
using CowboyCafe.Data.Enums;

namespace CowboyCafe.Data.Sides
{
    public class CornDodgers : Side
    {
        /// <summary>
        /// Returns the price for the CornDodgers side depending on the size of the entree
        /// </summary>
        public override double Price
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return SideInformation.SMALL_CORN_DODGERS_PRICE;
                    case Size.Medium:
                        return SideInformation.MEDIUM_CORN_DODGERS_PRICE;
                    case Size.Large:
                        return SideInformation.LARGE_CORN_DODGERS_PRICE;
                    default:
                        throw new NotImplementedException("Unknown size");
                }
            }
        }

        /// <summary>
        /// Returns the calories for the CornDodgers side depending on the size of the entree
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return SideInformation.SMALL_CORN_DODGERS_CALORIES;
                    case Size.Medium:
                        return SideInformation.MEDIUM_CORN_DODGERS_CALORIES;
                    case Size.Large:
                        return SideInformation.LARGE_CORN_DODGERS_CALORIES;
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
            return Size.ToString() + " Corn Dodgers";
        }
    }
}
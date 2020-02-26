/*
 * Author: Zachery Brunner
 * Class: PanDeCampo.cs
 * Purpose: A blueprint of the side PanDeCampo side for the cowboy diner
 */
using System;
using CowboyCafe.Data.Enums;

namespace CowboyCafe.Data.Sides
{
    public class PanDeCampo : Side
    {
        /// <summary>
        /// Returns the price for the PanDeCampo side depending on the size of the entree
        /// </summary>
        public override double Price
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return SideInformation.SMALL_PANDECAMPO_PRICE;
                    case Size.Medium:
                        return SideInformation.MEDIUM_PANDECAMPO_PRICE;
                    case Size.Large:
                        return SideInformation.LARGE_PANDECAMPO_PRICE;
                    default:
                        throw new NotImplementedException("Unknown size");
                }
            }
        }

        /// <summary>
        /// Returns the calories for the PanDeCampo side depending on the size of the entree
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return SideInformation.SMALL_PANDECAMPO_CALORIES;
                    case Size.Medium:
                        return SideInformation.MEDIUM_PANDECAMPO_CALORIES;
                    case Size.Large:
                        return SideInformation.LARGE_PANDECAMPO_CALORIES;
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
            return Size.ToString() + " Pan de Campo";
        }
    }
}
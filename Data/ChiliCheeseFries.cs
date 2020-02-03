/*
 * Author: Zachery Brunner
 * Class: ChiliCheeseFries.cs
 * Purpose: A blueprint of the side ChiliCheeseFries side for the cowboy diner
 */
using System;

namespace CowboyCafe.Data
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
                        return 1.99;
                    case Size.Medium:
                        return 2.99;
                    case Size.Large:
                        return 3.99;
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
                        return 433;
                    case Size.Medium:
                        return 524;
                    case Size.Large:
                        return 610;
                    default:
                        throw new NotImplementedException("Unknown size");

                }
            }
        }
    }
}
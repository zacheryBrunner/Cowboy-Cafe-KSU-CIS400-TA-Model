/*
 * Author: Zachery Brunner
 * Class: BakedBeans.cs
 * Purpose: A blueprint of the side BakedBeans side for the cowboy diner
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    public class BakedBeans : Side
    {
        /// <summary>
        /// Returns the price for the BakedBeans side depending on the size of the entree
        /// </summary>
        public override double Price
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 1.59;
                    case Size.Medium:
                        return 1.79;
                    case Size.Large:
                        return 1.99;
                    default:
                        throw new NotImplementedException("Unknown size");
                }
            }
        }

        /// <summary>
        /// Returns the calories for the BakedBeans side depending on the size of the entree
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 312;
                    case Size.Medium:
                        return 378;
                    case Size.Large:
                        return 410;
                    default:
                        throw new NotImplementedException("Unknown size");

                }
            }
        }
    }
}
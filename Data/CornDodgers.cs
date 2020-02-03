/*
 * Author: Zachery Brunner
 * Class: CornDodgers.cs
 * Purpose: A blueprint of the side CornDodgers side for the cowboy diner
 */
using System;

namespace CowboyCafe.Data
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
        /// Returns the calories for the CornDodgers side depending on the size of the entree
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 512;
                    case Size.Medium:
                        return 685;
                    case Size.Large:
                        return 717;
                    default:
                        throw new NotImplementedException("Unknown size");
                }
            }
        }
    }
}
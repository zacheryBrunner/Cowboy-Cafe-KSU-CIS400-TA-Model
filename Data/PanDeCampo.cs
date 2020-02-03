/*
 * Author: Zachery Brunner
 * Class: PanDeCampo.cs
 * Purpose: A blueprint of the side PanDeCampo side for the cowboy diner
 */
using System;

namespace CowboyCafe.Data
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
        /// Returns the calories for the PanDeCampo side depending on the size of the entree
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return 227;
                    case Size.Medium:
                        return 269;
                    case Size.Large:
                        return 367;
                    default:
                        throw new NotImplementedException("Unknown size");

                }
            }
        }
    }
}

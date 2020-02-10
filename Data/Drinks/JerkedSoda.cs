using System;
using System.Collections.Generic;
using System.Text;
using CowboyCafe.Data.Enums;

namespace CowboyCafe.Data.Drinks
{
    public class JerkedSoda : Drink
    {
        public DrinkFlavors Flavor { get; set; } = DrinkFlavors.CreamSoda;
    
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

        public override List<string> Ingredients
        {
            get
            {
                if (!Ice) return new List<string>() { "hold ice" };
                else return new List<string>();
            }
        }
    }
}

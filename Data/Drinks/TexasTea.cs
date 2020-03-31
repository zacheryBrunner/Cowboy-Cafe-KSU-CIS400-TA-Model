/*
 * Author: Zachery Brunner
 * Class: TexasTea.cs
 * Purpose: Model for the Texas Tea menu item
 *      Includes: Interactive logic for XAML pages using the INotifyPropertyChanged
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;

using CowboyCafe.Data.Enums;

namespace CowboyCafe.Data.Drinks
{
    public class TexasTea : Drink, INotifyPropertyChanged
    {
        /// <summary>
        /// This event will be invoked when a property is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Texas Tea Price - Based on size
        /// </summary>
        public override double Price
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return DrinkInformation.SMALL_TEXAS_TEA_PRICE;
                    case Size.Medium:
                        return DrinkInformation.MEDIUM_TEXAS_TEA_PRICE;
                    case Size.Large:
                        return DrinkInformation.LARGE_TEXAS_TEA_PRICE;
                    default:
                        throw new NotImplementedException("Unknown size");
                }
            }
        }

        /// <summary>
        /// Texas Tea Calorie Count - Based on size
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint calories;
                switch (Size)
                {
                    case Size.Small:
                        calories = DrinkInformation.SMALL_TEXAS_TEA_CALORIES;
                        break;
                    case Size.Medium:
                        calories = DrinkInformation.MEDIUM_TEXAS_TEA_CALORIES;
                        break;
                    case Size.Large:
                        calories = DrinkInformation.LARGE_TEXAS_TEA_CALORIES;
                        break;
                    default:
                        throw new NotImplementedException("Unknown size");
                }
                if (Sweet)
                    return calories;
                else
                    return calories / 2;
            }
        }

        /// <summary>
        /// Private backing variable for the Ice property
        /// </summary>
        private bool ice = true;

        /// <summary>
        /// Interactive logic for if ice should be included
        ///     with the texas tea   
        ///     
        /// Updates the Ice and the Special Instruction list on user click
        /// </summary>
        public override bool Ice
        {
            get
            {
                return ice;
            }
            set
            {
                ice = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ice"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
            }
        }

        /// <summary>
        /// Private backing variable for the Sweet property
        /// </summary>
        private bool sweet = true;

        /// <summary>
        /// Interactive logic for if sweet should be included
        ///     with the cowboy coffee   
        ///     
        /// Updates the Sweet and the Name on user click
        /// </summary>
        public bool Sweet
        {
            get
            {
                return sweet;
            }
            set
            {
                sweet = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Sweet"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }

        /// <summary>
        /// Private backing variable for the Lemon property
        /// </summary>
        private bool lemon = false;

        /// <summary>
        /// Interactive logic for if lemon should be included
        ///     with the cowboy coffee   
        ///     
        /// Updates the Lemon and the Special Instruction list on user click
        /// </summary>
        public bool Lemon
        {
            get
            {
                return lemon;
            }
            set
            {
                lemon = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Lemon"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
            }
        }

        /// <summary>
        /// The special instructions for preparing the texas tea
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (!Ice) instructions.Add("Hold Ice");
                if (Lemon) instructions.Add("Add Lemon");
                return instructions;
            }
        }

        /// <summary>
        /// Overrides the ToString method
        /// </summary>
        /// <returns>String representation of the class with the size</returns>
        public override string ToString()
        {
            if (Sweet) return Size.ToString() + " Texas Sweet Tea";
            return Size.ToString() + " Texas Plain Tea";
        }
    }
}
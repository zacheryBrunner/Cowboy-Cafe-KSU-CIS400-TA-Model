/*
 * Author: Zachery Brunner
 * Class: Water.cs
 * Purpose: Model for the Cowboy Coffee menu item
 *      Includes: Interactive logic for XAML pages using the INotifyPropertyChanged
 */
using System.Collections.Generic;
using System.ComponentModel;

using CowboyCafe.Data.Enums;

namespace CowboyCafe.Data.Drinks
{
    public class Water : Drink, INotifyPropertyChanged
    {
        /// <summary>
        /// This event will be invoked when a property is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Water Price
        /// </summary>
        public override double Price { get { return DrinkInformation.WATER_PRICE; } }

        /// <summary>
        /// Water Calories
        /// </summary>
        public override uint Calories { get { return DrinkInformation.WATER_CALORIES; } }

        /// <summary>
        /// Private backing variable for the Size Property
        /// </summary>
        private Size size = Size.Small;

        /// <summary>
        /// Gets,sets the size of the drink
        /// </summary>  
        public override Size Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }

        /// <summary>
        /// Private backing variable for the Ice property
        /// </summary>
        private bool ice = true;

        /// <summary>
        /// Interactive logic for if ice should be included
        ///     with the water  
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
        /// Private backing variable for the Lemon property
        /// </summary>
        private bool lemon = false;

        /// <summary>
        /// Interactive logic for if lemon should be included
        ///     with the water
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
        /// The special instructions for preparing the water
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (Lemon) instructions.Add("Add Lemon");
                if (!Ice) instructions.Add("Hold Ice");
                return instructions;
            }
        }

        /// <summary>
        /// Overrides the ToString method
        /// </summary>
        /// <returns>String representation of the class with the size</returns>
        public override string ToString()
        {
            return Size.ToString() + " Water";
        }
    }
}
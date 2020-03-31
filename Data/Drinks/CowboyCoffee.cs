/*
 * Author: Zachery Brunner
 * Class: CowboyCoffee.cs
 * Purpose: Model for the Cowboy Coffee menu item
 *      Includes: Interactive logic for XAML pages using the INotifyPropertyChanged
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;

using CowboyCafe.Data.Enums;

namespace CowboyCafe.Data.Drinks
{
    public class CowboyCoffee : Drink, INotifyPropertyChanged
    {
        /// <summary>
        /// This event will be invoked when a property is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        
        /// <summary>
        /// Cowboy Coffee Price - Based on size
        /// </summary>
        public override double Price
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return DrinkInformation.SMALL_COWBOY_COFFEE_PRICE;
                    case Size.Medium:
                        return DrinkInformation.MEDIUM_COWBOY_COFFEE_PRICE;
                    case Size.Large:
                        return DrinkInformation.LARGE_COWBOY_COFFEE_PRICE;
                    default:
                        throw new NotImplementedException("Unknown size");
                }
            }
        }

        /// <summary>
        /// Cowboy Coffee Calorie Count - Based on size
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return DrinkInformation.SMALL_COWBOY_COFFEE_CALORIES;
                    case Size.Medium:
                        return DrinkInformation.MEDIUM_COWBOY_COFFEE_CALORIES;
                    case Size.Large:
                        return DrinkInformation.LARGE_COWBOY_COFFEE_CALORIES;
                    default:
                        throw new NotImplementedException("Unknown size");
                }
            }
        }

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
        private bool ice = false;

        /// <summary>
        /// Interactive logic for if ice should be included
        ///     with the cowboy coffee   
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
        /// Private backing variable for the Decaf property
        /// </summary>
        private bool decaf = false;

        /// <summary>
        /// Interactive logic for if decaf should be included
        ///     with the cowboy coffee   
        ///     
        /// Updates the Decaf and the Name on user click
        /// </summary>
        public bool Decaf
        {
            get
            {
                return decaf;
            }
            set
            {
                decaf = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Decaf"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }

        /// <summary>
        /// Private backing variable for the RoomForCream property
        /// </summary>
        private bool roomForCream = false;

        /// <summary>
        /// Interactive logic for if RoomForCream should be included
        ///     with the cowboy coffee   
        ///     
        /// Updates the RoomForCream and the Special Instruction list on user click
        /// </summary>
        public bool RoomForCream
        {
            get
            {
                return roomForCream;
            }
            set
            {
                roomForCream = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RoomForCream"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
            }
        }
        
        /// <summary>
        /// The special instructions for preparing the cowboy coffee
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (Ice) instructions.Add("Add Ice");
                if (RoomForCream) instructions.Add("Room for Cream");
                return instructions;
            }
        }

        /// <summary>
        /// Overrides the ToString method
        /// </summary>
        /// <returns>String representation of the class with the size</returns>
        public override string ToString()
        {
            if (Decaf) return Size.ToString() + " Decaf Cowboy Coffee";
            return Size.ToString() + " Cowboy Coffee";
        }
    }
}
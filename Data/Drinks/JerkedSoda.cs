/*
 * Author: Zachery Brunner
 * Class: JerkedSoda.cs
 * Purpose: Model for the Jerked Soda menu item
 *      Includes: Interactive logic for XAML pages using the INotifyPropertyChanged
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;

using CowboyCafe.Data.Enums;

namespace CowboyCafe.Data.Drinks
{
    public class JerkedSoda : Drink, INotifyPropertyChanged
    {
        /// <summary>
        /// This event will be invoked when a property is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Jerked Soda Price - Based on size
        /// </summary>
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

        /// <summary>
        /// Jerked Soda Calorie Count - Based on size
        /// </summary>
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
        /// Private backing variable for the Flavor Property
        /// </summary>
        private SodaFlavor flavor = SodaFlavor.CreamSoda;

        /// <summary>
        /// Gets,sets the flavor of the drink
        /// </summary>  
        public SodaFlavor Flavor
        {
            get
            {
                return flavor;
            }
            set
            {
                flavor = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }

        /// <summary>
        /// Private backing variable for the Ice property
        /// </summary>
        private bool ice = true;

        /// <summary>
        /// Interactive logic for if ice should be included
        ///     with the jerked soda  
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
        /// Implicit constructor
        /// </summary>
        public JerkedSoda() { }

        /// <summary>
        /// Constructor that allows size initialization on creation
        /// </summary>
        /// <param name="s">Size of item</param>
        public JerkedSoda(Size s)
        {
            this.Size = s;
        }

        /// <summary>
        /// The special instructions for preparing the Jerked soda
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                if (!Ice) return new List<string>() { "Hold Ice" };
                else return new List<string>();
            }
        }

        /// <summary>
        /// Overrides the ToString method
        /// </summary>
        /// <returns>String representation of the class with the size and flavor</returns>
        public override string ToString()
        {
            string flavor;
            switch(Flavor)
            {
                /* Birch Beer */
                case SodaFlavor.BirchBeer:
                    flavor = "Birch Beer";
                break;

                /* Cream Soda */
                case SodaFlavor.CreamSoda:
                    flavor = "Cream Soda";
                break;

                /* Orange Soda */
                case SodaFlavor.OrangeSoda:
                    flavor = "Orange Soda";
                break;

                /* Root Beer */
                case SodaFlavor.RootBeer:
                    flavor = "Root Beer";
                break;

                /* Sarsparilla */
                case SodaFlavor.Sarsparilla:
                    flavor = "Sarsparilla";
                break;
                
                default:
                    throw new NotImplementedException("Unknown flavor");
            }
            return Size.ToString() + " " + flavor + " Jerked Soda";
        }
    }
}
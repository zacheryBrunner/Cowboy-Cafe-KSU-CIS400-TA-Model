/*
 * Author: Zachery Brunner
 * Class: PanDeCampo.cs
 * Purpose: Model for the Pan de Campo menu item
 *      Includes: Interactive logic for XAML pages using the INotifyPropertyChanged
 */
using System;
using System.ComponentModel;

using CowboyCafe.Data.Enums;

namespace CowboyCafe.Data.Sides
{
    public class PanDeCampo : Side, INotifyPropertyChanged
    {
        /// <summary>
        /// This event will be invoked when a property is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Pan de Campo Price - Based on size
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
        /// Pan de Campo Calorie Count - Based on size
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
        /// Overrides the ToString method
        /// </summary>
        /// <returns>String representation of the class with the size</returns>
        public override string ToString()
        {
            return Size.ToString() + " Pan de Campo";
        }
    }
}
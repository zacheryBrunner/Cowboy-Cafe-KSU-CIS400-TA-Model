/*
 * Author: Zachery Brunner
 * Class: ChiliCheeseFries.cs
 * Purpose: Model for the Baked Beans menu item
 *      Includes: Interactive logic for XAML pages using the INotifyPropertyChanged
 */
using System;
using System.ComponentModel;

using CowboyCafe.Data.Enums;

namespace CowboyCafe.Data.Sides
{
    public class ChiliCheeseFries : Side, INotifyPropertyChanged
    {
        /// <summary>
        /// This event will be invoked when a property is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Chili Cheese Fries Price - Based on size
        /// </summary>
        public override double Price
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return SideInformation.SMALL_CHILI_CHEESE_FRIES_PRICE;
                    case Size.Medium:
                        return SideInformation.MEDIUM_CHILI_CHEESE_FRIES_PRICE;
                    case Size.Large:
                        return SideInformation.LARGE_CHILI_CHEESE_FRIES_PRICE;
                    default:
                        throw new NotImplementedException("Unknown size");
                }
            }
        }

        /// <summary>
        /// Chili Cheese Fries Calorie Count - Based on size
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch(Size)
                {
                    case Size.Small:
                        return SideInformation.SMALL_CHILI_CHEESE_FRIES_CALORIES;
                    case Size.Medium:
                        return SideInformation.MEDIUM_CHILI_CHEESE_FRIES_CALORIES;
                    case Size.Large:
                        return SideInformation.LARGE_CHILI_CHEESE_FRIES_CALORIES;
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
        /// Implicit constructor
        /// </summary>
        public ChiliCheeseFries() { }

        /// <summary>
        /// Constructor that allows size initialization on creation
        /// </summary>
        /// <param name="s">Size of item</param>
        public ChiliCheeseFries(Size s)
        {
            this.Size = s;
        }

        /// <summary>
        /// Overrides the ToString method
        /// </summary>
        /// <returns>String representation of the class with the size</returns>
        public override string ToString()
        {
            return Size.ToString() + " Chili Cheese Fries";
        }
    }
}
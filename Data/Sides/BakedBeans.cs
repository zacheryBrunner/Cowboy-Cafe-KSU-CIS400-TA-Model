/*
 * Author: Zachery Brunner
 * Class: BakedBeans.cs
 * Purpose: Model for the Baked Beans menu item
 *      Includes: Interactive logic for XAML pages using the INotifyPropertyChanged
 */
using System;
using System.ComponentModel;

using CowboyCafe.Data.Enums;

namespace CowboyCafe.Data.Sides
{
    public class BakedBeans : Side, INotifyPropertyChanged
    {
        /// <summary>
        /// This event will be invoked when a property is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Baked Bean Price - Based on size
        /// </summary>
        public override double Price
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return SideInformation.SMALL_BAKED_BEANS_PRICE;
                    case Size.Medium:
                        return SideInformation.MEDIUM_BAKED_BEANS_PRICE;
                    case Size.Large:
                        return SideInformation.LARGE_BAKED_BEANS_PRICE;
                    default:
                        throw new NotImplementedException("Unknown size");
                }
            }
        }

        /// <summary>
        /// Baked Beans Calorie Count - Based on size
        /// </summary>
        public override uint Calories
        {
            get
            {
                switch (Size)
                {
                    case Size.Small:
                        return SideInformation.SMALL_BAKED_BEANS_CALORIES;
                    case Size.Medium:
                        return SideInformation.MEDIUM_BAKED_BEANS_CALORIES;
                    case Size.Large:
                        return SideInformation.LARGE_BAKED_BEANS_CALORIES;
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
            return Size.ToString() + " Baked Beans";
        }
    }
}
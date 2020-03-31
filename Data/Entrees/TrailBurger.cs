/* 
 * Author: Zachery Brunner
 * Class: Trailburger.cs
 * Purpose: Model for the trail burger menu item
 *      Includes: Interactive logic for XAML pages using the INotifyPropertyChanged
 */
using System.Collections.Generic;
using System.ComponentModel;

namespace CowboyCafe.Data.Entrees
{
    public class TrailBurger : Entree, INotifyPropertyChanged
    {
        /// <summary>
        /// This event will be invoked when a property is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Trail Burger Price
        /// </summary>
        public override double Price { get { return EntreeInformation.TRAIL_BURGER_PRICE; } }

        /// <summary>
        /// Trail Burger Calorie Count
        /// </summary>
        public override uint Calories { get { return EntreeInformation.TRAIL_BURGER_CALORIES; } }

        /// <summary>
        /// Private backing variable for the Bun property
        /// </summary>
        private bool bun = true;

        /// <summary>
        /// Interactive logic for if bun should be included
        ///     with the trail burger
        ///     
        /// Updates the Bun and the Special Instruction list on user click
        /// </summary>
        public bool Bun
        {
            get
            {
                return bun;
            }
            set
            {
                bun = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Bun"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
            }
        }

        /// <summary>
        /// Private backing variable for the Ketchup property
        /// </summary>
        private bool ketchup = true;

        /// <summary>
        /// Interactive logic for if ketchup should be included
        ///     with the trail burger
        ///     
        /// Updates the Ketchup and the Special Instruction list on user click
        /// </summary>
        public bool Ketchup
        {
            get
            {
                return ketchup;
            }
            set
            {
                ketchup = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ketchup"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
            }
        }

        /// <summary>
        /// Private backing variable for the Mustard property
        /// </summary>
        private bool mustard = true;

        /// <summary>
        /// Interactive logic for if mustard should be included
        ///     with the trail burger
        ///     
        /// Updates the Mustard and the Special Instruction list on user click
        /// </summary>
        public bool Mustard
        {
            get
            {
                return mustard;
            }
            set
            {
                mustard = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Mustard"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
            }
        }

        /// <summary>
        /// Private backing variable for the Pickle property
        /// </summary>
        private bool pickle = true;

        /// <summary>
        /// Interactive logic for if pickle should be included
        ///     with the trail burger   
        ///     
        /// Updates the Pickle and the Special Instruction list on user click
        /// </summary>
        public bool Pickle
        {
            get
            {
                return pickle;
            }
            set
            {
                pickle = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Pickle"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
            }
        }

        /// <summary>
        /// Private backing variable for the Cheese property
        /// </summary>
        private bool cheese = true;

        /// <summary>
        /// Interactive logic for if cheese should be included
        ///     with the trail burger
        ///     
        /// Updates the Cheese and the Special Instruction list on user click
        /// </summary>
        public bool Cheese
        {
            get
            {
                return cheese;
            }
            set
            {
                cheese = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Cheese"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
            }
        }
        /// <summary>
        /// The special instructions for preparing the trail burger
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (!Bun) instructions.Add("hold bun");
                if (!Ketchup) instructions.Add("hold ketchup");
                if (!Mustard) instructions.Add("hold mustard");
                if (!Pickle) instructions.Add("hold pickle");
                if (!Cheese) instructions.Add("hold cheese");
                return instructions;
            }
        }

        /// <summary>
        /// Overrides the ToString method
        /// </summary>
        /// <returns>String representation of the class</returns>
        public override string ToString()
        {
            return "Trail Burger";
        }
    }
}
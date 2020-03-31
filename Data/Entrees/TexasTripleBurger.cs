/* 
 * Author: Zachery Brunner
 * Class: TexasTripleBurger.cs
 * Purpose: Model for the Texas Triple menu item
 *      Includes: Interactive logic for XAML pages using the INotifyPropertyChanged
 */
using System.Collections.Generic;
using System.ComponentModel;

namespace CowboyCafe.Data.Entrees
{
    public class TexasTripleBurger : Entree, INotifyPropertyChanged
    {
        /// <summary>
        /// This event will be invoked when a property is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Texas Triple Price
        /// </summary>
        public override double Price { get { return EntreeInformation.TEXAS_TRIPLE_PRICE; } }

        /// <summary>
        /// Texas Triple Calorie Count
        /// </summary>
        public override uint Calories { get { return EntreeInformation.TEXAS_TRIPLE_CALORIES; } }
        
        /// <summary>
        /// Private backing variable for the Bun property
        /// </summary>
        private bool bun = true;

        /// <summary>
        /// Interactive logic for if bun should be included
        ///     with the texas triple
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
        ///     with the texas triple
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
        ///     with the texas triple
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
        ///     with the texas triple    
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
        ///     with the texas triple
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
        /// Private backing variable for the Tomato property
        /// </summary>
        private bool tomato = true;

        /// <summary>
        /// Interactive logic for if tomato should be included
        ///     with the texas triple
        ///     
        /// Updates the Tomato and the Special Instruction list on user click
        /// </summary>
        public bool Tomato
        {
            get
            {
                return tomato;
            }
            set
            {
                tomato = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tomato"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
            }
        }

        /// <summary>
        /// Private backing variable for the Lettuce property
        /// </summary>
        private bool lettuce = true;

        /// <summary>
        /// Interactive logic for if lettuce should be included
        ///     with the texas triple
        ///     
        /// Updates the Lettuce and the Special Instruction list on user click
        /// </summary>
        public bool Lettuce
        {
            get
            {
                return lettuce;
            }
            set
            {
                lettuce = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Lettuce"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
            }
        }

        /// <summary>
        /// Private backing variable for the Mayo property
        /// </summary>
        private bool mayo = true;

        /// <summary>
        /// Interactive logic for if mayo should be included
        ///     with the texas triple
        ///     
        /// Updates the Mayo and the Special Instruction list on user click
        /// </summary>
        public bool Mayo
        {
            get
            {
                return mayo;
            }
            set
            {
                mayo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Mayo"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
            }
        }

        /// <summary>
        /// Private backing variable for the Bacon property
        /// </summary>
        private bool bacon = true;

        /// <summary>
        /// Interactive logic for if bacon should be included
        ///     with the texas triple
        ///     
        /// Updates the Bacon and the Special Instruction list on user click
        /// </summary>
        public bool Bacon
        {
            get
            {
                return bacon;
            }
            set
            {
                bacon = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Bacon"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
            }
        }

        /// <summary>
        /// Private backing variable for the Egg property
        /// </summary>
        private bool egg = true;

        /// <summary>
        /// Interactive logic for if egg should be included
        ///     with the texas triple
        ///     
        /// Updates the Egg and the Special Instruction list on user click
        /// </summary>
        public bool Egg
        {
            get
            {
                return egg;
            }
            set
            {
                egg = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Egg"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
            }
        }

        /// <summary>
        /// The special instructions for preparing the texas triple
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
                if (!Tomato) instructions.Add("hold tomato");
                if (!Lettuce) instructions.Add("hold lettuce");
                if (!Mayo) instructions.Add("hold mayo");
                if (!Bacon) instructions.Add("hold bacon");
                if (!Egg) instructions.Add("hold egg");
                return instructions;
            }
        }

        /// <summary>
        /// Overrides the ToString method
        /// </summary>
        /// <returns>String representation of the class</returns>
        public override string ToString()
        {
            return "Texas Triple Burger";
        }
    }
}
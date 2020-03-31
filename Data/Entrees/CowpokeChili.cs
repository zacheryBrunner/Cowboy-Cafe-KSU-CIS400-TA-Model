/* 
 * Author: Zachery Brunner
 * Class: CowpokeChili.cs
 * Purpose: Model for the Cowpoke Chili menu item
 *      Includes: Interactive logic for XAML pages using the INotifyPropertyChanged
 */
using System.Collections.Generic;
using System.ComponentModel;

namespace CowboyCafe.Data.Entrees
{
    public class CowpokeChili : Entree, INotifyPropertyChanged
    {
        /// <summary>
        /// This event will be invoked when a property is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Cowpoke Chili Price
        /// </summary>
        public override double Price { get { return EntreeInformation.COWPOKE_CHILI_PRICE; } }

        /// <summary>
        /// Cowpoke Chili Calorie Count
        /// </summary>
        public override uint Calories { get { return EntreeInformation.COWPOKE_CHILI_CALORIES; } }

        /// <summary>
        /// Private backing variable for the Cheese property
        /// </summary>
        private bool cheese = true;

        /// <summary>
        /// Interactive logic for if cheese should be included
        ///     with the cowpoke chili
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
        /// Private backing variable for the SourCream property
        /// </summary>
        private bool sourCream = true;

        /// <summary>
        /// Interactive logic for if sour cream should be included
        ///     with the cowpoke chili
        ///     
        /// Updates the SourCream and the Special Instruction list on user click
        /// </summary>
        public bool SourCream
        {
            get
            {
                return sourCream;
            }
            set
            {
                sourCream = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SourCream"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
            }
        }

        /// <summary>
        /// Private backing variable for the GreenOnions property
        /// </summary>
        private bool greenOnions = true;

        /// <summary>
        /// Interactive logic for if green onions should be included
        ///     with the cowpoke chili
        ///     
        /// Updates the GreenOnions and the Special Instruction list on user click
        /// </summary>
        public bool GreenOnions
        {
            get
            {
                return greenOnions;
            }
            set
            {
                greenOnions = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("GreenOnions"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
            }
        }

        /// <summary>
        /// Private backing variable for the TortillaStrips property
        /// </summary>
        private bool tortillaStrips = true;

        /// <summary>
        /// Interactive logic for if tortilla strips should be included
        ///     with the cowpoke chili
        ///     
        /// Updates the TortillaStrips and the Special Instruction list on user click
        /// </summary>
        public bool TortillaStrips
        {
            get
            {
                return tortillaStrips;
            }
            set
            {
                tortillaStrips = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TortillaStrips"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
            }
        }

        /// <summary>
        /// The special instructions for preparing the cowpoke chili
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (!Cheese) instructions.Add("hold cheese");
                if (!SourCream) instructions.Add("hold sour cream");
                if (!GreenOnions) instructions.Add("hold green onions");
                if (!TortillaStrips) instructions.Add("hold tortilla strips");
                return instructions;
            }
        }

        /// <summary>
        /// Overrides the ToString method
        /// </summary>
        /// <returns>String representation of the class</returns>
        public override string ToString()
        {
            return "Cowpoke Chili";
        }
    }
}
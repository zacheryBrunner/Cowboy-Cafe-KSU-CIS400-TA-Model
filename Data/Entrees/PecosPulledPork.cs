/* 
 * Author: Zachery Brunner
 * Class: PecosPulledPork.cs
 * Purpose: Model for the Pecos Pulled Pork menu item
 *      Includes: Interactive logic for XAML pages using the INotifyPropertyChanged
 */
using System.Collections.Generic;
using System.ComponentModel;

namespace CowboyCafe.Data.Entrees
{
    public class PecosPulledPork : Entree, INotifyPropertyChanged
    {
        /// <summary>
        /// This event will be invoked when a property is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Pecos Pulled Pork Price
        /// </summary>
        public override double Price { get { return EntreeInformation.PECOS_PULLED_PORK_PRICE; } }

        /// <summary>
        /// Pecos Pulled Pork Calorie Count
        /// </summary>
        public override uint Calories { get { return EntreeInformation.PECOS_PULLED_PORK_CALORIES; } }
        
        /// <summary>
        /// Private backing variable for the Bread property
        /// </summary>
        private bool bread = true;

        /// <summary>
        /// Interactive logic for if bread should be included
        ///     with the pecos pulled pork
        ///     
        /// Updates the Bread and the Special Instruction list on user click
        /// </summary>
        public bool Bread
        {
            get
            {
                return bread;
            }
            set
            {
                bread = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Bread"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
            }
        }

        /// <summary>
        /// Private backing variable for the Pickle property
        /// </summary>
        private bool pickle = true;

        /// <summary>
        /// Interactive logic for if pickle should be included
        ///     with the pecos pulled pork    
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
        /// The special instructions for preparing the pecos pulled pork
        /// </summary>
        public override List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (!Pickle) instructions.Add("hold pickle");
                if (!Bread) instructions.Add("hold bread");
                return instructions;
            }
        }

        /// <summary>
        /// Overrides the ToString method
        /// </summary>
        /// <returns>String representation of the class</returns>
        public override string ToString()
        {
            return "Pecos Pulled Pork";
        }
    }
}
<<<<<<< HEAD
﻿/* 
 * Author: Zachery Brunner
 * Class: AngryChicken.cs
 * Purpose: Information about the menu item Angry Chicken
 */
 using System.Collections.Generic;

namespace CowboyCafe.Data
{
    public class AngryChicken
    {
        /// <summary>
        /// Angry Chicken Price
        /// </summary>
        public double Price { get { return 5.99; } }

        /// <summary>
        /// Angry Chicken Calorie Count
        /// </summary>
        public uint Calories { get { return 190; } }

        /// <summary>
        /// Serve bread with Angry Chicken?
        /// </summary>
        public bool Bread { get; set; } = true;

        /// <summary>
        /// Serve pickle with Angry Chicken?
        /// </summary>
        public bool Pickle { get; set; } = true;

        /// <summary>
        /// Preparation instructions for Angry Chicken
=======
﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CowboyCafe.Data
{
    /// <summary>
    /// A class representing an angry chicken entree
    /// </summary>
    public class AngryChicken
    {
        private bool bread = true;
        /// <summary>
        /// If the AngryChicken is served with bread
        /// </summary>
        public bool Bread
        {
            get { return bread; }
            set { bread = value; }
        }

        /// <summary>
        /// If the angry chicken is served with a pickle
        /// </summary>
        public bool Pickle { get; set; } = true;

        /// <summary>
        /// The price of the angry chicken
        /// </summary>
        public double Price
        {
            get { return 5.99; }
        }

        /// <summary>
        /// The calories of the angry chicken
        /// </summary>
        public uint Calories
        {
            get { return 190; }
        }

        /// <summary>
        /// The special instructions for preparing the angry chicken
>>>>>>> 39f23923651db4dafe6dbb705759ce97d16ca5cc
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
<<<<<<< HEAD
                if (!Pickle) instructions.Add("hold pickle");
                if (!Bread) instructions.Add("hold bread");
=======

                if(!bread) instructions.Add("hold bread");
                if(!Pickle) instructions.Add("hold pickle"); 

>>>>>>> 39f23923651db4dafe6dbb705759ce97d16ca5cc
                return instructions;
            }
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> 39f23923651db4dafe6dbb705759ce97d16ca5cc

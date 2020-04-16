/* Author: Zachery Brunner
 * Class: Menu.cs
 * Purpose: Build the menu
 */
using System.Collections.Generic;

using CowboyCafe.Data.Entrees;
using CowboyCafe.Data.Drinks;
using CowboyCafe.Data.Sides;

namespace CowboyCafe.Data
{
    public static class Menu
    {
        /// <summary>
        /// Gets all of the entrees in the menu
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<IOrderItem> Entrees()
        {
            List<IOrderItem> entrees = new List<IOrderItem>();

            entrees.Add(new AngryChicken());
            entrees.Add(new CowpokeChili());
            entrees.Add(new DakotaDoubleBurger());
            entrees.Add(new PecosPulledPork());
            entrees.Add(new RustlersRibs());
            entrees.Add(new TexasTripleBurger());
            entrees.Add(new TrailBurger());

            return entrees;
        }

        /// <summary>
        /// Get all the sides in the menu
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<IOrderItem> Sides()
        {
            List<IOrderItem> sides = new List<IOrderItem>();

            sides.Add(new BakedBeans());
            sides.Add(new ChiliCheeseFries());
            sides.Add(new PanDeCampo());
            sides.Add(new CornDodgers());

            return sides;
        }

        /// <summary>
        /// Get all the drinks in the menu
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<IOrderItem> Drinks()
        {
            List<IOrderItem> drinks = new List<IOrderItem>();

            drinks.Add(new CowboyCoffee());
            drinks.Add(new JerkedSoda());
            drinks.Add(new TexasTea());
            drinks.Add(new Water());

            return drinks;
        }

        /// <summary>
        /// Compile the entire menu using the above 3 methods
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<IOrderItem> CompleteMenu()
        {
            List<IOrderItem> completeMenu = new List<IOrderItem>();

            foreach (IOrderItem i in Entrees())
            {
                completeMenu.Add(i);
            }

            foreach (IOrderItem i in Drinks())
            {
                completeMenu.Add(i);
            }

            foreach (IOrderItem i in Sides())
            {
                completeMenu.Add(i);
            }

            return completeMenu;
        }
    }
}
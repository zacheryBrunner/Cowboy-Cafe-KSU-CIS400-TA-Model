/* Author: Zachery Brunner
 * Class: Menu.cs
 * Purpose: Build the menu
 */
using System.Collections.Generic;

using CowboyCafe.Data.Entrees;
using CowboyCafe.Data.Drinks;
using CowboyCafe.Data.Sides;

using Size = CowboyCafe.Data.Enums.Size;

namespace CowboyCafe.Data
{
    public static class Menu
    {
        /// <summary>
        /// All types of items in the menu
        /// </summary>
        public static string[] TypeOfItems
        {
            get => new string[]
            {
                "Entrees",
                "Sides",
                "Drinks"
            };
        }

        /// <summary>
        /// Gets all of the entrees in the menu
        /// </summary>
        /// <returns>All entrees at the Cowboy-Cafe</returns>
        public static IEnumerable<IOrderItem> Entrees()
        {
            List<IOrderItem> entrees = new List<IOrderItem>();

            /* Add all of the entrees */
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
        /// <returns>All Sides at the Cowboy-Cafe</returns>
        public static IEnumerable<IOrderItem> Sides()
        {
            List<IOrderItem> sides = new List<IOrderItem>();

            /* Add all of the sides */
            sides.Add(new BakedBeans(Size.Small));
            sides.Add(new BakedBeans(Size.Medium));
            sides.Add(new BakedBeans(Size.Large));

            sides.Add(new ChiliCheeseFries(Size.Small)); 
            sides.Add(new ChiliCheeseFries(Size.Medium));
            sides.Add(new ChiliCheeseFries(Size.Large));

            sides.Add(new PanDeCampo(Size.Small));
            sides.Add(new PanDeCampo(Size.Medium));
            sides.Add(new PanDeCampo(Size.Large));

            sides.Add(new CornDodgers(Size.Small));
            sides.Add(new CornDodgers(Size.Medium));
            sides.Add(new CornDodgers(Size.Large));

            return sides;
        }

        /// <summary>
        /// Get all the drinks in the menu
        /// </summary>
        /// <returns>All drinks at the Cowboy-Cafe</returns>
        public static IEnumerable<IOrderItem> Drinks()
        {
            List<IOrderItem> drinks = new List<IOrderItem>();

            /* Add all of the drinks */
            drinks.Add(new CowboyCoffee(Size.Small));
            drinks.Add(new CowboyCoffee(Size.Medium));
            drinks.Add(new CowboyCoffee(Size.Large));

            drinks.Add(new JerkedSoda(Size.Small));
            drinks.Add(new JerkedSoda(Size.Medium));
            drinks.Add(new JerkedSoda(Size.Large));

            drinks.Add(new TexasTea(Size.Small));
            drinks.Add(new TexasTea(Size.Medium));
            drinks.Add(new TexasTea(Size.Large));

            drinks.Add(new Water());

            return drinks;
        }

        /// <summary>
        /// Compile the entire menu using the above 3 methods
        /// </summary>
        /// <returns>The complete Cowboy-Cafe Menu</returns>
        public static IEnumerable<IOrderItem> CompleteMenu()
        {
            List<IOrderItem> completeMenu = new List<IOrderItem>();

            /* The AddRange Method concats 2 list objects together */
            completeMenu.AddRange(Entrees());
            completeMenu.AddRange(Sides());
            completeMenu.AddRange(Drinks());

            return completeMenu;
        }

        /// <summary>
        /// This is the functionality for the search bar in the website
        /// </summary>
        /// <param name="menu">The full menu</param>
        /// <param name="terms">The search key to filter by</param>
        /// <returns>An updated list with the filtered items</returns>
        public static IEnumerable<IOrderItem> Search(IEnumerable<IOrderItem> menu, string terms)
        {
            /* See if terms are null, if so no need to go further */
            if (terms == null) return menu;

            /* Cast the menu to something you can work with */
            List<IOrderItem> results = new List<IOrderItem>();
            
            /* Filter through the entire menu looking for the substring "terms" 
                    If substring is found in the name then it is added to results list */
            foreach(IOrderItem item in menu)
                if(item.Name.Contains(terms, System.StringComparison.InvariantCultureIgnoreCase))
                    results.Add(item);

            return results;
        }

        /// <summary>
        /// Filters by the categories of the IOrderItems
        /// </summary>
        /// <param name="menu">The current filtered menu</param>
        /// <param name="cat">The list of categories to filter by</param>
        /// <returns>An updated list with the filtered items</returns>
        public static IEnumerable<IOrderItem> FilterByCategory(IEnumerable<IOrderItem> menu, IEnumerable<string> cat)
        {
            List<IOrderItem> results = new List<IOrderItem>();

            /* Create some boolean values so I only have to traverse list once */
            bool filterInEntrees = ((List<string>)cat).Contains("Entrees");
            bool filterInSides = ((List<string>)cat).Contains("Sides");
            bool filterInDrinks = ((List<string>)cat).Contains("Drinks");

            foreach(IOrderItem i in menu)
            {
                /* Check type of item */
                if (i is Entree e)
                {
                    /* Check if we include item */
                    if (filterInEntrees)
                        results.Add(e);
                }

                else if (i is Drink d)
                {
                    if (filterInDrinks)
                        results.Add(d);
                }

                else if (i is Side)
                {
                    if(filterInSides)
                        results.Add(i);
                }    
            }

            /* Return the update search */
            return results;
        }

        /// <summary>
        /// Filters by the calories of the items
        /// </summary>
        /// <param name="menu">The current menu</param>
        /// <param name="min">The minimum number of calories that must be in the item</param>
        /// <param name="max">The maximum number of calories that must be in the item</param>
        /// <returns>An updated list with the filtered items</returns>
        public static IEnumerable<IOrderItem> FilterByCalories(IEnumerable<IOrderItem> menu, int? min, int? max)
        {
            /* Return the entire menu, we don't need to filter */
            if (min == null && max == null) return menu;

            /* Create results list that we can populate */
            List<IOrderItem> results = new List<IOrderItem>();

            /* Filter by the max */
            if(min == null)
            {
                foreach (IOrderItem i in menu)
                    if (i.Calories <= max)
                        results.Add(i);
            }

            /* Filter by the min */
            else if(max == null)
            {
                foreach (IOrderItem i in menu)
                    if (i.Calories >= min)
                        results.Add(i);
            }

            /* Min and max are both not null */
            else
            {
                foreach (IOrderItem i in menu)
                    if (i.Calories >= min && i.Calories <= max)
                        results.Add(i);
            }

            /* Return the updated search */
            return results;
        }

        /// <summary>
        /// Filters by the price of the entree
        /// </summary>
        /// <param name="menu">The current filtered menu</param>
        /// <param name="min">The minimum price of the entree to filter by</param>
        /// <param name="max">The maximum price of the entree to filter by</param>
        /// <returns>An updated list with the filtered items</returns>
        public static IEnumerable<IOrderItem> FilterByPrice(IEnumerable<IOrderItem> menu, double? min, double? max)
        {
            /* Nothing to filter, return here */
            if (min == null && max == null) return menu;

            /* Create results list that we can populate */
            List<IOrderItem> results = new List<IOrderItem>();
            
            /* Filter by the max */
            if (min == null)
            {
                foreach (IOrderItem i in menu)
                    if (i.Price <= max)
                        results.Add(i);
            }

            /* Filter by the min */
            else if (max == null)
            {
                foreach (IOrderItem i in menu)
                    if (i.Price >= min)
                        results.Add(i);
            }

            /* Min and max are both not null */
            else
            {
                foreach (IOrderItem i in menu)
                    if (i.Price >= min && i.Price <= max)
                        results.Add(i);
            }

            /* Return the updated search */
            return results;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using CowboyCafe.Data;
using CCMenu = CowboyCafe.Data.Menu;
using System.Text;

namespace Website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// Holds the current menu that is shown in the html
        /// </summary>
        public IEnumerable<IOrderItem> Menu { get; protected set; }


        [BindProperty]
        public string[] typeOfItems { get; set; }

        /// <summary>
        /// Search terms if the user wanted to search for something
        /// </summary>
        [BindProperty]
        public string SearchTerms { get; set; } = "";

        /// <summary>
        /// The minimum price to filter the items by
        /// </summary>
        [BindProperty]
        public double? PriceMin { get; set; } = 0;

        /// <summary>
        /// The maximum price to filter the items by
        /// </summary>
        [BindProperty]
        public double? PriceMax { get; set; } = 100;

        /// <summary>
        /// The minimum calorie to filter the items by
        /// </summary>
        [BindProperty]
        public int? CalorieMin { get; set; } = 0;

        /// <summary>
        /// The maximum calorie to filter the items by
        /// </summary>
        [BindProperty]
        public int? CalorieMax { get; set; } = 1000;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Hits this method when get request start flowing
        /// </summary>
        public void OnGet(int? CalorieMin, int? CalorieMax, double? PriceMin, double? PriceMax, string[]? typeOfItems)
        {
            this.CalorieMax = CalorieMax;
            this.CalorieMin = CalorieMin;
            this.PriceMin = PriceMin;
            this.PriceMax = PriceMax;

            SearchTerms = Request.Query["SearchTerms"];
            typeOfItems = Request.Query["typeOfItems"];

            if(typeOfItems.Length == 0)
            {
                typeOfItems = new string[]
                {
                    "Entrees",
                    "Sides",
                    "Drinks"
                };
            }

            Menu = CCMenu.Search(CCMenu.CompleteMenu(), SearchTerms);
            Menu = CCMenu.FilterByCalories(Menu, CalorieMin, CalorieMax);
            Menu = CCMenu.FilterByCategory(Menu, typeOfItems.ToList());
            Menu = CCMenu.FilterByPrice(Menu, PriceMin, PriceMax);
        }
    }
}
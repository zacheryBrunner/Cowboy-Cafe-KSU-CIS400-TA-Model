/*
 * Author: Zachery Brunner
 * Class: SideInformation.cs
 * Purpose: A centralized place to change the prices and calorie values. Allows for constant allocation of values
 *      This is very popular in the professional development to have a class full of constant variables. 
 * 
 * Notes: If you were working with a database a class full of constant strings that refer to queries 
 *      is extremely common to see
 *      
 * Naming Convention: public const <TYPE DECLARATION> ALL_CAPITAL_LETTERS_SEPARATED_BY_UNDERSCORES 
 */
namespace CowboyCafe.Data.Sides
{
    public class SideInformation
    {
        //Holds the prices for each size of baked beans
        public const double SMALL_BAKED_BEANS_PRICE = 1.59;
        public const double MEDIUM_BAKED_BEANS_PRICE = 1.79;
        public const double LARGE_BAKED_BEANS_PRICE = 1.99;

        //Holds the calories for each size of baked beans
        public const uint SMALL_BAKED_BEANS_CALORIES = 312;
        public const uint MEDIUM_BAKED_BEANS_CALORIES = 378;
        public const uint LARGE_BAKED_BEANS_CALORIES = 410;

        //Holds the prices for each size of ChiliCheeseFries
        public const double SMALL_CHILI_CHEESE_FRIES_PRICE = 1.99;
        public const double MEDIUM_CHILI_CHEESE_FRIES_PRICE = 2.99;
        public const double LARGE_CHILI_CHEESE_FRIES_PRICE = 3.99;

        //Holds the calories for each size of ChiliCheeseFries
        public const uint SMALL_CHILI_CHEESE_FRIES_CALORIES = 433;
        public const uint MEDIUM_CHILI_CHEESE_FRIES_CALORIES = 524;
        public const uint LARGE_CHILI_CHEESE_FRIES_CALORIES = 610;

        //Holds the prices for each size of PanDeCampo
        public const double SMALL_PANDECAMPO_PRICE = 1.59;
        public const double MEDIUM_PANDECAMPO_PRICE = 1.79;
        public const double LARGE_PANDECAMPO_PRICE = 1.99;

        //Holds the calories for each size of PanDeCampo
        public const uint SMALL_PANDECAMPO_CALORIES = 227;
        public const uint MEDIUM_PANDECAMPO_CALORIES = 269;
        public const uint LARGE_PANDECAMPO_CALORIES = 367;

        //Holds the prices for each size of CornDodgers
        public const double SMALL_CORN_DODGERS_PRICE = 1.59;
        public const double MEDIUM_CORN_DODGERS_PRICE = 1.79;
        public const double LARGE_CORN_DODGERS_PRICE = 1.99;

        //Holds the calories for each size of CornDodgers
        public const uint SMALL_CORN_DODGERS_CALORIES = 512;
        public const uint MEDIUM_CORN_DODGERS_CALORIES = 685;
        public const uint LARGE_CORN_DODGERS_CALORIES = 717;
    }
}
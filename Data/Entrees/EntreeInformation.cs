/*
 * Author: Zachery Brunner
 * Class: EntreeInformation.cs
 * Purpose: A centralized place to change the prices and calorie values. Allows for constant allocation of values
 *      This is very popular in the professional development to have a class full of constant variables. 
 * 
 * Notes: If you were working with a database a class full of constant strings that refer to queries 
 *      is extremely common to see
 *      
 * Naming Convention: public const <TYPE DECLARATION> ALL_CAPITAL_LETTERS_SEPARATED_BY_UNDERSCORES 
 */
namespace CowboyCafe.Data.Entrees
{
    public class EntreeInformation
    {
        //Information about the AngryChicken entree
        public const double ANGRY_CHICKEN_PRICE = 5.99;
        public const uint ANGRY_CHICKEN_CALORIES = 190;

        //Information about the CowpokeChili entree
        public const double COWPOKE_CHILI_PRICE = 6.10;
        public const uint COWPOKE_CHILI_CALORIES = 171;

        //Information about the DakotaDouble entree
        public const double DAKOTA_DOUBLE_PRICE = 5.20;
        public const uint DAKOTA_DOUBLE_CALORIES = 464;

        //Information about the PecosPulledPork entree
        public const double PECOS_PULLED_PORK_PRICE = 5.88;
        public const uint PECOS_PULLED_PORK_CALORIES = 528;

        //Information about the RustlersRibs entree
        public const double RUSTLERS_RIBS_PRICE = 7.50;
        public const uint RUSTLERS_RIBS_CALORIES = 894;

        //Information about the TexasTriple entree
        public const double TEXAS_TRIPLE_PRICE = 6.45;
        public const uint TEXAS_TRIPLE_CALORIES = 698;

        //Information about the TrailBurger entree
        public const double TRAIL_BURGER_PRICE = 4.50;
        public const uint TRAIL_BURGER_CALORIES = 288;
    }
}
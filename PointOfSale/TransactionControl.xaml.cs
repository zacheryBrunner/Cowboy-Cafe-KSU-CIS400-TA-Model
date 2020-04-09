/* 
 * Author: Zachery Brunner
 * Class: TransactionControl.xaml.cs
 * Purpose: Handles all transactions within the point of sale system
 */
using System;
using System.Text;

using System.ComponentModel;
using System.Collections.Generic;

using System.Windows;
using System.Windows.Controls;

using CowboyCafe.Data;

using PointOfSale.ExtensionMethods;

using CashRegister;

namespace PointOfSale
{
    /// <summary>
    /// Interaction logic for TransactionControl.xaml
    /// </summary>
    public partial class TransactionControl : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// Used to update the values on the xaml page
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Instance of the cash drawer, passed into the constructor
        /// </summary>
        CashDrawer cd;

        /// <summary>
        /// The order control we need to switch back to
        /// </summary>
        OrderControl oc;

        /// <summary>
        /// Holds the Previous Order Number so we can set it later
        /// </summary>
        private uint PrevOrderNumber { get; set; } = 0;

        /// <summary>
        /// The pre-total of the order
        /// </summary>
        public double Subtotal { get; private set; } = 0;

        /// <summary>
        /// The tax amount for the order
        /// </summary>
        public double Tax { get; private set; } = 0;

        /// <summary>
        /// The final total including tax
        /// </summary>
        public double TotalWithTax { get; private set; } = 0;

        /// <summary>
        /// How much has the consumer paid?
        /// </summary>
        public double Paid { get; private set; } = 0;

        /// <summary>
        /// Private backing variable used to fix my mistakes
        /// </summary>
        private double amountLeftToTender;

        /// <summary>
        /// The current amount held by the employee
        /// </summary>
        public double AmountLeftToTender { get { return Math.Round(amountLeftToTender, 2); } private set { amountLeftToTender = Math.Round(value, 2); } }

        /// <summary>
        /// How much change is needed if customer paid with cash
        /// </summary>
        private double Change { get; set; }

        /// <summary>
        /// These are the coins that are allowed to be processed in the system
        /// </summary>
        public int Pennies { get; private set; } = 0;

        public int Nickels { get; private set; } = 0;

        public int Dimes { get; private set; } = 0;

        public int Quarters { get; private set; } = 0;

        public int HalfDollars { get; private set; } = 0;

        public int DollarCoins { get; private set; } = 0;

        /// <summary>
        /// These are the dollar bills that are allowed to be processed in the system
        /// </summary>
        public int OneBill { get; private set; } = 0;

        public int TwoBill { get; private set; } = 0;

        public int FiveBill { get; private set; } = 0;

        public int TenBill { get; private set; } = 0;

        public int TwentyBill { get; private set; } = 0;

        public int FiftyBill { get; private set; } = 0;

        public int HundredBill { get; private set; } = 0;

        /// <summary>
        /// The items in the order
        /// </summary>
        private IEnumerable<IOrderItem> Items { get; set; }

        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="cd">The cash drawer for the program</param>
        public TransactionControl(CashDrawer cd, OrderControl o)
        {
            DataContext = this;
            InitializeComponent();
            oc = o;
            Order or = (Order)o.DataContext;

            /* Cash should not be able to complete until enough has been received */
            CompleteCashButton.IsEnabled = false;

            /* Assign the cash drawer instance */
            this.cd = cd;

            /* Get the important stuff out of the order */
            PrevOrderNumber = or.OrderNumber;
            Items = or.Items;

            /* Do some quick maffs */
            Subtotal = Math.Round(or.Subtotal, 2);
            Tax = Math.Round(Subtotal * .16, 2);
            TotalWithTax = Math.Round(Subtotal + Tax, 2);
            
            /* How much do we need to charge the customer? */
            AmountLeftToTender = TotalWithTax;

            /* Let the xaml know that we updated properties */
            PopulateItemsStackPanel();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tax"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TotalWithTax"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountLeftToTender"));
        }

        /// <summary>
        /// Populates the stack panel
        /// </summary>
        private void PopulateItemsStackPanel()
        {
            foreach(IOrderItem i in Items)
            {
                string s = i.ToString() + "\t " + i.Price;
                ItemsListBox.Items.Add(s);
                foreach(string str in i.SpecialInstructions)
                {
                    ItemsListBox.Items.Add(str);
                }
            }
        }

        /// <summary>
        /// User pressed the cancel order button, set up a new order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            SetNewOrder();
        }

        /// <summary>
        /// Sets the screen back to an OrderControl for the next order
        /// </summary>
        private void SetNewOrder()
        {
            /* Go find the main window and create a new order control */
            MainWindow mw = this.FindAncestor<MainWindow>();

            /* Make new order */
            oc.DataContext = new Order(PrevOrderNumber + 1);
            oc.Container.Child = new MenuItemSelectionControl();
            mw.Container.Child = oc;
        }


        /* HAHAHAHAHAHA going below here is confusing. I do alot of jumping through switch cases. If you go past here
         *  take your time to read line by line and follow the jumps. Its the only way you'll make it though :) */


        /// <summary>
        /// The consumer is wanting to pay by card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PaybyCardButton_Click(object sender, RoutedEventArgs e)
        {
            CardTerminal ct = new CardTerminal();
            ResultCode rc = ct.ProcessTransaction(TotalWithTax);

            switch (rc)
            {
                case ResultCode.Success:
                    PrintReceipt(0);
                    break;

                case ResultCode.InsufficentFunds:
                    PaybyCardButton.IsEnabled = false;
                    ErrorText.Text = "Error: No funds";
                    break;

                case ResultCode.CancelledCard:
                    PaybyCardButton.IsEnabled = false;
                    ErrorText.Text = "Error: Card Cancelled";
                    break;

                case ResultCode.ReadError:
                    ErrorText.Text = "Error: Read Error";
                    break;

                case ResultCode.UnknownErrror:
                    ErrorText.Text = "Error: Unknown";
                    break;

                default:
                    throw new NotImplementedException("Should never be reached");
            }
        }

        /// <summary>
        /// This will increase the amount tendered while decreasing the total owed
        ///     based on the button that was pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IncrementClick(object sender, RoutedEventArgs e)
        {
            double value = 0;

            /* Switch on the button name to find out which was pressed */
            switch (((Button)sender).Name)
            {
                /* Pennies */
                case "PennyIncrementButton":
                    Pennies += 1;
                    value = .01;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Pennies"));
                break;

                /* Nickels */
                case "NickelIncrementButton":
                    Nickels += 1;
                    value = .05;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Nickels"));
                break;

                /* Dimes */
                case "DimesIncrementButton":
                    Dimes += 1;
                    value = .10;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Dimes"));
                break;

                /* Quarters */
                case "QuarterIncrementButton":
                    Quarters += 1;
                    value = .25;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Quarters"));
                break;

                /* Half Dollars */
                case "HDIncrementButton":
                    HalfDollars += 1;
                    value = .5;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HalfDollars"));
                break;

                /* Dollar Coins */
                case "DIncrementButton":
                    DollarCoins += 1;
                    value = 1;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DollarCoins"));
                break;

                /* One Bills */
                case "OnesIncrementButton":
                    OneBill += 1;
                    value = 1;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OneBill"));
                break;

                /* Two Bills */
                case "TwosIncrementButton":
                    TwoBill += 1;
                    value = 2;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TwoBill"));
                break;

                /* Five Bills */
                case "FivesIncrementButton":
                    FiveBill += 1;
                    value = 5;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiveBill"));
                break;

                /* Ten Bills */
                case "TensIncrementButton":
                    TenBill += 1;
                    value = 10;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TenBill"));
                break;

                /* Twenty Bills */
                case "TwentiesIncrementButton":
                    TwentyBill += 1;
                    value = 20;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TwentyBill"));
                break;

                /* Fifty Bills */
                case "FiftiesIncrementButton":
                    FiftyBill += 1;
                    value = 50;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiftyBill"));
                break;

                /* Hundred Bills */
                case "HundredsIncrementButton":
                    HundredBill += 1;
                    value = 100;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HundredBill"));
                break;

                /* Should never be reached */
                default:
                    throw new NotImplementedException("Should never be reached");
            }
            Paid += value;
            AmountLeftToTender -= value;
            UpdateProperties();
        }

        /// <summary>
        /// This will increase the remaining cost of payment while decreasing the amount tendered
        ///     based on the button that was pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DecrementClick(object sender, RoutedEventArgs e)
        {
            double value = 0;
            
            /* Switch on the button name to find out which was pressed */
            switch(((Button)sender).Name)
            {
                /* Pennies */
                case "PennyDecrementButton":
                    if (Pennies != 0)
                    {
                        Pennies -= 1;
                        value = .01;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Pennies"));
                    }
                    else
                        value = 0;
                break;

                /* Nickels */
                case "NickelDecrementButton":
                    if (Nickels != 0)
                    {
                        Nickels -= 1;
                        value = .05;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Nickels"));
                    }
                    else
                        value = 0;
                break;

                /* Dimes */
                case "DimesDecrementButton":
                    if (Dimes != 0)
                    {
                        Dimes -= 1;
                        value = .10;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Dimes"));
                    }
                    else
                        value = 0;
                break;

                /* Quarters */
                case "QuartersDecrementButton":
                    if (Quarters != 0)
                    {
                        Quarters -= 1;
                        value = .25;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Quarters"));
                    }
                    else
                        value = 0;
                break;

                /* Half Dollars */
                case "HDDecrementButton":
                    if (HalfDollars != 0)
                    {
                        HalfDollars -= 1;
                        value = .5;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HalfDollars"));
                    }
                    else
                        value = 0;
                break;

                /* Dollar Coins */
                case "DDecrementButton":
                    if (DollarCoins != 0)
                    {
                        DollarCoins -= 1;
                        value = 1;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DollarCoins"));
                    }
                    else
                        value = 0;
                break;

                /* One Bills */
                case "OnesDecrementButton":
                    if (OneBill != 0)
                    {
                        OneBill -= 1;
                        value = 1;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("OneBill"));
                    }
                    else
                        value = 0;
                break;

                /* Two Bills */
                case "TwosDecrementButton":
                    if (TwoBill != 0)
                    {
                        TwoBill -= 1;
                        value = 2;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TwoBill"));
                    }
                    else
                        value = 0;
                break;

                /* Five Bills */
                case "FivesDecrementButton":
                    if (FiveBill != 0)
                    {
                        FiveBill -= 1;
                    value = 5;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiveBill"));
                    }
                    else
                        value = 0;
                break;

                /* Ten Bills */
                case "TensDecrementButton":
                    if (TenBill != 0)
                    {
                        TenBill -= 1;
                    value = 10;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TenBill"));
                    }
                    else
                        value = 0;
                break;

                /* Twenty Bills */
                case "TwentiesDecrementButton":
                    if (TwentyBill != 0)
                    {
                        TwentyBill -= 1;
                        value = 20;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TwentyBill"));
                    }
                    else
                        value = 0;
                break;
                
                /* Fifty Bills */
                case "FiftiesDecrementButton":
                    if (FiftyBill != 0)
                    {
                        FiftyBill -= 1;
                        value = 50;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FiftyBill"));
                    }
                    else
                        value = 0;
                break;

                /* Hundred Bills */
                case "HundredsDecrementButton":
                    if (HundredBill != 0)
                    {
                        HundredBill -= 1;
                        value = 100;
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("HundredBill"));
                    }
                    else
                        value = 0;
               break;

                /* Should never be reached */
                default:
                    throw new NotImplementedException("Should never be reached");

            }
            Paid -= value;
            AmountLeftToTender += value;
            UpdateProperties();
        }

        /// <summary>
        /// Updates the Paid and AmountLeftToTender Properties
        /// </summary>
        private void UpdateProperties()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Paid"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AmountLeftToTender"));

            /* Logic to make sure customer has paid enough before completing the cash order */
            if (AmountLeftToTender <= 0)
                CompleteCashButton.IsEnabled = true;

            else
                CompleteCashButton.IsEnabled = false;
        }

        /// <summary>
        /// Adds the bills and coins to the drawer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompleteCashButton_Click(object sender, RoutedEventArgs e)
        {
            foreach(Coins coin in (Coins[]) Enum.GetValues(typeof(Coins)))
            {
                int quantity;
                
                /* Add all the coins to the drawer */
                switch(coin)
                {
                    /* Pennies */
                    case Coins.Penny:
                        quantity = Pennies;
                    break;

                    /* Nickels */
                    case Coins.Nickel:
                        quantity = Nickels;
                    break;

                    /* Dimes */
                    case Coins.Dime:
                        quantity = Dimes;
                    break;

                    /* Quarters */
                    case Coins.Quarter:
                        quantity = Quarters;
                    break;
                    
                    /* Half Dollars */
                    case Coins.HalfDollar:
                        quantity = HalfDollars;
                    break;

                    /* Dollars */
                    case Coins.Dollar:
                        quantity = DollarCoins;
                    break;
                    
                    /* Should never be reached */
                    default:
                        throw new NotImplementedException("Should never be reached");
                }
                cd.AddCoin(coin, quantity);
            }

            foreach(Bills bill in (Bills[]) Enum.GetValues(typeof(Bills)))
            {
                int quantity;

                /* Add the bills to the drawer */
                switch(bill)
                {
                    /* One Bills */
                    case Bills.One:
                        quantity = OneBill;
                    break;

                    /* Two Bills */
                    case Bills.Two:
                        quantity = TwoBill;
                    break;

                    /* Five Bills */
                    case Bills.Five:
                        quantity = FiveBill;
                    break;

                    /* Ten Bills */
                    case Bills.Ten:
                        quantity = TenBill;
                    break;

                    /* Twenty Bills */
                    case Bills.Twenty:
                        quantity = TwentyBill;
                    break;
                        
                    /* Fifty Bills */
                    case Bills.Fifty:
                        quantity = FiftyBill;
                    break;

                    /* Hundred Bills */
                    case Bills.Hundred:
                        quantity = HundredBill;
                    break;

                    default:
                        throw new NotImplementedException("Should never be reached");
                }
                /* Add the bills to the drawer */
                cd.AddBill(bill, quantity);
            }

            /* See if change needs to be made */
            if (AmountLeftToTender < 0)
                MakeChange();

            /* Print the receipt */
            PrintReceipt(1);

            /* Set the new order */
            SetNewOrder();
        }

        /// <summary>
        /// Balances the coins in the drawer to make effective change
        /// </summary>
        /// <param name="b"></param>
        private void BalanceCoins(Coins c)
        {
            Coins result = c;
            int quantity = 0;

            while (quantity == 0)
            {
                result = c + 1;
                switch (result)
                {
                    case Coins.Nickel:
                        quantity = cd.Nickels;
                        break;

                    case Coins.Dime:
                        quantity = cd.Dimes;
                        break;

                    case Coins.Quarter:
                        quantity = cd.Quarters;
                        break;

                    case Coins.HalfDollar:
                        quantity = cd.HalfDollars;
                        break;

                    case Coins.Dollar:
                        quantity = cd.Dollars;
                        if(quantity == 0)
                        {
                            if (cd.Ones > 0)
                            {
                                cd.RemoveBill(Bills.One, 1);
                                cd.AddCoin(Coins.Dollar, 1);
                                result = c;
                                quantity = 0;
                            }
                            else
                            {
                                BalanceBills(Bills.One);
                            }
                        }
                        break;

                    default:
                        throw new NotImplementedException("Should never be reached");
                }
            }

            switch (result)
            {
                case Coins.Dollar:
                    cd.RemoveCoin(Coins.Dollar, 1);
                    cd.AddCoin(Coins.HalfDollar, 2);
                    if (c == Coins.HalfDollar)
                        break;
                    else
                        goto case Coins.HalfDollar;

                case Coins.HalfDollar:
                    cd.RemoveCoin(Coins.HalfDollar, 1);
                    cd.AddCoin(Coins.Quarter, 2);
                    if (c == Coins.Quarter)
                        break;
                    else
                        goto case Coins.Quarter;

                case Coins.Quarter:
                    cd.RemoveCoin(Coins.Quarter, 1);
                    cd.AddCoin(Coins.Dime, 2);
                    cd.AddCoin(Coins.Nickel, 1);
                    if (c == Coins.Dime)
                        break;
                    else
                        goto case Coins.Dime;

                case Coins.Dime:
                    cd.RemoveCoin(Coins.Dime, 1);
                    cd.AddCoin(Coins.Nickel, 2);
                    if (c == Coins.Nickel)
                        break;
                    else
                        goto case Coins.Nickel;

                case Coins.Nickel:
                    cd.RemoveCoin(Coins.Nickel, 1);
                    cd.AddCoin(Coins.Penny, 5);
                    break;

                default:
                    throw new NotImplementedException("Should never be reached");
            }
        }

        /// <summary>
        /// Balances the bills in the drawer to make effective change
        /// </summary>
        /// <param name="b"></param>
        private void BalanceBills(Bills b)
        {
            Bills result = b;
            int quantity = 0;

            while(quantity == 0)
            {
                result = b + 1;
                switch(result)
                {
                    case Bills.Two:
                        quantity = cd.Twos;
                    break;

                    case Bills.Five:
                        quantity = cd.Fives;
                    break;

                    case Bills.Ten:
                        quantity = cd.Tens;
                    break;

                    case Bills.Twenty:
                        quantity = cd.Tens;
                    break;

                    case Bills.Fifty:
                        quantity = cd.Fifties;
                    break;

                    case Bills.Hundred:
                        quantity = cd.Hundreds;
                    break;

                    default:
                        throw new NotImplementedException("Change cannot be made Huston we have a major problem");
                }
            }

            switch(result)
            {
                case Bills.Hundred:
                    cd.RemoveBill(Bills.Hundred, 1);
                    cd.AddBill(Bills.Fifty, 2);
                    if (b == Bills.Fifty)
                        break;
                    else
                        goto case Bills.Fifty;

                case Bills.Fifty:
                    cd.RemoveBill(Bills.Fifty, 1);
                    cd.AddBill(Bills.Twenty, 2);
                    cd.AddBill(Bills.Ten, 1);
                    if (b == Bills.Twenty)
                        break;
                    else
                        goto case Bills.Twenty;

                case Bills.Twenty:
                    cd.RemoveBill(Bills.Twenty, 1);
                    cd.AddBill(Bills.Ten, 2);
                    if (b == Bills.Ten)
                        break;
                    else
                        goto case Bills.Ten;

                case Bills.Ten:
                    cd.RemoveBill(Bills.Ten, 1);
                    cd.AddBill(Bills.Five, 2);
                    if (b == Bills.Five)
                        break;
                    else
                        goto case Bills.Five;

                case Bills.Five:
                    cd.RemoveBill(Bills.Five, 1);
                    cd.AddBill(Bills.Two, 2);
                    cd.AddBill(Bills.One, 1);
                    if (b == Bills.Two)
                        break;
                    else
                        goto case Bills.Two;

                case Bills.Two:
                    cd.RemoveBill(Bills.Two, 1);
                    cd.AddBill(Bills.One, 2);
                    break;

                default:
                    throw new NotImplementedException("Should never be reached");
            }
        }

        /// <summary>
        /// Removes the change from the drawer
        /// </summary>
        private void MakeChange()
        {
            /* Get the absolute value, Makes mod easier to think about */
            double ChangeNeeded = Math.Abs(AmountLeftToTender);
            Change = ChangeNeeded;

            /* Make List so user knows what to give back */
            List<Bills> ListOfBillsGiven = new List<Bills>();
            List<Coins> ListOfCoinsGiven = new List<Coins>();


            /* Get all the coin enums and put them in reverse order */
            Coins[] coins = (Coins[])Enum.GetValues(typeof(Coins));
            Array.Reverse(coins);

            /* Get all the bill enums and put them in reverse order */
            Bills[] bills = (Bills[])Enum.GetValues(typeof(Bills));
            Array.Reverse(bills);

            /* See which bills need to be given back (Reverse Order of the Enum) */
            foreach (Bills b in bills)
            {
                int quantity;
                uint value;

                /* Filter through the bills */
                switch (b)
                { 
                    /* One Bills */
                    case Bills.One:
                        quantity = cd.Ones;
                        value = 1;
                    break;

                    /* Two Bills */
                    case Bills.Two:
                        quantity = cd.Twos;
                        value = 2;
                    break;

                    /* Five Bills */
                    case Bills.Five:
                        quantity = cd.Fives;
                        value = 5;
                    break;

                    /* Ten Bills */
                    case Bills.Ten:
                        quantity = cd.Tens;
                        value = 10;
                    break;

                    /* Twenty Bills */
                    case Bills.Twenty:
                        quantity = cd.Twenties;
                        value = 20;
                    break;

                    /* Fifty Bills */
                    case Bills.Fifty:
                        quantity = cd.Fifties;
                        value = 50;
                    break;

                    /* Hundred Bills */
                    case Bills.Hundred:
                        quantity = cd.Hundreds;
                        value = 100;
                    break;

                    /* Should never be reached */
                    default:
                        throw new NotImplementedException("Should never be reached");
                }

                /* Get as close as you can to 0 with dolla billz */
                while (ChangeNeeded - value >= 0)
                {
                    if (quantity == 0)
                        BalanceBills(b);
                    ChangeNeeded -= value;
                    cd.RemoveBill(b, 1);
                    quantity--;
                }
            }
        
            /* See which coins need to be given back (Reverse order of the Enum) */
            foreach (Coins c in coins)
            {
                int quantity;
                double value;

                /* Filter through the coins */
                switch (c)
                {
                    /* Pennies */
                    case Coins.Penny:
                        quantity = cd.Pennies;
                        value = .01;
                    break;

                    /* Nickels */
                    case Coins.Nickel:
                        quantity = cd.Nickels;
                        value = .05;
                    break;

                    /* Dimes */
                    case Coins.Dime:
                        quantity = cd.Dimes;
                        value = .1;
                    break;

                    /* Quarters */
                    case Coins.Quarter:
                        quantity = cd.Quarters;
                        value = .25;
                    break;

                    /* Half Dollars */
                    case Coins.HalfDollar:
                        quantity = cd.HalfDollars;
                        value = .5;
                    break;

                    /* Dollars */
                    case Coins.Dollar:
                        quantity = cd.Dollars;
                        value = 1;
                    break;

                    /* Should never be reached */
                    default:
                        throw new NotImplementedException("Should never be reached");
                }

                /* Remove the change until 0 is hit */
                while (ChangeNeeded - value >= 0)
                {
                    if (quantity == 0)
                        BalanceCoins(c);
                    ChangeNeeded -= value;
                    cd.RemoveCoin(c, 1);
                    quantity--;
                }
            }

            if(cd.Ones > 100)
            {
                cd.RemoveBill(Bills.One, 100);
                cd.AddBill(Bills.Hundred, 1);
            }
            if(cd.Twenties > 5)
            {
                cd.RemoveBill(Bills.Twenty, 5);
                cd.AddBill(Bills.Hundred, 1);
            }
            if(cd.Fifties > 2)
            {
                cd.RemoveBill(Bills.Fifty, 2);
                cd.AddBill(Bills.Hundred, 1);
            }
        }

        /// <summary>
        /// Creates the reciept to be sent to the printer
        /// </summary>
        /// <param name="cardOrCash">0 if card 1 if cash</param>
        private void PrintReceipt(int cardOrCash)
        {

            ReceiptPrinter rp = new ReceiptPrinter();
            StringBuilder sb = new StringBuilder();
            sb.Append("---------- COWBOY CAFE ----------\n");
            sb.Append(DateTime.Now + "\n");
            sb.Append("Order #: " + PrevOrderNumber + "\n");
            
            foreach(IOrderItem i in Items)
            {
                sb.Append(i.ToString() + "\t\t" + i.Price + "\n");
                foreach(string s in i.SpecialInstructions)
                {
                    sb.Append(s + "\n");
                }
                sb.Append("\n");
            }

            sb.Append("Subtotal: " + Subtotal + "\n");
            sb.Append("Tax: " + Tax + "\n");
            sb.Append("Total: " + TotalWithTax + "\n\n");

            if(cardOrCash == 1)
            {
                sb.Append("Paid: " + Paid + "\n");
                sb.Append("Change: " + Change + "\n");
            }
            else
            {
                sb.Append("Credit Card was used!");
            }

            string sr = sb.ToString();
            MessageBox.Show(sr);
            rp.Print(sr);
            ShowDrawerContents();
        }

        /// <summary>
        /// Something that helps the graders ;P
        /// </summary>
        private void ShowDrawerContents()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Current Contents of Drawer\n\n");
            sb.Append("---------- Coins ----------\n");
            sb.Append("Pennies: " + cd.Pennies + "\n");
            sb.Append("Nickels: " + cd.Nickels + "\n");
            sb.Append("Dimes: " + cd.Dimes + "\n");
            sb.Append("Quarters: " + cd.Quarters + "\n");
            sb.Append("Half Dollars: " + cd.HalfDollars + "\n");
            sb.Append("Dollars: " + cd.Dollars + "\n");

            sb.Append("\n\n---------- Bills ----------\n");
            sb.Append("Ones: " + cd.Ones + "\n");
            sb.Append("Twos: " + cd.Twos + "\n");
            sb.Append("Fives: " + cd.Fives + "\n");
            sb.Append("Tens: " + cd.Tens + "\n");
            sb.Append("Twenties: " + cd.Twenties + "\n");
            sb.Append("Fifties: " + cd.Fifties + "\n");
            sb.Append("Hundreds: " + cd.Hundreds + "\n\n");

            sb.Append("Total in Drawer : " + cd.TotalValue);

            MessageBox.Show(sb.ToString());
        }
    }
}
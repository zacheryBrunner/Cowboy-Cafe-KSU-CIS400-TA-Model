﻿/*Author: Zachery Brunner
 *Class: Order.cs
 *Purpose: This class represents a client at the cowboy cafe ordering a meal
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CowboyCafe.Data
{
    public class Order : INotifyPropertyChanged
    {
        /// <summary>
        /// This event will be invoked when a property relating to the order is changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Invokes all of the binding properties
        /// </summary>
        public void InvokePropertyChanged()
        {
            /* Invoke all events to ensure you don't miss anything */
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Subtotal"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Items"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ItemPrices"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
        }

        /// <summary>
        /// Property to get the current order number
        /// </summary>
        public uint OrderNumber { get; private set; }

        /// <summary>
        /// Property to get or set the subtotal of the current order
        /// </summary>
        public double Subtotal { get; private set; }

        /// <summary>
        /// The list of the items on the current order
        /// </summary>
        private List<IOrderItem> items;

        /// <summary>
        /// Property to return the list of items in the current order
        /// </summary>
        public IEnumerable<IOrderItem> Items { get { return items.ToArray(); } }

        /// <summary>
        /// The list of the item prices on the currentn order
        /// </summary>
        private List<string> itemPrices;

        /// <summary>
        /// Property to return the list of item prices in the current order 
        /// </summary>
        public IEnumerable<string> ItemPrices { get { return itemPrices.ToArray(); } }

        /// <summary>
        /// Public constructor that initializes the list
        /// </summary>
        /// <param name="i">The current order number</param>
        public Order(uint i)
        {
            items = new List<IOrderItem>();
            itemPrices = new List<string>();
            OrderNumber = i;
        }

        /// <summary>
        /// This method will add everything that is needed to respective list for the client
        /// </summary>
        /// <param name="i">The item needed to be added to the list</param>
        public void Add(IOrderItem i)
        {
            /* Do some computation here to make it easier in the future */
            double priceOfItem = i.Price;
            string priceOfItemAsCurrency = String.Format("{0:C}", priceOfItem);
            Subtotal += priceOfItem;

            /* Add the computed values to their respective lists */
            items.Add(i);
            itemPrices.Add(priceOfItemAsCurrency);
            InvokePropertyChanged();
        }

        /// <summary>
        /// This method will remove everything related to the item passed in from the reciept
        /// </summary>
        /// <param name="i">The item needed to be removed to the list</param>
        public void Remove(IOrderItem i)
        {
            /* Do some computation here too to ensure everything is removed */
            double priceOfItem = i.Price;
            Subtotal -= priceOfItem;

            /* Remove the computed values to their respective lists */
            int index = items.IndexOf(i);
            items.Remove(i);
            itemPrices.RemoveAt(index);
            InvokePropertyChanged();
        }

        /// <summary>
        /// The special instructions for the current order item
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        { 
            get
            {
                IOrderItem[] listOfOrderItems = (IOrderItem[])Items;
                List<string> s = listOfOrderItems[listOfOrderItems.Length].SpecialInstructions;
                return s.ToArray();
            }
        }
    }
}
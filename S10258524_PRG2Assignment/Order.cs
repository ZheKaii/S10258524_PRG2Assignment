﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10258524_PRG2Assignment
{
    internal class Order
    {
        public int Id { get; set; }
        public DateTime TimeReceived { get; set; }
        public DateTime? TImeFulfilled { get; set; }
        public List<IceCream> IceCreamList { get; set; } = new List<IceCream>();

        public Order() { }
        public Order(int id, DateTime timeReceived)
        {
            Id = id;
            TimeReceived = timeReceived;
        }
        public int ModifyIceCream()
        {
            
        }
        public IceCream AddIceCream()
        {

        }
        public int DeleteIceCream()
        {

        }
        public double CalculateTotal()
        {

        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
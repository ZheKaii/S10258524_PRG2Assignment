﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//==========================================
// Student Number : S10258524
// Student Name : Heng Zhe Kai
// Partner Name : Gan Yu Hong
//==========================================

namespace S10258524_PRG2Assignment
{
    internal class Order
    {
        private int id;
        private DateTime timeReceived;
        private DateTime? timeFulfilled;
        private List<IceCream> iceCreamsList;
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

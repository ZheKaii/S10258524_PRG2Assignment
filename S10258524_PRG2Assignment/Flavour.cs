﻿using System;
using System.Collections.Generic;
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
    internal class Flavour
    {
        public string Type { get; set; }
        public bool Premimum { get; set; }
        public int Quantity { get; set; }
        public Flavour() { }
        public Flavour(string type, bool premium, int quantity)
        {
            Type = type;
            Premimum = premium;
            Quantity = quantity;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
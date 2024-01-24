using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//==========================================
// Student Number : S10258441
// Student Name : Gan Yu Hong
// Partner Name : Heng Zhe Kai
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
        public void ModifyIceCream(int index)
        {
            
        }
        public void AddIceCream(IceCream iceCream)
        {
            IceCreamList.Add(iceCream);
        }
        public void DeleteIceCream(int index)
        {
            IceCreamList.RemoveAt(index);
        }
        public double CalculateTotal()
        {
            return IceCreamList.Count;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}

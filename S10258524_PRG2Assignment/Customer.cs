using System;
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
    internal class Customer
    {
        private string name;
        private int memberid;
        private DateTime dob;
        private Order currentOrder;
        private List<Order> ordersHistory;
        private PointCard rewards;
        public string Name { get; set; }
        public int MemberId { get; set; }
        public DateTime Dob { get; set; }
        public Order CurrentOrder { get; set; }
        public List<Order> OrderHistory { get; set; } = new List<Order>();
        public PointCard Rewards { get; set; }
        public Customer() { }
        public Customer(string name, int memberId, DateTime dob)
        {
            Name = name;
            MemberId = memberId;
            Dob = dob;
        }

        public Order MakeOrder()
        {
            CurrentOrder = new Order();
            return CurrentOrder;
        }
        public bool IsBirthday()
        {
            DateTime dateTime = DateTime.Today;
            if (dateTime == Dob)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override string ToString()
        {
            return Name + MemberId + Dob + Rewards;
        }
    }
}

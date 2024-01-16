using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10258524_PRG2Assignment
{
    internal class PointCard
    {
        public int Points { get; set; }
        public int PunchCards { get; set; }
        public string Tier { get; set; }

        public PointCard() { }
        public PointCard(int points, int punchCard, string tier)
        {
            Points = points;
            PunchCards = punchCard;
            Tier = tier;
        }
        public int AddPoints()
        {   
            Points += Points;
            return Points;
        }
        public int RedeemPoints()
        {
            int money = Points;
            return money;
        }
        public Punch()
        {
            if (PunchCards == 10) { }
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}

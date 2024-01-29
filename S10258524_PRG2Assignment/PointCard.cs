using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
    internal class PointCard
    {
        private int points;
        private int punchcards;
        private int tier;
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

        public void AddPoints(int amount)
        {
            int earnedPoints = (int)Math.Floor(amount * 0.72);
            Points += earnedPoints;
            Punch();
        }
        public void RedeemPoints(int amount)
        {
            if (Tier == "Silver" || Tier == "Gold")
            {
                Points -= amount;
            }
        }
        public void Punch()
        {
            PunchCards++;
            if (PunchCards == 10)
            {
                PunchCards = 0;
            }
        }

        public override string ToString()
        {
            return Points + PunchCards + Tier;
        }
    }
}

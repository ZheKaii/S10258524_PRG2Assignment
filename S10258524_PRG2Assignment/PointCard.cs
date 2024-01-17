using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
    internal class PointCard
    {
        private int points;
        private int punchcards;
        private string tier;
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
        public override string ToString()
        {
            return base.ToString();
        }
    }
}

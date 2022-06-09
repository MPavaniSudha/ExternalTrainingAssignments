using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackJackGameAssesment.Models
{
    public class ShuffleCards
    {
        public string CName { get; set; }
        public int CVal { get; set; }

        public void RandomCards()
        {
            //Getting the data from database table Cards and taken the card randomly and stores the cardvalue and cardname into given variables
            BlackJackDBEntities BJ = new BlackJackDBEntities();
            List<Card> card = BJ.Cards.ToList();

            Random random = new Random(Guid.NewGuid().GetHashCode()); 
            int r = random.Next(card.Count);
            var res = card[r].CardName.ToString();
            CVal = card[r].CardValue.Value;
            CName = res;
        }
    }
}
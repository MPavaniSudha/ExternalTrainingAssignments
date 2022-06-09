using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackJackGameAssesment.Models
{
    public class Dealt
    {
        public string PlayerCard1 { get; set; }
        public string PlayerCard2 { get; set; }
        public string DealerCard { get; set; }

        ShuffleCards SC = new ShuffleCards();

        //It will generate one random card and returns the cardname and stores the cardvalue into Playerscore
        public string PlayerFirstCard()
        {
            SC.RandomCards();
            PlayerCard1 = SC.CName;
            Scores.Playerscore = Scores.Playerscore + SC.CVal;
            return PlayerCard1;
        }

        //It will generate one random card and returns the cardname and add the previous playerscore to this score
        public string PlayerSecondCard()
        {
            SC.RandomCards();
            PlayerCard2 = SC.CName;
            Scores.Playerscore = Scores.Playerscore + SC.CVal;
            return PlayerCard2;
        }
        
        //It will generate one random card and returns the cardname and stores the cardvalue into Dealerscore

        public string DealerCards()
        {
            SC.RandomCards();
            DealerCard = SC.CName;
            Scores.Dealerscore = Scores.Dealerscore + SC.CVal;
            return DealerCard;
        }
    }
}
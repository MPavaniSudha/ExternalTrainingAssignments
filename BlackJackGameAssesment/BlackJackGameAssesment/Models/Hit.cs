using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackJackGameAssesment.Models
{
    public class Hit
    {
        public string hitcard { get; set; }
        
        //It will  shuffle the cards randomly
        ShuffleCards SC = new ShuffleCards();

        //It will generate one random card and return the cardname,update the playerscore
        //When the playerscore is <=21
        
        public string PlayerHit()
        {
            if (Scores.Playerscore <= 21)
            {
                SC.RandomCards();
                hitcard = SC.CName;
                Scores.Playerscore = Scores.Playerscore + SC.CVal;
            }
            else
            {
                return "No Card Will be Generated because PlayerScore must be Lessthan 21";
            }
            return hitcard;
        }

        //It will generate one random card and return the cardname,updates the Dealerscore
        //When the Dealerscore is <=17
        
        public string DealerHit()
        {
            if(Scores.Dealerscore <= 17)
            {
                SC.RandomCards();
                hitcard = SC.CName;
                Scores.Dealerscore = Scores.Dealerscore + SC.CVal;
            }
            return hitcard;
        }
    }
}
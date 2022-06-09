using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackJackGameAssesment.Models
{
    public class PlayingGame
    {
        //It checks the  Scores of the Player&Dealer and display the result whether they win or lose
        public string CheckGameStatus()
        {
            if (Scores.Playerscore > 21 && Scores.Dealerscore <= 21)
            {
                return "DealerWons,PlayerLoses";
            }
            else if (Scores.Dealerscore > 21 && Scores.Playerscore <= 21)
            {
                return "PlayerWons,DealerLoses";
            }
            else if (Scores.Playerscore == Scores.Dealerscore)
            {
                return "GameTie";
            }
            else if (Scores.Playerscore <= 21)
            {
                if (Scores.Playerscore < Scores.Dealerscore)
                {
                    return "PlayerWons, DealerLoses";
                }
                else
                {
                    return "DealerWons,PlayerLoses";
                }
            }
            return "OOps!!Something Went Wrong";
        }

    }
}
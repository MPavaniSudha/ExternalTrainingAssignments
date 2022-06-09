using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlackJackGameAssesment.Models
{
    public class Scores
    {
        public static int Playerscore { get; set; }
        public static int Dealerscore { get; set; }
        public static int PlayerHitCount { get; set; }
        public static int DealerHitCount { get; set; }
    }
}
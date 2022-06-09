using BlackJackGameAssesment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlackJackGameAssesment.Controllers
{
    public class GameController : Controller
    {
        // GET: Game

        //Create Instance of Entityframework dbContext Class
        BlackJackDBEntities bje = new BlackJackDBEntities();
        
        public ActionResult Index()
        {
            return View();
        }
       
        //It will randomly selected the cards and passes the cards to the players(two Cards) and dealer(one card)
        public ActionResult GameStart()
        {
            Dealt d = new Dealt();
            TempData["PlayerCard1"] = d.PlayerFirstCard();
            TempData["PlayerCard2"] = d.PlayerSecondCard();
            TempData["DealerCard"] = d.DealerCards();
            return View();
        }
        
        //Call a playerhit method from the hit class and stores the Playerhit() data into Tempdata[]
        public ActionResult Hit()
        {
            Hit h = new Hit();
            if (Scores.PlayerHitCount<1)
            {
                TempData["PlayerHitCard1"] = h.PlayerHit();
                Scores.PlayerHitCount = Scores.PlayerHitCount + 1;
            }
            
            else if(Scores.PlayerHitCount<2)
            {
                TempData["PlayerHitCard2"] = h.PlayerHit();
                Scores.PlayerHitCount = Scores.PlayerHitCount + 1;
            }

            else if (Scores.PlayerHitCount<3)
            {
                TempData["PlayerHitCard3"] = h.PlayerHit();
            }
            return View("GameStart");
        }
        
        //Call a Dealerhit method from the hit class and stores the Dealerhit() data into Tempdata[]
        public ActionResult Stand()
        {
            Hit h = new Hit();
            PlayingGame pg = new PlayingGame();
            while (Scores.Dealerscore <= 17)
            {
                if (Scores.DealerHitCount<1)
                {
                    TempData["DealerHitCard1"] = h.DealerHit();
                    Scores.DealerHitCount = Scores.DealerHitCount + 1;
                }

                else if (Scores.DealerHitCount<2)
                {
                    TempData["DealerHitCard2"] = h.DealerHit();
                    Scores.DealerHitCount = Scores.DealerHitCount + 1;
                }
                else if (Scores.DealerHitCount<3)
                {
                    TempData["DealerHitCard3"] = h.DealerHit();
                    Scores.DealerHitCount = Scores.DealerHitCount + 1;
                }
                else if (Scores.DealerHitCount<4)
                {
                    TempData["DealerHitCard4"] = h.DealerHit();
                }
            }
            if (Scores.Dealerscore >= 17)
            {
                ViewData["GameStatus"] = pg.CheckGameStatus();
            }
            return View("GameStart");
        }

        //It will restart the game
        public ActionResult PlayAgain()
        {
            GameRestart gr = new GameRestart();
            gr.Restart();
            TempData.Remove("PlayerhitCard1");
            TempData.Remove("PlayerhitCard2");
            TempData.Remove("PlayerhitCard3");
            TempData.Remove("DealerhitCard1");
            TempData.Remove("DealerhitCard2");
            TempData.Remove("DealerhitCard3");
            TempData.Remove("DealerhitCard4");
            return RedirectToAction("GameStart");
        }

        //It displays the report of the previous game history results
        public ActionResult SessionReport()
        {
            List<Session> session = bje.Sessions.ToList();
            return View(session);
        }

        //It will save the game results
        public ActionResult GameSave()
        {
            PlayingGame pg = new PlayingGame();
            Session ss = new Session();
            ss.PlayerTotal = Scores.Playerscore;
            ss.DealerTotal = Scores.Dealerscore;
            ss.GameResult = pg.CheckGameStatus();
            bje.Sessions.Add(ss);
            bje.SaveChanges();
            return View("GameStart");
        }

    }
}
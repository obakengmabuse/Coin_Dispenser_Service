using CD_Service.Data;
using CD_Service.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CD_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinChangerController : ControllerBase
    {
        private AppDbContext _context;
        public CoinChangerController(AppDbContext context)
        {
            _context = context;
        }

        //This is the API that get the minimium amount of coins
        // GET: api/<CoinChangerController>
        [HttpGet]
        [Route("/api/CoinChanger")]
        public IEnumerable<CoinLookUp> GetCoins(double amount)
        {

            List<CoinLookUp> coinDenominations = _context.CoinLookup.ToList(); //Gets the list of coins from the database

            List<CoinLookUp> changedCoins = new List<CoinLookUp>(); //The list that will store the coins for a given amount

            double Remainder = amount; //Remainder is the remaining amount that needs to be changed to coin(s)

            //Iteration through the list of coins stored in the database and substract the coin value from the remainder until the remainder is equal to 0

            foreach (CoinLookUp coin in coinDenominations)
            {
                while (Remainder >= coin.Value)
                {
                    Remainder -= coin.Value;
                    changedCoins.Add(coin);
                }
            }
            return changedCoins;
        }


    }
}

using DailySharePriceApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace DailySharePriceApi.Repository
{
    public class StockRepository : IStockRepository
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(StockRepository));

        public static List<Stock> stocklist = new List<Stock>()
        {
            new Stock { StockId = 101, StockName = "NESTLE", StockValue = 17785},
            new Stock { StockId = 102, StockName = "ONGC", StockValue = 131.15},
            new Stock {StockId = 103, StockName = "TITAN", StockValue = 1946.10},
            new Stock { StockId = 104, StockName = "HDFC", StockValue = 2205.70},
            new Stock { StockId = 105, StockName = "AXIS", StockValue = 644.25},
            new Stock {StockId = 106, StockName = "TATA", StockValue = 412.70},
            new Stock { StockId = 107, StockName = "HEROMOTORS", StockValue = 2755.50},
            new Stock { StockId = 108, StockName = "LIC", StockValue = 676.75},
            new Stock {StockId = 109, StockName = "RELIANCE", StockValue = 1975.87},
            new Stock { StockId = 110, StockName = "ITC", StockValue = 284.35},
            new Stock {StockId = 111, StockName = "INDIANOIL", StockValue = 78.90},

        };
       
        /// <summary>
        /// It is a Method in Repository that is being called by the Provider and returns the Stock based on the StockName
        /// </summary>
        /// <param name="stockname"></param>
        /// <returns></returns>
        public Stock GetStockByNameRepository(string stockname)
        {
            Stock stockData = null;
            try
            {
                _log4net.Info("In Stock Repository, StockProvider is calling the Method GetStockByNameRepository and " + stockname + " is being searched");
                stockData = stocklist.FirstOrDefault(s => s.StockName == stockname);
                if (stockData != null)
                {
                    var jsonStock = JsonConvert.SerializeObject(stockData);
                    _log4net.Info("Stock Found " + jsonStock);
                }
                else
                {
                    _log4net.Info("In StockRepository, Stock " + stockname + " is not found");
                }
            }
            catch(Exception ex)
            {
                _log4net.Error("In Stock Repository, Exception Found - " + ex.Message);
            }
            return stockData;            
        }
    }
}

using Demo_NMM.Basic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_NMM.Basic.DAL
{
    /// <summary>
    /// Class to initialize the data
    /// </summary>
    public static class Data
    {
        /// <summary>
        /// Initialize a list of breweries and store it in a a session variable
        /// </summary>
        public static void InitializeBreweries()
        {
            //
            // Create a temporary list of breweries
            //
            List<Brewery> breweries = new List<Brewery>();

            breweries.Add(new Brewery
            {
                ID = 1,
                Name = "Right Brain Brewery",
                Address = "225 E. 16th St",
                City = "Traverse City",
                State = AppEnum.StateAbrv.MI,
                Zip = "49684",
                Phone = "(231) 944-1239"
            });

            breweries.Add(new Brewery
            {
                ID = 2,
                Name = "Acoustic Tap Room",
                Address = "119 Maple St",
                City = "Traverse City",
                State = AppEnum.StateAbrv.MI,
                Zip = "49684",
                Phone = "(231) 883-2012"
            });

            breweries.Add(new Brewery
            {
                ID = 3,
                Name = "Beggars Brewery",
                Address = "4177 Village Park Dr. Suite C",
                City = "Traverse City",
                State = AppEnum.StateAbrv.MI,
                Zip = "49684",
                Phone = "N/A"
            });

            //
            // Store the list of breweries in a session variable
            //
            HttpContext.Current.Session["Breweries"] = breweries;

        }
    }
}
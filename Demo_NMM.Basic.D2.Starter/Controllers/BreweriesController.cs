using Demo_NMM.Basic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_NMM.Basic.Controllers
{
    public class BreweriesController : Controller
    {
        // 
        // Landing page
        //
        public ActionResult Index()
        {
            return View();
        }

        //
        // Show table view
        //
        public ActionResult ShowTable()
        {
            List<Brewery> breweries = (List<Brewery>)Session["Breweries"];

            return View(breweries);
        }

        //
        // Show list view
        //
        public ActionResult ShowList()
        {
            List<Brewery> breweries = (List<Brewery>)Session["Breweries"];

            return View(breweries);
        }

        //
        // Show detail view
        //
        public ActionResult ShowDetail(int id)
        {
            List<Brewery> breweries = (List<Brewery>)Session["Breweries"];

            var brewery = breweries[breweries.FindIndex(x => x.ID == id)];

            return View(brewery);
        }

        //
        // Show brewery to delete in detail view
        // 
        public ActionResult DeleteBrewery(int id)
        {
            List<Brewery> breweries = (List<Brewery>)Session["Breweries"];

            var brewery = breweries[breweries.FindIndex(x => x.ID == id)];

            return View(brewery);
        }

        //
        // Process request from delete brewery form
        //
        [HttpPost]
        public ActionResult DeleteBrewery(FormCollection form)
        {
            if (form["operation"] == "Delete")
            {
                List<Brewery> breweries = (List<Brewery>)Session["Breweries"];
                var brewery = breweries[breweries.FindIndex(x => x.ID == Convert.ToInt32(form["ID"]))];

                breweries.RemoveAt(brewery.ID - 1);

                Session["Breweries"] = breweries;
            }

            return Redirect("/Breweries/ShowTable");
        }

        //
        // Show new brewery form
        //
        public ActionResult CreateBrewery()
        {
            return View();
        }

        //
        // Process request from new brewery form
        //
        [HttpPost]
        public ActionResult CreateBrewery(FormCollection form)
        {
            if (form["operation"] == "Add")
            {
                List<Brewery> breweries = (List<Brewery>)Session["Breweries"];
                AppEnum.StateAbrv result = AppEnum.StateAbrv.MI;
                Enum.TryParse<AppEnum.StateAbrv>(form["state"], out result);
                int maxID = breweries.Max(x => x.ID) + 1;

                var addBrewery = new Brewery()
                {
                    ID = maxID,
                    Name = form["name"],
                    Address = form["address"],
                    City = form["city"],
                    State = result,
                    Zip = form["zip"],
                    Phone = form["phone"]
                };

                breweries.Add(addBrewery);

                Session["Breweries"] = breweries;
            }

            return Redirect("/Breweries/ShowTable");
        }

        //
        // Show brewery to update in edit view
        //
        public ActionResult UpdateBrewery(int id)
        {
            List<Brewery> breweries = (List<Brewery>)Session["Breweries"];

            var brewery = breweries[breweries.FindIndex(x => x.ID == id)];

            return View(brewery);
        }

        //
        // Process request from update brewery form
        //
        [HttpPost]
        public ActionResult UpdateBrewery(FormCollection form)
        {
            if (form["operation"] == "Edit")
            {
                List<Brewery> breweries = (List<Brewery>)Session["Breweries"];
                var brewery = breweries[breweries.FindIndex(x => x.ID == Convert.ToInt32(form["ID"]))];
                AppEnum.StateAbrv result = AppEnum.StateAbrv.MI;
                Enum.TryParse<AppEnum.StateAbrv>(form["state"], out result);

                var editBrewery = new Brewery()
                {
                    ID = int.Parse(form["id"]),
                    Name = form["name"],
                    Address = form["address"],
                    City = form["city"],
                    State = result,
                    Zip = form["zip"],
                    Phone = form["phone"]
                };

                breweries[breweries.FindIndex(x => x.ID == brewery.ID)] = editBrewery;

                Session["Breweries"] = breweries;
            }

            return Redirect("/Breweries/ShowTable");
        }

        //
        // Reload initial data set
        //
        public ActionResult ReloadData()
        {
            DAL.Data.InitializeBreweries();

            return Redirect("/Breweries/ShowTable");
        }

        //
        // Get next ID number ensure uniqueness
        //
        private int GetNextID()
        {
            List<Brewery> breweries = (List<Brewery>)Session["Breweries"];

            return breweries.Max(x => x.ID) + 1;
        }
    }
}
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace GodOl
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("Default", "", "~/Pages/BeerPages/BeerList.aspx");

            routes.MapPageRoute("Error", "serverfel", "~/Pages/Shared/Error.aspx");

            routes.MapPageRoute("BeerList", "beers", "~/Pages/BeerPages/BeerList.aspx");
            routes.MapPageRoute("BeerCreate", "beer/new", "~/Pages/BeerPages/Insert.aspx");
            routes.MapPageRoute("BeerDetails", "beer/{id}", "~/Pages/BeerPages/Details.aspx");
            routes.MapPageRoute("BeerEdit", "beer/{id}/edit", "~/Pages/BeerPages/Edit.aspx");
            routes.MapPageRoute("BeerDelete", "beer/{id}/delete", "~/Pages/BeerPages/Delete.aspx");

            routes.MapPageRoute("BreweryList", "breweries", "~/Pages/BreweryPages/BreweryList.aspx");
            routes.MapPageRoute("BreweryCreate", "brewery/new", "~/Pages/BreweryPages/Insert.aspx");
            routes.MapPageRoute("BreweryDetails", "brewery/{id}", "~/Pages/BreweryPages/Details.aspx");
            routes.MapPageRoute("BreweryEdit", "brewery/{id}/edit", "~/Pages/BreweryPages/Edit.aspx");
            routes.MapPageRoute("BreweryDelete", "brewery/{id}/delete", "~/Pages/BreweryPages/Delete.aspx");

            
        }
    }
}
using GodOl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GodOl.Pages.BeerPages
{
    public partial class BeerList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<Beer> ListView1_GetData()
        {
            try
            {
                var s = new Service();
                return s.GetBeers();
            }
            catch
            {
                ModelState.AddModelError(String.Empty, "Kunde inte hämta öl...");
                return null;
            }
        }

        protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var beer = (Beer)e.Item.DataItem;
            var s = new Service();

            var beerType = s.GetBeerTypeById(beer.BeerTypeId);
            var brewery = s.GetBreweryById(beer.BreweryId);

            var lblBeerType = e.Item.FindControl("lblBeerType") as Label;
            var hlBrewery = e.Item.FindControl("hlBrewery") as HyperLink;

            lblBeerType.Text = beerType.BType;
            hlBrewery.Text = brewery.Name;
            hlBrewery.NavigateUrl = GetRouteUrl("BreweryDetails", new { id = brewery.BreweryId });
        }


    }
}
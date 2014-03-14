using GodOl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GodOl.Pages.BeerPages
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public Beer fwBeerDetails_GetItem([RouteData]int id)
        {
            try
            {
                var s = new Service();
                return s.GetBeerById(id);
            }
            catch (Exception)
            {
                Page.ModelState.AddModelError(String.Empty, "Databasfel vid läsning av data.");
                return null;
            }
        }

        protected void fwBeerDetails_DataBound(object sender, EventArgs e)
        {
            var beer = (Beer)fwBeerDetails.DataItem;
            var s = new Service();

            var brewery = s.GetBreweryById(beer.BeweryId);
            var beerType = s.GetBeerTypeById(beer.BeerTypeId);

            var lblBeerType = fwBeerDetails.FindControl("lblBeerType") as Label;
            var hlBrewery = fwBeerDetails.FindControl("hlBrewery") as HyperLink;

            lblBeerType.Text = beerType.BType;

            hlBrewery.Text = brewery.Name;
            hlBrewery.NavigateUrl = GetRouteUrl("BreweryDetails", new { id = brewery.BreweryId });
        }

    }
}
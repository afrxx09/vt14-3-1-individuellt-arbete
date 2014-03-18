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
            lblSuccess.Text = Page.GetTempData("SuccessMessage") as String;
            pnlSuccess.Visible = !String.IsNullOrWhiteSpace(lblSuccess.Text);
        }

        /// <summary>
        /// Laddar ett ölobjekt för databasen till listview:n.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Beer-objekt</returns>
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

        /// <summary>
        /// Hämtar bryggeiet och öltypen baserat på deras id:n från Beer-objektet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void fwBeerDetails_DataBound(object sender, EventArgs e)
        {
            var beer = (Beer)fwBeerDetails.DataItem;
            var s = new Service();

            var brewery = s.GetBreweryById(beer.BreweryId);
            var beerType = s.GetBeerTypeById(beer.BeerTypeId);

            var lblBeerType = fwBeerDetails.FindControl("lblBeerType") as Label;
            var hlBrewery = fwBeerDetails.FindControl("hlBrewery") as HyperLink;

            lblBeerType.Text = beerType.BType;

            hlBrewery.Text = brewery.Name;
            hlBrewery.NavigateUrl = GetRouteUrl("BreweryDetails", new { id = brewery.BreweryId });
        }

    }
}